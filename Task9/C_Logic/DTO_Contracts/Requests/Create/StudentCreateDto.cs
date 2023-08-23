using Domain;

namespace C_Logic.DTO_Contracts.Requests
{
    public class StudentCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
