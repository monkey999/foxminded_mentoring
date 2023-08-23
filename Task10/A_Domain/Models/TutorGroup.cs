using Task10.Models;

namespace A_Domain.Models
{
    public class TutorGroup
    {
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
