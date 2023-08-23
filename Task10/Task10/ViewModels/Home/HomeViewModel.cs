namespace Task10.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CoursesViewModel CoursesViewModel { get; set; }

        public HomeViewModel(CoursesViewModel coursesViewModel)
        {
            CoursesViewModel = coursesViewModel;
        }
    }
}
