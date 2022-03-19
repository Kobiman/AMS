using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AMS.Server.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        public AccountTransactionService(ApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        private readonly ApplicationDbContext appDbContext;

        //public async Task<Shared.IResult> AddAccountTransaction(AdminTransaction adminTransactions)
        //{
        //    adminTransactions.Debit = adminTransactions.Amount < 0 ? adminTransactions.Amount : 0;
        //    adminTransactions.Credit = adminTransactions.Amount > 0 ? adminTransactions.Amount : 0;
        //    appDbContext.AdminTransactions.Add(adminTransactions);
        //    var result = await appDbContext.SaveChangesAsync();
        //    if (result > 0)
        //        return new Result(true, "Transaction saved successfully.");
        //    return new Result(false, "Operation failled.");
        //}
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
            DateTime date = DateTime.Now.Date;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (period == "This Week")
            {
                startDate = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Sunday);
                endDate = startDate.AddDays(6);
            }

            else if (period == "This Month")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                endDate = startDate.AddDays(daysInMonth - 1);
            }
            else
            {
                startDate = date.Date;
                endDate = date.AddHours(24);
            }
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

        public async Task<AccountTransactionDto> Transfer(Transfer transferDto)
        {
            //transferDto.Debit = transferDto.Amount < 0 ? transferDto.Amount : 0;
            //transferDto.Credit = transferDto.Amount > 0 ? transferDto.Amount : 0;

            var result = appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = transferDto.SourceAccountId, Amount = -transferDto.Amount, Debit = transferDto.Amount, Description = "TRANSFER" });
             appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = transferDto.DestinationAccountId, Amount = transferDto.Amount, Credit = transferDto.Amount, Description = "TRANSFER" });
             appDbContext.Transfers.Add(transferDto);
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetAdministrativeTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<IEnumerable<TransferDto>> TransferReport(string period)//Should be by period
        {
            DateTime date = DateTime.Now.Date;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (period == "This Week")
            {
                startDate = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Sunday);
                endDate = startDate.AddDays(7);
            }

            else if (period == "This Month")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                endDate = startDate.AddDays(daysInMonth - 1);
            }
            else
            {
                startDate = date.Date;
                endDate = date.AddHours(24);
            }
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

        public async Task<AccountTransactionDto> Payout(Payout payout)
        {
            //transferDto.Debit = transferDto.Amount < 0 ? transferDto.Amount : 0;
            //transferDto.Credit = transferDto.Amount > 0 ? transferDto.Amount : 0;

            var result = appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = payout.SourceAccountId, Amount = -payout.Amount, Debit = payout.Amount, Description = "PAYOUT" });
            appDbContext.AccountTransactions.Add(new AccountTransaction { AccountId = payout.DestinationAccountId, Amount = payout.Amount, Credit = payout.Amount, Description = "PAYOUT" });
            appDbContext.Payouts.Add(payout);
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetAdministrativeTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<IEnumerable<PayoutDto>> PayoutReport(string period)//Should be by period
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
            DateTime date = DateTime.Now.Date;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (period == "This Week")
            {
                startDate = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Sunday);
                endDate = startDate.AddDays(6);
            }

            else if (period == "This Month")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                endDate = startDate.AddDays(daysInMonth - 1);
            }
            else
            {
                startDate = date.Date;
                endDate = date.AddHours(24);
            }
            var result = await (from p in appDbContext.Payouts.Where(x => x.TransactionDate >= startDate && x.TransactionDate<= endDate)
                                join acc in appDbContext.Accounts on p.SourceAccountId equals acc.AccountId into sourceac
                                from a in sourceac.DefaultIfEmpty()
                                join dacc in appDbContext.Accounts on p.DestinationAccountId equals dacc.AccountId into desacc
                                from d in desacc.DefaultIfEmpty()
                                join ag in appDbContext.Agents on p.AgentId equals ag.AgentId into agac
                                from agt in agac.DefaultIfEmpty()
                                join gm in appDbContext.Games on p.GameId equals gm.Id into gmac
                                from gme in gmac.DefaultIfEmpty()

                                select new PayoutDto
                                {
                                    Amount = p.Amount,
                                    Description = p.Description,
                                    AgentId = p.AgentId,
                                    Agent = agt==null?string.Empty: agt.Name,
                                    GameId = p.GameId,
                                    GameName = gme.Name,
                                    DestinationAccountId = p.DestinationAccountId,
                                    DestinationAccount = d == null? string.Empty : d.AccountName,
                                    SourceAccountId = p.SourceAccountId,
                                    SourceAccount = a == null? string.Empty : a.AccountName
                                }).ToListAsync();
            return result;
        }
    }
}
