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
        public AccountTransactionService(ApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        private readonly ApplicationDbContext appDbContext;

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

        public async Task<IEnumerable<AccountTransactionDto>> GetAdmininistrativeTransactions(string period)
        {
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;
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

        public async Task<IEnumerable<TransferDto>> TransferReport(string period)//Should be by period
        {
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;

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
            var originalPayout = await appDbContext.Sales.FirstOrDefaultAsync(x=>x.EntryDate.Value.Date == addPayoutDto.EntryDate.Value.Date &&
                                                                                   x.AgentId == addPayoutDto.AgentId);
            if (originalPayout != null)
            {
                //var result = appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = addPayoutDto.SourceAccountId, Amount = -addPayoutDto.Amount, Debit = addPayoutDto.Amount, Credit = 0, Description = "PAYOUT" });
                //appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = addPayoutDto.DestinationAccountId, Amount = addPayoutDto.Amount, Debit = 0, Credit = addPayoutDto.Amount, Description = "PAYOUT" });
                //appDbContext.Transfers.Add(new Transfer { Amount = addPayoutDto.Amount, SourceAccountId = addPayoutDto.SourceAccountId, DestinationAccountId = addPayoutDto.DestinationAccountId, Description = "PAYOUT" });
                var absoluteAmount = Math.Abs(addPayoutDto.Amount);
                appDbContext.Payouts.Add(new Payout
                {
                    Amount = addPayoutDto.Type == "Payout" ? -absoluteAmount : absoluteAmount,
                    PayoutAmount = addPayoutDto.Type == "Payout" ? absoluteAmount : 0,
                    PayinAmount = addPayoutDto.Type == "Payin" ? absoluteAmount : 0,
                    Description = addPayoutDto.Description,
                    DestinationAccountId = addPayoutDto.DestinationAccountId,
                    SourceAccountId = addPayoutDto.SourceAccountId,
                    AgentId = addPayoutDto.AgentId,
                    GameId = addPayoutDto.GameId,
                    Type = addPayoutDto.Type,
                    EntryDate = addPayoutDto.EntryDate.Value,
                    DrawDate = addPayoutDto.DrawDate.Value
                });
                await appDbContext.SaveChangesAsync();
            }
            
            return new AccountTransactionDto();
        }

        public async Task<IEnumerable<PayoutDto>> PayoutReport(string period)
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
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;

            var result = await (from p in appDbContext.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate<= endDate && x.Type == "Payout")
                                join ag in appDbContext.Agents on p.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()
                                join gm in appDbContext.Games on p.GameId equals gm.Id into gmac
                                from gme in gmac.DefaultIfEmpty()

                                select new PayoutDto
                                {
                                    Amount = p.Amount,
                                    EntryDate = p.EntryDate,
                                    Description = p.Description,
                                    AgentId = p.AgentId,
                                    Agent = agt == null ? string.Empty : agt.Name,
                                    GameId = p.GameId,
                                    GameName = gme.Name
                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PayoutDto>> PayinReport(string period)
        {
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;

            var result = await (from p in appDbContext.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate && x.Type == "Payin")
                                join ag in appDbContext.Agents on p.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()
                                join gm in appDbContext.Games on p.GameId equals gm.Id into gmac
                                from gme in gmac.DefaultIfEmpty()

                                select new PayoutDto
                                {
                                    Amount = p.Amount,
                                    EntryDate = p.EntryDate,
                                    DrawDate = p.DrawDate,
                                    Description = p.Description,
                                    AgentId = p.AgentId,
                                    Agent = agt == null ? string.Empty : agt.Name,
                                    GameId = p.GameId,
                                    GameName = gme.Name
                                }).ToListAsync();
            return result;
        }
    }
}
