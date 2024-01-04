using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.Models;

namespace Task10.Specifications
{
    public class GroupsWithCourseSpecification : ISpecification<Group>
    {
        private readonly int _courseId;

        public GroupsWithCourseSpecification(int courseId)
        {
            _courseId = courseId;
        }

        public bool IsSatisfiedBy(Group group)
        {
            return group.CourseId == _courseId;
        }
    }
}
