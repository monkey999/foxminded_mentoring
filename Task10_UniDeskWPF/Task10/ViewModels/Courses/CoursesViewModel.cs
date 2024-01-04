using A_Domain.Repo_interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Task10.Commands;
using Task10.Models;
using Task10.Specifications;
using Task10.State.Navigators;

namespace Task10.ViewModels
{
    public class CoursesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CourseViewModel> _courses;
        public IEnumerable<CourseViewModel> Courses => _courses;
        private readonly IUnitOfWork _unitOfWork;
        public readonly INavigator _navigator;

        public ICommand NavigateToGroupsView { get; }

        public CoursesViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            _navigator = navigator;
            _courses = new ObservableCollection<CourseViewModel>();
            _unitOfWork = unitOfWork;

            NavigateToGroupsView = new RelayCommand(param =>
            {
                if (param is CourseViewModel course)
                {
                    var specification = new GroupsWithCourseSpecification((int)course.Id);
                    var groupsViewModel = GroupsViewModel.LoadGroupsViewModel(_unitOfWork, _navigator, specification);
                    _navigator.CurrentViewModel = groupsViewModel;
                }
            });
        }

        public static CoursesViewModel LoadCoursesViewModel(IUnitOfWork unitOfWork, INavigator navigator)
        {
            CoursesViewModel coursesViewModel = new(unitOfWork, navigator);
            coursesViewModel.LoadCoursesFromDb();

            return coursesViewModel;
        }

        private void LoadCoursesFromDb()
        {
            var coursesFromDb = _unitOfWork.Courses.GetAll().ToList();

            foreach (var course in coursesFromDb)
            {
                var courseViewModel = new CourseViewModel(course);
                _courses.Add(courseViewModel);
            }
        }
    }
}
