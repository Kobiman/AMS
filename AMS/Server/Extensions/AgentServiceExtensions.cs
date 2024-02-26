using AMS.Shared;

namespace AMS.Server.Extensions
{
    public static class AgentServiceExtensions
    {
        public static IEnumerable<Sales_Payin_Payout> JoinPayInPayOut(this List<SalesDto2> sales, List<PayinPayout> payout_payin, List<AgentExpense> expenses)
        {
            var payoutPayInDic = payout_payin.GroupBy(x=>x.SalesId).ToDictionary(x=>x.Key,x=>x.ToList());
            var expensesDic = expenses.GroupBy(x => x.SalesId).ToDictionary(x => x.Key, x => x.ToList());

            foreach (var s in sales)
            {
                var payInAmount = payoutPayInDic.TryGetValue(s.Id, out List<PayinPayout> payin) ? payin.Sum(x => x.PayinAmount) : 0;
                var payoutAmount = payoutPayInDic.TryGetValue(s.Id, out List<PayinPayout> payout) ? payout.Sum(x => x.PayoutAmount) : 0;
                var expenseAmount = expensesDic.TryGetValue(s.Id, out List<AgentExpense> e) ? e.Sum(x => x.Amount) : 0;
                yield return new Sales_Payin_Payout
                        (
                            s.AccountId,
                            s.AgentId,
                            s.DailySales,
                            s.Description,
                            s.EntryDate,
                            s.DrawDate,
                            s.WinAmount,
                            s.ReceiptNumber,
                            payInAmount,
                            payoutAmount,
                            expenseAmount
                        );
            }
        }

        public static List<SalesDetails> GetSalesDetails(this IGrouping<string, Sales_Payin_Payout> x)
        {
            return x.Select(x => new SalesDetails
                           (
                               x.AccountId,
                               x.AgentId,
                               "",
                               x.DailySales,
                               x.Description,
                               x.EntryDate,
                               x.DrawDate,
                               x.WinAmount,
                               x.ReceiptNumber,
                               0,
                               0,
                               x.PayinAmount,
                               x.PayoutAmount,
                               x.ExpenseAmount
                           )).ToList();
        }

        public static List<SalesDetails> TransformDetails(this List<SalesDetails> details)
        {
            List<SalesDetails> sales = new();
            List<SalesDetails> list = new();
            var _list = details.OrderBy(x => x.DrawDate).ToList();
            // SalesDetails s1 = list.FirstOrDefault(x=>x.Description == "balance b/f") with { OpeningBalance = list[0].DailySales, DailySales = 0, WinAmount = 0, PayinAmount = 0, PayoutAmount = 0, EndBalance = list[0].DailySales };
            //sales.Add(s1);

            var s1 = _list.FirstOrDefault(x => x.Description.Equals("balance b/f",StringComparison.OrdinalIgnoreCase));
            if (s1 != null)
            {
                sales.Add(s1 with { OpeningBalance = s1.DailySales, DailySales = 0, WinAmount = 0, PayinAmount = 0, PayoutAmount = 0, ExpenseAmount = 0, EndBalance = s1.DailySales });
                _list.Remove(s1);
                list = new List<SalesDetails>
                {
                    s1
                };
                list.AddRange(_list); 
            }
            else
            {
                sales.Add(_list[0] with { OpeningBalance = _list[0].DailySales, DailySales = 0, WinAmount = 0, PayinAmount = 0, PayoutAmount = 0, ExpenseAmount = 0, EndBalance = _list[0].DailySales });
            }


            for (int i = 1; i < list.Count; i++)
            {
                SalesDetails? s = list[i];
                SalesDetails s2 = s with { OpeningBalance = sales[i - 1].EndBalance, EndBalance = s.DailySales - s.WinAmount - s.PayinAmount - s.PayoutAmount - s.ExpenseAmount + sales[i - 1].EndBalance };
                sales.Add(s2);

            }
            return sales;
        }

        public static IEnumerable<GroupedPayinPayout> Group(this List<SalesDto2> sales, List<PayinPayout> payout_payin, List<AgentExpense> expenses)
        {
            return sales.JoinPayInPayOut(payout_payin, expenses)
                             .GroupBy(x => x.AgentId)
                             .Select(x => new GroupedPayinPayout
                             (
                                 x.Key,
                                 x.Sum(x => x.DailySales),
                                 x.Sum(x => x.WinAmount),
                                 x.GetSalesDetails()
                             ));
        }

        public static IEnumerable<AgentReportDto> GetAgentReport(this List<SalesDto2> sales, Dictionary<string?, string?> agents, List<PayinPayout> payout_payin, List<AgentExpense> expenses)
        {
            return sales.Group(payout_payin, expenses)
                            .Select(x =>
                            {
                                var payinAmount = payout_payin
                                .Where(y => y.AgentId == x.AgentId)
                                .Sum(y => y.PayinAmount);
                                var payoutAmount = payout_payin
                                .Where(y => y.AgentId == x.AgentId)
                                .Sum(y => y.PayoutAmount);
                                var amount = payout_payin
                                .Where(y => y.AgentId == x.AgentId)
                                .Sum(y => y.Amount);
                                var expenseAmount = expenses.Where(y => y.AgentId == x.AgentId)
                                .Sum(y => y.Amount);
                                return new AgentReportDto
                                {
                                    AgentId = x.AgentId,
                                    Name = agents.TryGetValue(x.AgentId, out string? agent) ? agent : "",
                                    Sales = x.DailySales,
                                    Wins = x.WinAmount,
                                    Payin = payinAmount,
                                    Payout = payoutAmount,
                                    ExpenseAmount = expenseAmount,
                                    Balance = x.DailySales - x.WinAmount - amount,
                                    Details = x.Details.TransformDetails(),
                                };
                            });
        }
    }
}
