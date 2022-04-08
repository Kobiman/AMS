namespace AMS.Shared.Dto
{
    public class AccountConfig
    {
        public string? AccountType { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public IEnumerable<Subtypes>? Subtypes { get; set; }

        public static string GetAccountCode(Account account,int startingPoint)
        {
            IEnumerable<AccountConfig> AccountConfigs = AccountList();
            var config = AccountConfigs.FirstOrDefault(c => c.AccountType == account.Type);
            return $"{startingPoint + config.Min}{config.Subtypes.FirstOrDefault(x => x.Name == account.SubType)?.Id}";
        }

        private static IEnumerable<AccountConfig> AccountList()
        {
            return new List<AccountConfig>
           {
            new AccountConfig
            {
                AccountType = "Asset",
                Min = 101, Max = 199,
                Subtypes = new List<Subtypes>
                {
                    new Subtypes("1","Current Assets"),
                    new Subtypes("2","Inventory"),
                    new Subtypes("3","Fixed Assets"),
                    new Subtypes("4","Long-term Assets")
                }
            },
            new AccountConfig
            {
                AccountType = "Liability",
                Min = 201, Max = 299,
                Subtypes = new List<Subtypes>
                {
                    new Subtypes("1","Current Liabilities"),
                    new Subtypes("2","Long - term Liabilities"),
                }
            },
            new AccountConfig
            {
                AccountType = "Equity",
                Min = 301, Max = 399,
                Subtypes = new List<Subtypes>
                {
                    new Subtypes("1","Paid -in Capital"),
                    new Subtypes("2","Treasury Stock"),
                    new Subtypes("3","Retained Earnings"),
                }
            },
            new AccountConfig
            {
                AccountType = "Revenue",
                Min = 401, Max =499,
                Subtypes = new List<Subtypes>
                {
                }
            },
            new AccountConfig
            {
                AccountType = "Expense",
                Min = 501, Max = 599,
                Subtypes = new List<Subtypes>
                {
                    new Subtypes("1","Cost of Goods Sold"),
                    new Subtypes("2","Selling Expenses"),
                    new Subtypes("3","General or Administrative Expenses"),
                    new Subtypes("4","Depreciation Expense"),
                    new Subtypes("4","Research and Development"),
                    new Subtypes("4","Non - Operating Section")
                }
            },
           };
        }
    }
   public record Subtypes(string Id, string Name);
}
