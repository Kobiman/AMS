using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using AMS.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Principal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using System.Data.Entity;

namespace AMS.Server.Services
{
    public class SalesService : ISalesService
    {
        public SalesService(ApplicationDbContext _appDbContext,IAuthService authService)
        {
            appDbContext = _appDbContext;
            _authService = authService;
        }

        private readonly ApplicationDbContext appDbContext;
        private readonly IAuthService _authService;

        public async Task<SalesDto> AddSales(SalesDto sales)
        {
            var result = await appDbContext.Sales.AddAsync(
                new Sales { 
                    AgentId = sales.AgentId,
                    AccountId = sales.AccountId,
                    DailySales = sales.DailySales, 
                    Description = sales.Description,
                    //WinAmount = sales.WinAmount, 
                    GameId = sales.GameId,
                    ReceiptNumber = sales.ReceiptNumber,
                    EntryDate = sales.EntryDate,
                    DrawDate = sales.DrawDate,
                    NumberOfBooks = sales.NumberOfBooks,
                    LocationId = _authService.GetLocationID(),
                    AreaOfOperations = sales.AreaOfOperations,
                    SalesStaffId = _authService.GetStaffID(),
                    SalesTreatedBy = sales.SalesTreatedBy,
                    SalesApprovedBy = sales.SalesApprovedBy,
                    //WinsStaffId = string.Empty,
                    GrossSales = sales.GrossSales,
                    SalesCommission = sales.SalesCommission,
                }
                );

            var cachAccount = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountName.ToUpper() == "Cash-Checking Account".ToUpper());

            var Increase = new JournalEntryRules(sales.DailySales, AccountTypes.Asset, JournalEntryRules.Increase);
            await appDbContext.AccountTransactions.AddAsync(
                new AccountTransaction
                {
                    Amount = Increase.Amount,
                    Credit = Increase.Credit,
                    Debit = Increase.Debit,
                    Description = sales.Description,
                    AccountId = cachAccount?.AccountId
                });

            await appDbContext.AccountTransactions.AddAsync(
                new AccountTransaction
                {
                    AccountId = sales.AccountId,
                    Amount = sales.DailySales,
                    Credit = sales.DailySales,
                    Description = sales.Description
                }
                );

            if (await appDbContext.SaveChangesAsync() > 0)
            {
                return await GetTransactionById(result.Entity.SalesId); 
            }
                
            return null;
        }

        //public Task UpdateSales(SalesDto sales)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<SalesDto> DeleteAgentsTransaction(string accountTransactionId)
        {
            var result = await appDbContext.Sales.FirstOrDefaultAsync(i => i.SalesId == accountTransactionId);
            if (result != null)
            {
                appDbContext.Sales.Remove(result);
                appDbContext.AccountTransactions.Add(
                new AccountTransaction
                {
                    AccountId = result.AccountId,
                    Amount = -result.DailySales,
                    Debit = result.DailySales,
                    Description = "Transaction removed"
                }
                );
                await appDbContext.SaveChangesAsync();
                //await UpdateAccount(-result.PayInAmount, result.AccountId);
                return await GetTransactionById(result.SalesId);
            }
            return null;
        }

        public async Task<IEnumerable<SalesDto>> GetSalesReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var users = await appDbContext.Users.ToDictionaryAsync(x => x.Id, x => x.Email);

            var query = (from t in appDbContext.Sales
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                select new SalesDto
                                {
                                    AgentId = t.AgentId,
                                    AccountId = t.AccountId,
                                    AgentName = x == null ? string.Empty : x.Name,
                                    SalesId = t.SalesId,
                                    DailySales = t.DailySales,
                                    Description = t.Description,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
                                    GameId = t.GameId,
                                    SalesStaffId = t.SalesStaffId,
                                    SalesTreatedBy = t.SalesTreatedBy,
                                    Approved = t.Approved == null ? false : t.Approved,
                                    SalesApprovedBy = t.SalesApprovedBy,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                    NumberOfBooks = t.NumberOfBooks,
                                    AreaOfOperations = t.AreaOfOperations,
                                    SalesCommission = t.SalesCommission,
                                    SalesCommissionValue = ((t.SalesCommission /100)*t.GrossSales),
                                    GrossSales = t.GrossSales,
                                    LocationId = (int)t.LocationId,
                                });

            var result = _authService.GetUserRole() == Shared.Enums.UserRoles.Admin ?  
                         query.Where(t => t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date && t.Description != "balance b/f") :
                         query.Where(t => t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date && t.Description != "balance b/f" && t.LocationId == _authService.GetLocationID());

            return await result.OrderBy(x => x.EntryDate).ToListAsync();
        }

        public async Task<IEnumerable<SalesDto>> GetWinsReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);
            var users = await appDbContext.Users.ToDictionaryAsync(x => x.Id, x => x.Email);
            var query =  (from t in appDbContext.Sales
                                    join w in appDbContext.Wins on t.SalesId equals w.SalesId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                select new SalesDto
                                {
                                    AgentId = t.AgentId,
                                    AccountId = t.AccountId,
                                    AgentName = x == null ? string.Empty : x.Name,
                                    AgentPhoneNumber = x == null ? string.Empty : x.Phone,
                                    SalesId = t.SalesId,
                                    WinAmount = w.WinAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - w.WinAmount,
                                    Description = t.Description,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
                                    GameId = t.GameId,
                                    SalesStaffId = t.SalesStaffId,
                                    WinsStaffId = w.StaffId,
                                    SalesTreatedBy = t.SalesTreatedBy,
                                    Approved = t.Approved == null ? false : t.Approved,
                                    Sheet = w.Sheet,
                                    NumberOfSheets = t.NumberOfBooks,
                                    SalesApprovedBy = t.SalesApprovedBy,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                    NumberOfBooks = t.NumberOfBooks,
                                    AreaOfOperations = t.AreaOfOperations,
                                    SalesCommission = t.SalesCommission,
                                    SalesCommissionValue = ((t.SalesCommission / 100) * t.GrossSales),
                                    GrossSales = t.GrossSales,
                                });

            var result = _authService.GetUserRole() == Shared.Enums.UserRoles.Admin ? 
                         query.Where(t => t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date && t.Description != "balance b/f") :
                         query.Where(t => t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date && t.Description != "balance b/f" && t.LocationId == _authService.GetLocationID());

            return await result.OrderBy(x => x.EntryDate).ToListAsync();
        }

        public async Task<IEnumerable<SalesDto>> GetOpenSalesWinsStortage()
        {
            var bfAccount = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountName == "BALANCE B/F");
            var query = (from t in appDbContext.Sales
                               join w in appDbContext.Wins on t.SalesId equals w.SalesId
                               join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                               from x in gj.DefaultIfEmpty()
                               join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                               from gme in _gme.DefaultIfEmpty()
                               select new SalesDto
                               {
                                   AgentId = t.AgentId,
                                   AccountId = t.AccountId,
                                   AgentName = x == null ? string.Empty : x.Name,
                                   SalesId = t.SalesId,
                                   WinAmount = w.WinAmount,
                                   DailySales = t.DailySales,
                                   OutstandingBalance = t.DailySales - w.WinAmount,
                                   Description = t.Description,
                                   EntryDate = t.EntryDate,
                                   DrawDate = t.DrawDate,
                                   GameId = t.GameId,
                                   SalesStaffId = t.SalesStaffId,
                                   Approved = t.Approved,
                                   GameName = gme == null ? string.Empty : gme.Name,
                                   SalesCommission = t.SalesCommission,
                                   GrossSales = t.GrossSales,
                               });
            var result = _authService.GetUserRole() == Shared.Enums.UserRoles.Admin ?
                         query.Where(t => t.AccountId == bfAccount.AccountId) :
                         query.Where(t => t.AccountId == bfAccount.AccountId && t.LocationId == _authService.GetLocationID());

            return await result.OrderBy(x => x.DrawDate).ToListAsync();
        }


        public async Task<SalesDto> AddWins(Wins wins)
        {
            //result.WinAmount = wins.WinAmount;
            //result.Sheet = wins.Sheet;
            //result.NumberOfSheets = wins.NumberOfSheets;
            //result.Description = wins.Description;
            //result.AccountId = wins.AccountId;
            //result.AgentId = wins.AgentId;
            //result.DailySales = wins.DailySales;
            //result.EntryDate = DateTime.Today;
            ////result.GameId = agentTransaction.GameId;
            //result.AccountId = wins.AccountId;
            //result.WinsStaffId = _authService.GetStaffID();
            //result.WinsTreatedBy = agentTransaction.WinsTreatedBy;
            //result.WinsApprovedBy = agentTransaction.WinsApprovedBy;
            //result.LocationId = _authService.GetLocationID() == "" ? 0 : Convert.ToInt16(_authService.GetLocationID());
            wins.StaffId = _authService.GetStaffID();
            appDbContext.Wins.Add(wins);
            await appDbContext.SaveChangesAsync();
                return await GetTransactionById(wins.SalesId);
        }
        public async Task<SalesDto> ApproveSales(string SalesId)
        {
            var sales = await appDbContext.Sales.FirstOrDefaultAsync(x => x.SalesId == SalesId);
            if(sales != null)
            {
                sales.Approved = true;
                sales.SalesApprovedBy = _authService.GetStaffID();

                var cachAccount = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountName.ToUpper() == "Cash-Checking Account".ToUpper());

                var Increase = new JournalEntryRules(sales.DailySales, AccountTypes.Asset, JournalEntryRules.Increase);
                await appDbContext.AccountTransactions.AddAsync(
                    new AccountTransaction
                    {
                        Amount = Increase.Amount,
                        Credit = Increase.Credit,
                        Debit = Increase.Debit,
                        Description = sales.Description,
                        AccountId = cachAccount?.AccountId
                    });

                await appDbContext.AccountTransactions.AddAsync(
                    new AccountTransaction
                    {
                        AccountId = sales.AccountId,
                        Amount = sales.DailySales,
                        Credit = sales.DailySales,
                        Description = sales.Description
                    }
                    );
                if (await appDbContext.SaveChangesAsync() > 0)
                {
                    return await GetTransactionById(SalesId);
                }
                return null;
            }
            return new SalesDto();
        }

        public async Task<IEnumerable<Sales>> GetTransactionsByAccountId(string accountId)
        {
            List<Sales> transactions = await appDbContext.Sales.Where(t => t.AgentId == accountId).ToListAsync();
            return transactions;
        }

        private IEnumerable<SalesDto> CreateTransaction(List<Account> accounts)
        {
            foreach (var a in accounts)
            {
                foreach (var t in a.Transactions)
                {
                    yield return new SalesDto
                    {
                        AccountId = a.AccountId,
                        AccountName = a.AccountName,
                        SalesId = t.Id,
                        WinAmount = t.Amount,
                        Description = t.Description,
                        EntryDate = t.TransactionDate,
                    };
                }
            }
        }

        public async Task<SalesDto> GetTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.Sales
                                //join w in appDbContext.Wins on t.SalesId equals w.SalesId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where t.SalesId == transactionID 

                                select new SalesDto
                                {
                                    //AccountId = a.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AgentName = (x == null? String.Empty : x.Name),
                                    SalesId = t.SalesId,
                                    //WinAmount = w.WinAmount,
                                    DailySales = t.DailySales,
                                    //OutstandingBalance = t.DailySales - w.WinAmount,
                                    Description = t.Description,
                                    SalesStaffId = t.SalesStaffId,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
                                    GameId = t.GameId,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                    SalesCommission = t.SalesCommission,
                                    GrossSales = t.GrossSales,
                                }).FirstOrDefaultAsync();

            return result;
        }

       

        public async Task<Sales> GetTransaction(string transactionID)
        {
            return await appDbContext.Sales.FirstOrDefaultAsync(t => t.SalesId == transactionID);
        }

        public async Task<IEnumerable<SalesDto>> GetTransactionsCashInCashOut(string inOut, DateRange period)
        {
            var transactions = await GetSalesReport(period);
            if (inOut == "CashIn")
                return transactions.Where(x => x.WinAmount > 0);
            else
                return transactions.Where(x => x.WinAmount < 0);
        }

        public async Task UpdateAccount(decimal amount, string accountId)
        {
            var accToUpdate = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
            if (accToUpdate != null)
            {
                accToUpdate.Balance += amount;
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
