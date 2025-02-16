using AMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public sealed record JournalEntryRules
    {
        public const string Increase = "Increase";
        public const string Decrease = "Decrease";
        public JournalEntryRules(decimal amount, string accountType,string operetion)
        {
            var _amount = Math.Abs(amount);
            switch (accountType)
            {
                case AccountTypes.Asset:
                    Debit = operetion == Increase ? _amount : 0;
                    Credit = operetion == Decrease ? _amount : 0;
                    Amount = operetion == Increase ? -_amount : _amount; 
                    break;

                case AccountTypes.Liability:
                    Debit = operetion == Decrease ? _amount : 0;
                    Credit = operetion == Increase ? _amount : 0;
                    Amount = operetion == Increase ? _amount : -_amount;
                    break;

                case AccountTypes.Revenue:
                    Debit = operetion == Decrease ? _amount : 0;
                    Credit = operetion == Increase ? _amount : 0;
                    Amount = operetion == Increase ? _amount : -_amount;
                    break;

                case AccountTypes.Equity:
                    Debit = operetion == Decrease ? _amount : 0;
                    Credit = operetion == Increase ? _amount : 0;
                    Amount = operetion == Increase ? _amount : -_amount;
                    break;

                case AccountTypes.Expense:
                    Debit = operetion == Increase ? _amount : 0;
                    Credit = operetion == Decrease ? _amount : 0;
                    Amount = operetion == Increase ? -_amount : _amount;
                    break;
            }
        }
        public decimal Amount; 
        public decimal Debit;
        public decimal Credit;
    }
}
