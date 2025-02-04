using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using AMS.Shared.Enums;
using Microsoft.EntityFrameworkCore;
//using Z.EntityFramework.Plus;

namespace AMS.Server.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        public AccountTransactionService(ApplicationDbContext _appDbContext,
            IAuthService authService,
            INotificationService notificationService,
            IWebHostEnvironment evn)
        {
            appDbContext = _appDbContext;
            _authService = authService;
            _notificationService = notificationService;
            _evn = evn;
        }

        private readonly ApplicationDbContext appDbContext;
        private readonly IAuthService _authService;
        private readonly INotificationService _notificationService;
        private readonly IWebHostEnvironment _evn;

        public async Task<Shared.IResult> AddAccountTransaction(AddTransactionDto transactionDto)
        {
            var journalEntryRule = new JournalEntryRules(transactionDto.Amount, transactionDto.AccountType, transactionDto.Operation);
            var transaction = new AccountTransaction
            {
                 AccountId = transactionDto.AccountId,
                 Debit = journalEntryRule.Debit,
                 Credit = journalEntryRule.Credit,
                 Amount = journalEntryRule.Amount,
                 Description = transactionDto.Description
            };
            appDbContext.AccountTransactions.Add(transaction);
            var result = await appDbContext.SaveChangesAsync();
            if (result > 0)
                return new Result(true, "Transaction saved successfully.");
            return new Result(false, "Operation failled.");
        }
        public async Task<AccountTransactionDto> AddAdministrativeTransaction(AccountTransaction adminTransactions)
        {
            adminTransactions.Debit = adminTransactions.Amount < 0 ? adminTransactions.Amount : 0;
            adminTransactions.Credit = adminTransactions.Amount > 0 ? adminTransactions.Amount : 0;

            var result = appDbContext.AccountTransactions.Add(adminTransactions);
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetAdministrativeTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<AccountTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if (result != null)
            {
                appDbContext.AccountTransactions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return await GetAdministrativeTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetAdmininistrativeTransactions(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);
            var result = await (from t in appDbContext.AccountTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                //join sa in appDbContext.Accounts on t.SecondaryAccountId equals sa.AccountId into gj
                                //from x in gj.DefaultIfEmpty()
                                where //t.TransactionType == "Administrative"
                                 (t.TransactionDate >= startDate.Date && t.TransactionDate <= endDate.Date)

                                select new AccountTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    SourceAccount = a.AccountName,
                                    //SecondaryAccountId = t.SecondaryAccountId,
                                    //DestinationAccount = (x == null ? String.Empty : x.AccountName),
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    Credit = t.Credit,
                                    Debit = t.Debit,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).ToListAsync();
            return result;
        }

        public async Task<AccountTransactionDto> UpdateAdministrativeTrasaction(AccountTransaction adminTransactions)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == adminTransactions.Id);
            if (result != null)
            {
                result.Debit = adminTransactions.Amount < 0 ? adminTransactions.Amount : 0;
                result.Credit = adminTransactions.Amount > 0 ? adminTransactions.Amount : 0;
                result.Amount = adminTransactions.Amount;
                result.Description = adminTransactions.Description;
                result.AccountId = adminTransactions.AccountId;
                //result.SecondaryAccountId = adminTransactions.SecondaryAccountId;
                result.TransactionDate = adminTransactions.TransactionDate;

                await appDbContext.SaveChangesAsync();
                return await GetAdministrativeTransactionById(result.Id);
            }
            return null;
        }

       
        public async Task<AccountTransactionDto> GetAdministrativeTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.AccountTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                //join sa in appDbContext.Accounts on t.SecondaryAccountId equals sa.AccountId into gj
                                //from x in gj.DefaultIfEmpty()
                                where t.Id == transactionID

                                select new AccountTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    SourceAccount = a.AccountName,
                                    //SecondaryAccountId = t.SecondaryAccountId,
                                   // DestinationAccount = (x == null ? String.Empty : x.AccountName),
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    Credit = t.Credit,
                                    Debit = t.Debit,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).FirstOrDefaultAsync();

            return result;
        }
        public async Task<AccountTransaction> GetTransaction(string transactionID)
        {
            return await appDbContext.AccountTransactions.FirstOrDefaultAsync(t => t.Id == transactionID);
        }

        public async Task<AccountTransactionDto> Transfer(TransferDto transferDto)
        {
            var result = appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = transferDto.SourceAccountId, Amount = -transferDto.Amount, Credit = 0, Debit = transferDto.Amount, Description = transferDto.Description });
             appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = transferDto.DestinationAccountId, Amount = transferDto.Amount, Credit = transferDto.Amount, Debit = 0, Description = transferDto.Description });
             appDbContext.Transfers.Add(new Transfer
             {
                 Amount = transferDto.Amount,
                 Description = transferDto.Description,
                 DestinationAccountId = transferDto.DestinationAccountId,
                 SourceAccountId = transferDto.SourceAccountId
             });
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetAdministrativeTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<IEnumerable<TransferDto>> TransferReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var transfers = await appDbContext.Transfers.Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate).ToListAsync();
            var accounts = await appDbContext.Accounts.Select(x=>new { x.AccountName, x.AccountId}).ToDictionaryAsync(x=>x.AccountId,y=>y.AccountName);
            return transfers.Select(x=> new TransferDto {
                Amount = x.Amount, 
                Description= x.Description,
                DestinationAccountId = x.DestinationAccountId, 
                DestinationAccount = accounts[x.DestinationAccountId],
                SourceAccountId = x.SourceAccountId,
                SourceAccount = accounts[x.SourceAccountId],
            });
        }

        public async Task<AccountTransactionDto> Payout(AddPayoutDto addPayoutDto)
        {
            var absoluteAmount = Math.Abs(addPayoutDto.Amount);
            string phoneno = "";
            var agent = await appDbContext.Agents.FirstOrDefaultAsync(x => x.AgentId == addPayoutDto.AgentId);
            
                
            appDbContext.Payouts.Add(new Payout
            {
                Amount = addPayoutDto.Type == "Payout" ? -absoluteAmount : absoluteAmount,
                PayoutAmount = addPayoutDto.Type == "Payout" ? absoluteAmount : 0,
                PayinAmount = addPayoutDto.Type == "Payin" ? absoluteAmount : 0,
                Description = addPayoutDto.Description,
                DestinationAccountId = addPayoutDto.DestinationAccountId,
                SourceAccountId = addPayoutDto.SourceAccountId,
                AgentId = addPayoutDto.AgentId,
                //GameId = addPayoutDto.GameId,
                Type = addPayoutDto.Type,
                EntryDate = addPayoutDto.EntryDate.Value,
                StaffId = _authService.GetStaffID(),
                LocationId = _authService.GetLocationID(),
                TreatedBy = addPayoutDto.TreatedBy,
                ApprovedBy = addPayoutDto.ApprovedBy,
                ReceiverPhone = addPayoutDto.ReceiverPhone,               
                SalesId = addPayoutDto.SalesId,
                AreaOfOperations = addPayoutDto.AreaOfOperations,
                ChequeNo = addPayoutDto.ChequeNo,
                ReceivedBy = addPayoutDto.ReceivedBy,
                ReceivedFrom = addPayoutDto.ReceivedFrom,

                FilePath = addPayoutDto.FilePath,
                
                //DrawDate = addPayoutDto.DrawDate.Value
            });
            await appDbContext.SaveChangesAsync();
            //if (agent != null)
            //{
            //    string msg = "";
            //    // msg = $"Hello {agent.Name}, an amount of GHC {addPayoutDto.Amount} has been received as payin as at {addPayoutDto.EntryDate.Value.ToShortDateString()}";
            //    if(addPayoutDto.Type=="Payin")
            //    {
            //        msg = $"Hello {agent.Name}, a PAY-IN  cash of GHC {addPayoutDto.Amount} has been received on {addPayoutDto.EntryDate.Value.ToShortDateString()} Thanks";
            //    }
            //    else
            //    {
            //        msg = $"Hello {agent.Name}, a PAY-OUT cash of GHC {addPayoutDto.Amount} has been paid on {addPayoutDto.EntryDate.Value.ToShortDateString()} Thanks";
            //    }
                    
            //    phoneno = agent.Phone;
            //    if (!string.IsNullOrEmpty(phoneno))
            //        await _notificationService.SendSMS(msg, phoneno);
            //}

                return new AccountTransactionDto();
        }

        public async Task<Result> AddAgentExpense(AddAgentExpenseDto addExpenseDto)
        {

            appDbContext.AgentExpenses.Add(new AgentExpense
            {
                EntryDate = addExpenseDto.EntryDate.Value,
                AgentId = addExpenseDto.AgentId,
                Date = addExpenseDto.Date.Value,
                Description = addExpenseDto.Description,
                Amount = addExpenseDto.Amount,
                SalesId = addExpenseDto.SalesId,
            });
            if(await appDbContext.SaveChangesAsync() > 0)
            {
                return new Result(true, "Saved Successfully");
            }

            return new Result(false, "Error Occured While Saving!");
        }

        public async Task<Result> EditAgentExpense(AgentExpenseDto editExpenseDto)
        {
            var expense = appDbContext.AgentExpenses.FirstOrDefault(x => x.Id == editExpenseDto.Id);
            if(expense != null)
            {
                expense.EntryDate = editExpenseDto.EntryDate.Value;
                expense.Date = editExpenseDto.Date.Value;
                expense.Description = editExpenseDto.Description;
                expense.Amount = editExpenseDto.Amount;
            }

            if (await appDbContext.SaveChangesAsync() > 0)
            {
                return new Result(true, "Saved Successfully");
            }

            return new Result(false, "Error Occured While Saving!");
        }
        public async Task<IEnumerable<AgentExpenseDto>> AgentExpenses(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var result = await (from e in appDbContext.AgentExpenses.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate)
                                join ag in appDbContext.Agents on e.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()

                                select new AgentExpenseDto
                                {
                                    Id = e.Id,
                                    Amount = e.Amount,
                                    EntryDate = e.EntryDate,
                                    Description = e.Description,
                                    AgentId = e.AgentId,
                                    Agent = agt == null ? string.Empty : agt.Name,
                                    StaffId = e.StaffId,
                                    SalesId= e.SalesId,
                                    Date   = e.Date
                                }).ToListAsync();
            return result;
        }

        public async Task<Result> EditPayout(Payout editPayoutDto)
        {
            var result = await appDbContext.Payouts.FirstOrDefaultAsync(x=> x.Id == editPayoutDto.Id);
            var absoluteAmount = Math.Abs(editPayoutDto.Amount);
            if(result != null)
            {
                result.Amount = editPayoutDto.Type == "Payout" ? -absoluteAmount : absoluteAmount;
                result.PayoutAmount = editPayoutDto.Type == "Payout" ? absoluteAmount : 0;
                result.PayinAmount = editPayoutDto.Type == "Payin" ? absoluteAmount : 0;
                result.Description = editPayoutDto.Description;
                result.ChequeNo = editPayoutDto.ChequeNo;
                //result.DestinationAccountId = editPayoutDto.DestinationAccountId;
                //result.SourceAccountId = editPayoutDto.SourceAccountId;
                result.AgentId = editPayoutDto.AgentId;
                result.StaffId = _authService.GetStaffID();
                result.Type = editPayoutDto.Type;
                result.EntryDate = editPayoutDto.EntryDate;
                result.TreatedBy = editPayoutDto.TreatedBy;
                result.ApprovedBy = editPayoutDto.ApprovedBy;
                result.ReceivedBy = editPayoutDto.ReceivedBy;
                result.ReceivedFrom = editPayoutDto.ReceivedFrom;
                result.ReceiverPhone = editPayoutDto.ReceiverPhone;

                await appDbContext.SaveChangesAsync();
                return new Result (true, "Update Successful");
            }

            return new Result(false, "An error occured. Unable to update");
        }

        public async Task<Result<AccountTransactionDto>> ApprovePayout(string payoutId)
        {
            var result = await appDbContext.Payouts.FirstOrDefaultAsync(x => x.Id == payoutId);
            if (result != null)
            {
                result.Approved = true;
                result.ApprovedBy = _authService.GetStaffID();
                await appDbContext.SaveChangesAsync();
                return new Result<AccountTransactionDto> { IsSucessful = true, Message = "Transaction Approved", Value = await GetAdministrativeTransactionById(result.Id) };
            }
            return new Result<AccountTransactionDto> { IsSucessful = false, Message = "Operation Failed", Value = new AccountTransactionDto() };
        }

        public async Task<IEnumerable<PayoutDto>> PayoutReport(DateRange period)
        {
            //var transfers = await appDbContext.Payouts.ToListAsync();
            //var accounts = await appDbContext.Accounts.Select(x => new { x.AccountName, x.AccountId }).ToDictionaryAsync(x => x.AccountId, y => y.AccountName);
            //var agents = await appDbContext.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x => x.AgentId, y => y.Name);
            //var games = await appDbContext.Games.Select(x => new { x.Name, x.Id }).ToDictionaryAsync(x => x.Id, y => y.Name);
            //return transfers.Select(x => new PayoutDto
            //{
            //    Amount = x.Amount,
            //    Description = x.Description,
            //    AgentId = x.AgentId,
            //    Agent = agents[x.AgentId] == null ? string.Empty : agents[x.AgentId],
            //    GameId = x.GameId,
            //    GameName = games[x.Id] == null ? string.Empty : games[x.Id],
            //    DestinationAccountId = x.DestinationAccountId,
            //    DestinationAccount = accounts[x.DestinationAccountId],
            //    SourceAccountId = x.SourceAccountId,
            //    SourceAccount = accounts[x.SourceAccountId]
            //});
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var result = await (from p in appDbContext.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate<= endDate && x.Type == "Payout")
                                join ag in appDbContext.Agents on p.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()
                                //join gm in appDbContext.Games on p.GameId equals gm.Id into gmac
                                //from gme in gmac.DefaultIfEmpty()

                                select new PayoutDto
                                {
                                    Id = p.Id,
                                    Amount = p.Amount,
                                    EntryDate = p.EntryDate,                                    
                                    Description = p.Description,
                                    AgentId = p.AgentId,
                                    Approved = p.Approved,
                                    ChequeNo = p.ChequeNo,
                                    Agent = agt == null ? string.Empty : agt.Name,
                                    StaffId = p.StaffId,
                                    LocationId = p.LocationId, 
                                    AreaOfOperations = p.AreaOfOperations,
                                    TreatedBy = p.TreatedBy,
                                    ApprovedBy = p.ApprovedBy,
                                    ReceivedBy = p.ReceivedBy,
                                    ReceivedFrom = p.ReceivedFrom,
                                    ReceiverPhone = p.ReceiverPhone,
                                    FileName = p.FilePath
                                    //GameId = p.GameId,
                                    //GameName = gme.Name
                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PayoutDto>> PayinReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var result = await (from p in appDbContext.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate && x.Type == "Payin")
                                join ag in appDbContext.Agents on p.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()
                                //join gm in appDbContext.Games on p.GameId equals gm.Id into gmac
                                //from gme in gmac.DefaultIfEmpty()

                                select new PayoutDto
                                {
                                    Id = p.Id,
                                    Amount = p.Amount,
                                    EntryDate = p.EntryDate,
                                    //DrawDate = p.DrawDate,
                                    Description = p.Description,
                                    AgentId = p.AgentId,
                                    Approved = p.Approved == null? false: p.Approved,
                                    Agent = agt == null ? string.Empty : agt.Name,
                                    StaffId = p.StaffId,
                                    LocationId = p.LocationId,
                                    ApprovedBy = p.ApprovedBy,
                                    TreatedBy = p.TreatedBy,
                                    ChequeNo = p.ChequeNo,
                                    AreaOfOperations = p.AreaOfOperations,
                                    ReceivedBy = p.ReceivedBy,
                                    ReceivedFrom = p.ReceivedFrom,
                                    ReceiverPhone = p.ReceiverPhone,
                                    FileName = p.FilePath
                                    //GameId = p.GameId,
                                    //GameName = gme.Name
                                }).ToListAsync();
            return result;
        }

        
    }
}
