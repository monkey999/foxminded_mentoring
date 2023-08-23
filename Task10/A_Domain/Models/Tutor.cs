using A_Domain.Models;

namespace Task10.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<TutorGroup>? TutorGroups { get; set; }
    }
}
