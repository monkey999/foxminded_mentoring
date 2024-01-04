using System.Windows.Input;
using Task10.ViewModels;

namespace Task10.State.Navigators
{
    public enum ViewType
    {
        Home,
        Courses,
        Students,
        Teachers,
        Groups,
        CreateGroup,
        CreateStudent,
        CreateTeacher,
        UpdateGroup,
        DeleteGroup,
        UpdateStudent,
        DeleteStudent,
        UpdateTeacher,
        DeleteTeacher
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
