﻿using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using AMS.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
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

        //public async Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction)
        //{
        //    accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
        //    accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
        //    appDbContext.AgentsTransactions.Add(accountTransaction);
        //    var result = await appDbContext.SaveChangesAsync();
        //    if (result > 0)
        //        return new Result(true, "Transaction saved successfully.");
        //    return new Result(false, "Operation failled.");
        //}
        public async Task<SalesDto> AddSales(SalesDto sales)
        {
            var result = await appDbContext.Sales.AddAsync(
                new Sales { 
                    AgentId = sales.AgentId,
                    AccountId = sales.AccountId,
                    DailySales = sales.DailySales, 
                    Description = sales.Description,
                    WinAmount = sales.WinAmount, 
                    GameId = sales.GameId,
                    ReceiptNumber = sales.ReceiptNumber,
                    EntryDate = sales.EntryDate,
                    DrawDate = sales.DrawDate,
                    NumberOfBooks = sales.NumberOfBooks,
                    LocationId =_authService.GetLocationID() == "" ? 0 :Convert.ToInt16(_authService.GetLocationID()),
                    AreaOfOperations = sales.AreaOfOperations,
                    SalesStaffId = _authService.GetStaffID(),
                    SalesTreatedBy = sales.SalesTreatedBy,
                    SalesApprovedBy = sales.SalesApprovedBy,
                }
                );

            if (await appDbContext.SaveChangesAsync() > 0)
            {
                return await GetTransactionById(result.Entity.Id); 
            }
                
            return null;
        }

        public async Task<SalesDto> DeleteAgentsTransaction(string accountTransactionId)
        {
            var result = await appDbContext.Sales.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
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
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<SalesDto>> GetAgentsTransaction(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var users = await appDbContext.Users.ToDictionaryAsync(x => x.Id, x => x.Email);

            var result = await (from t in appDbContext.Sales
                                    //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where
                                t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date

                                select new SalesDto
                                {
                                    //AccountId = t.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AccountId = t.AccountId,
                                    AgentName = x == null ? string.Empty : x.Name,
                                    Id = t.Id,
                                    WinAmount = t.WinAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.WinAmount,
                                    Description = t.Description,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
                                    GameId = t.GameId,
                                    SalesStaffId = t.SalesStaffId,
                                    WinsStaffId = t.WinsStaffId,
                                    SalesTreatedBy = t.SalesTreatedBy,
                                    Approved = t.Approved == null ? false : t.Approved,
                                    SalesApprovedBy = t.SalesApprovedBy,
                                    WinsApprovedBy = t.WinsApprovedBy,
                                    WinsTreatedBy = t.WinsApprovedBy,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                    NumberOfBooks = t.NumberOfBooks,
                                    AreaOfOperations = t.AreaOfOperations
                                }).OrderBy<SalesDto, DateTime?>(x => x.EntryDate)
                                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<SalesDto>> GetOpenSalesWinsStortage()
        {
            var bfAccount = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountName == "BALANCE B/F");
            var result = await(from t in appDbContext.Sales
                                   //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                               join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                               from x in gj.DefaultIfEmpty()
                               join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                               from gme in _gme.DefaultIfEmpty()
                               where
                               t.AccountId == bfAccount.AccountId

                               select new SalesDto
                               {
                                   //AccountId = t.AccountId,
                                   //AccountName = a.AccountName,
                                   AgentId = t.AgentId,
                                   AccountId = t.AccountId,
                                   AgentName = x == null ? string.Empty : x.Name,
                                   Id = t.Id,
                                   WinAmount = t.WinAmount,
                                   DailySales = t.DailySales,
                                   OutstandingBalance = t.DailySales - t.WinAmount,
                                   Description = t.Description,
                                   EntryDate = t.EntryDate,
                                   DrawDate = t.DrawDate,
                                   GameId = t.GameId,
                                   SalesStaffId = t.SalesStaffId,
                                   Approved = t.Approved,
                                   GameName = gme == null ? string.Empty : gme.Name,
                               }).OrderBy(x => x.EntryDate)
                                .ToListAsync();
            return result;
        }


        public async Task<SalesDto> UpdateAgentsTrasaction(Sales agentTransaction)
        {
            string preAccountId;
            decimal preAmount;
            var result = await appDbContext.Sales.FirstOrDefaultAsync(i => i.Id == agentTransaction.Id);
            if (result != null)
            {
                preAmount = result.WinAmount;
                result.WinAmount = agentTransaction.WinAmount;
                result.Description = agentTransaction.Description;
                result.AccountId = agentTransaction.AccountId;
                result.AgentId = agentTransaction.AgentId;
                result.DailySales = agentTransaction.DailySales;
                result.EntryDate = DateTime.Today;
                //result.GameId = agentTransaction.GameId;
                result.AccountId = agentTransaction.AccountId;
                result.WinsStaffId = _authService.GetStaffID();
                result.WinsTreatedBy = agentTransaction.WinsTreatedBy;
                result.WinsApprovedBy = agentTransaction.WinsApprovedBy;
                result.LocationId = _authService.GetLocationID() == "" ? 0 : Convert.ToInt16(_authService.GetLocationID());


                await appDbContext.SaveChangesAsync();
                return await GetTransactionById(result.Id);
            }
            return null;
        }
        public async Task<SalesDto> ApproveSales(string SalesId)
        {
            var sales = await appDbContext.Sales.FirstOrDefaultAsync(x => x.Id == SalesId);
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
                        Id = t.Id,
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
                                //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where t.Id == transactionID 

                                select new SalesDto
                                {
                                    //AccountId = a.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AgentName = (x == null? String.Empty : x.Name),
                                    Id = t.Id,
                                    WinAmount = t.WinAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.WinAmount,
                                    Description = t.Description,
                                    SalesStaffId = t.SalesStaffId,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
                                    GameId = t.GameId,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                }).FirstOrDefaultAsync();

            return result;
        }

       

        public async Task<Sales> GetTransaction(string transactionID)
        {
            return await appDbContext.Sales.FirstOrDefaultAsync(t => t.Id == transactionID);
        }

        public async Task<IEnumerable<SalesDto>> GetTransactionsCashInCashOut(string inOut, DateRange period)
        {
            var transactions = await GetAgentsTransaction(period);
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
