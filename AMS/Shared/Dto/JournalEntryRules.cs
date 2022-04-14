using AMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public record JournalEntryRules
    {
        public const string Increase = "Increase";
        public const string Decrease = "Decrease";
        public JournalEntryRules(decimal amount, string accountType,string operetion)
        {
            Amount = amount;

            switch (accountType)
            {
                case AccountTypes.Asset:
                    Debit = operetion == Increase ? amount : 0;
                    Credit = operetion == Decrease ? amount : 0;
                    Amount = operetion == Increase ? -amount : amount; 
                    break;

                case AccountTypes.Liability:
                    Debit = operetion == Decrease ? amount : 0;
                    Credit = operetion == Increase ? amount : 0;
                    Amount = operetion == Increase ? amount : -amount;
                    break;

                case AccountTypes.Revenue:
                    Debit = operetion == Decrease ? amount : 0;
                    Credit = operetion == Increase ? amount : 0;
                    Amount = operetion == Increase ? amount : -amount;
                    break;

                case AccountTypes.Equity:
                    Debit = operetion == Decrease ? amount : 0;
                    Credit = operetion == Increase ? amount : 0;
                    Amount = operetion == Increase ? amount : -amount;
                    break;

                case AccountTypes.Expense:
                    Debit = operetion == Increase ? amount : 0;
                    Credit = operetion == Decrease ? amount : 0;
                    Amount = operetion == Increase ? -amount : amount;
                    break;
            }

        }
        public decimal Amount; 
        public decimal Debit;
        public decimal Credit;
    }
}
