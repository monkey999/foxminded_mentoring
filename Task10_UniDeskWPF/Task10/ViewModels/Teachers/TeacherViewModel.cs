using Task10.Models;

namespace Task10.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;

        public int? Id => _teacher.Id;
        public string? FullName => _teacher.FullName;
        public string? FirstName => _teacher.FirstName;
        public string? LastName => _teacher.LastName;

        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher;
        }
    }
}
