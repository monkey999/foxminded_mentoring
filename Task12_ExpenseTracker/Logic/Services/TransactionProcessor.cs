using Domain.Enums;
using Domain.Models;
using Domain.RepoInterfaces;
using Logic.ServiceInterfaces;

namespace Logic.Services
{
    public class TransactionProcessor : ITransactionProcessor
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Transaction> ProcessTransaction(Transaction transaction)
        {
            switch (transaction.TransactionType)
            {
                case TransactionType.Income:
                    await ProcessIncomeTransaction(transaction);
                    break;
                case TransactionType.Expense:
                    await ProcessExpenseTransaction(transaction);
                    break;
                case TransactionType.IRepayLoan:
                    await ProcessRepayLoanTransaction(transaction);
                    break;
                // Add cases for other transaction types

                default:
                    // Handle unsupported transaction type
                    break;
            }

            await _unitOfWork.SaveAsync();

            return transaction;
        }

        private async Task ProcessIncomeTransaction(Transaction transaction)
        {
            // Update the category's balance
            // Update the account's balance

            // Optionally, handle special cases or validations for this type
        }

        private async Task ProcessExpenseTransaction(Transaction transaction)
        {
            // Update the category's balance
            // Update the account's balance

            // Optionally, handle special cases or validations for this type
        }

        private async Task ProcessRepayLoanTransaction(Transaction transaction)
        {
            // Update the relevant balances for loans

            // Optionally, handle special cases or validations for this type
        }


        // Add methods for other transaction types
    }
}
