namespace Task12_ExpenseTracker
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Categories
        {
            public const string GetAllCategories = Base + "/categories";
            public const string GetCategoryByID = Base + "/categories/{Id}";
            public const string CreateCategory = Base + "/categories";
            public const string DeleteCategory = Base + "/categories/{Id}";
            public const string UpdateCategory = Base + "/categories";
            public const string UpdatePatchCategory = Base + "/categories/{Id}";
        }
        public static class DebitAccounts
        {
            public const string CreateDebitAccount = Base + "/debitAccounts";
            public const string GetAllDebitAccounts = Base + "/debitAccounts";
            public const string GetDebitAccountByID = Base + "/debitAccounts/{Id}";
            public const string DeleteDebitAccount = Base + "/debitAccounts/{Id}";
            public const string UpdateDebitAccount = Base + "/debitAccounts";
            public const string UpdatePatchDebitAccount = Base + "/debitAccounts/{Id}";
        }
        public static class Reports
        {
            public const string GetDailyReport = Base + "/dailyReport";
            public const string GetDatePeriodReport = Base + "/datePeriodReport";
        }
        public static class Transactions
        {
            public const string GetAllTransactions = Base + "/transactions";
            public const string GetTransactionByID = Base + "/transactions/{Id}";
            public const string CreateTransaction = Base + "/transactions";
            public const string DeleteTransaction = Base + "/transactions/{Id}";
            public const string UpdateTransaction = Base + "/transactions";
            public const string UpdatePatchTransaction = Base + "/transactions/{Id}";
        }
    }
}
