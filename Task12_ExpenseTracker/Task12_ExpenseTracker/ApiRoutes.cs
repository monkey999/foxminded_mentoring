namespace Task12_ExpenseTracker
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class CreditAccounts
        {
            public const string GetCreditAccounts = Base + "/creditAccounts";
            public const string GetCreditAccountByID = Base + "/creditAccounts/{Id}";
            public const string CreateCreditAccount = Base + "/creditAccounts";
            public const string DeleteCreditAccount = Base + "/creditAccounts/{Id}";
            public const string UpdateCreditAccount = Base + "/creditAccounts";
        }
        public static class Categories
        {
            public const string GetAllCategories = Base + "/categories";
            public const string GetCategoryByID = Base + "/categories/{Id}";
            public const string CreateCategory = Base + "/categories";
            public const string DeleteCategory = Base + "/categories/{Id}";
            public const string UpdateCategory = Base + "/categories";
        }
        public static class DebitAccounts
        {
            public const string CreateDebitAccount = Base + "/debitAccounts";
            public const string GetAllDebitAccounts = Base + "/debitAccounts";
            public const string GetDebitAccountByID = Base + "/debitAccounts/{Id}";
            public const string DeleteDebitAccount = Base + "/debitAccounts/{Id}";
            public const string UpdateDebitAccount = Base + "/debitAccounts";
        }
        public static class DebtAccounts
        {
            public const string GetAllDebtAccounts = Base + "/debtAccounts";
            public const string GetDebtAccountByID = Base + "/debtAccounts/{Id}";
            public const string CreateDebtAccount = Base + "/debtAccounts";
            public const string DeleteDebtAccount = Base + "/debtAccounts/{Id}";
            public const string UpdateDebtAccount = Base + "/debtAccounts";
        }
        public static class InvestAccounts
        {
            public const string GetAllInvestAccounts = Base + "/investAccounts";
            public const string GetInvestAccountByID = Base + "/investAccounts/{Id}";
            public const string CreateInvestAccount = Base + "/investAccounts";
            public const string DeleteInvestAccount = Base + "/investAccounts/{Id}";
            public const string UpdateInvestAccount = Base + "/investAccounts";
        }
        public static class Reports
        {
            public const string GetAllReports = Base + "/reports";
            public const string GetReportByID = Base + "/reports/{Id}";
            public const string CreateReport = Base + "/reports";
            public const string DeleteReport = Base + "/reports/{Id}";
            public const string UpdateReport = Base + "/reports";
        }
        public static class Transactions
        {
            public const string GetAllTransactions = Base + "/transactions";
            public const string GetTransactionByID = Base + "/transactions/{Id}";
            public const string CreateTransaction = Base + "/transactions";
            public const string DeleteTransaction = Base + "/transactions/{Id}";
            public const string UpdateTransaction = Base + "/transactions";
        }
    }
}
