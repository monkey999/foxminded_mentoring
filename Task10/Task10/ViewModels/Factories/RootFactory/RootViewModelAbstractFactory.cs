using System;
using Task10.State.Navigators;
using Task10.ViewModels.Factories.ViewModelFactories;

namespace Task10.ViewModels.Factories.AbstractFactories
{
    public class RootViewModelAbstractFactory : IRootViewModelFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<StudentsViewModel> _studentsViewModelFactory;
        private readonly IViewModelFactory<CoursesViewModel> _coursesViewModelFactory;
        private readonly IViewModelFactory<TeachersViewModel> _teachersViewModelFactory;
        private readonly IViewModelFactory<GroupsViewModel> _groupsViewModelFactory;

        public RootViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<StudentsViewModel> studentsViewModelFactory, IViewModelFactory<CoursesViewModel> coursesViewModelFactory,
            IViewModelFactory<TeachersViewModel> teachersViewModelFactory, IViewModelFactory<GroupsViewModel> groupsViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _studentsViewModelFactory = studentsViewModelFactory;
            _coursesViewModelFactory = coursesViewModelFactory;
            _teachersViewModelFactory = teachersViewModelFactory;
            _groupsViewModelFactory = groupsViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Students:
                    return _studentsViewModelFactory.CreateViewModel();
                case ViewType.Teachers:
                    return _teachersViewModelFactory.CreateViewModel();
                case ViewType.Groups:
                    return _groupsViewModelFactory.CreateViewModel();
                case ViewType.Courses:
                    return _coursesViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", $"{viewType}");
            }
        }
    }
}
