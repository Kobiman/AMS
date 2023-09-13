using AMS.Shared;

namespace AMS.Server.Extensions
{
    public static class AgentServiceExtensions
    {
        public static IEnumerable<Sales_Payin_Payout> JoinPayInPayOut(this List<SalesDto2> sales, List<PayinPayout> payout_payin)
        {
            var list = payout_payin.GroupBy(x=>x.SalesId).ToDictionary(x=>x.Key,x=>x.ToList());
            foreach (var s in sales)
            {
                if(list.TryGetValue(s.Id, out List<PayinPayout> p))
                {
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
                            p.Sum(x=>x.PayinAmount),
                            p.Sum(x => x.PayoutAmount)
                        );
                }
                else
                {
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
                            0,
                            0
                        );
                }
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
                               x.PayoutAmount
                           )).ToList();
        }

        public static List<SalesDetails> TransformDetails(this List<SalesDetails> details)
        {
            List<SalesDetails> list = details.OrderBy(x => x.EntryDate).ToList();
            List<SalesDetails> sales = new();
            for (int i = 0; i < list.Count; i++)
            {
                SalesDetails? s = list[i];
                if (i == 0)
                {
                    SalesDetails s2 = s with { OpeningBalance = 0, EndBalance = s.DailySales - s.WinAmount - s.PayinAmount - s.PayoutAmount };
                    sales.Add(s2);
                }
                else
                {
                    SalesDetails s2 = s with { OpeningBalance = sales[i - 1].EndBalance, EndBalance = s.DailySales - s.WinAmount - s.PayinAmount - s.PayoutAmount + sales[i - 1].EndBalance };
                    sales.Add(s2);
                }

            }
            return sales;
        }

        public static IEnumerable<GroupedPayinPayout> Group(this List<SalesDto2> sales, List<PayinPayout> payout_payin)
        {
            return sales.JoinPayInPayOut(payout_payin)
                             .GroupBy(x => x.AgentId)
                             .Select(x => new GroupedPayinPayout
                             (
                                 x.Key,
                                 x.Sum(x => x.DailySales),
                                 x.Sum(x => x.WinAmount),
                                 x.GetSalesDetails()
                             ));
        }

        public static IEnumerable<AgentReportDto> GetAgentReport(this List<SalesDto2> sales, Dictionary<string?, string?> agents, List<PayinPayout> payout_payin)
        {
            return sales.Group(payout_payin)
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
                                return new AgentReportDto
                                {
                                    AgentId = x.AgentId,
                                    Name = agents.TryGetValue(x.AgentId, out string? agent) ? agent : "",
                                    Sales = x.DailySales,
                                    Wins = x.WinAmount,
                                    Payin = payinAmount,
                                    Payout = payoutAmount,
                                    Balance = x.DailySales - x.WinAmount - amount,
                                    Details = x.Details.TransformDetails(),
                                };
                            });
        }
    }
}
