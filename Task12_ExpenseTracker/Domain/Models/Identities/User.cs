namespace Domain.Models.Identities
{
    public class User
    {
        public User()
        {
        }

        public User(Guid id, string firtName, string lastName)
        {
            Id = id;
            FirtName = firtName;
            LastName = lastName;
        }

        public Guid Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirtName} {LastName}";
    }
}
