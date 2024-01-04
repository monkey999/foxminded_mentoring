using Domain;

namespace C_Logic.DTO_Contracts.Responses
{
    public class StudentGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
