using System.Text.RegularExpressions;
using Task10.Models;

namespace Task10.ViewModels
{
    public class CourseViewModel : ViewModelBase
    {
        private readonly Course _course;

        public int? Id => _course.Id;
        public string? Name => _course.Name;
        public string? Description => _course.Description;

        public CourseViewModel(Course course)
        {
            _course = course;
        }
    }
}
