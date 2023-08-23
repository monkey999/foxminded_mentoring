using Task10.Models;

namespace Task10.Specifications
{
    public class StudentsWithGroupSpecification : ISpecification<Student>
    {
        private readonly int _groupId;

        public StudentsWithGroupSpecification(int groupId)
        {
            _groupId = groupId;
        }

        public bool IsSatisfiedBy(Student student)
        {
            return student.GroupId == _groupId;
        }
    }
}
