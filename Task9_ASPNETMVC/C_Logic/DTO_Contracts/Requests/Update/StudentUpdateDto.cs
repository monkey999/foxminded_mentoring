using Domain;

namespace C_Logic.DTO_Contracts.Requests.Update
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
