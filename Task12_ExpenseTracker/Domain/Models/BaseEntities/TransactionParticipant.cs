namespace Domain.Models.BaseEntities
{
    public class TransactionParticipant
    {
        public TransactionParticipant()
        {
            TransactionsFrom = new HashSet<Transaction>();
            TransactionsTo = new HashSet<Transaction>();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<Transaction> TransactionsFrom { get; set; }
        public ICollection<Transaction> TransactionsTo { get; set; }
    }
}
