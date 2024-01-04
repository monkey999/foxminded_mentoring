using Task10.Models;

namespace Task10.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private readonly Student _student;

        public int Id => _student.Id;
        public string? FullName => _student.FullName;
        public string? FirstName => _student.FirstName;
        public string? LastName => _student.LastName;
        public int? GroupId => _student.GroupId;

        public StudentViewModel(Student student)
        {
            _student = student;
        }
    }
}
