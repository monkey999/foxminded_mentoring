using A_Domain.Models;

namespace Task10.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Group>? Groups { get; set; }
        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
    }
}
