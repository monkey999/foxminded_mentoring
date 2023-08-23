using A_Domain.Models;
using System.Text.RegularExpressions;

namespace Task10.Models
{
    public class Teacher
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Tutor? Tutor { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
    }
}
