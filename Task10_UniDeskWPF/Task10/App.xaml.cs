using A_Domain.Repo_interfaces;
using B_DataAccess;
using B_DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Task10.State.Navigators;
using Task10.ViewModels;
using Task10.ViewModels.Factories.AbstractFactories;
using Task10.ViewModels.Factories.ViewModelFactories;

namespace Task10
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddDbContext<UniDeskDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<IGroupRepo, GroupRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ITutorRepo, TutorRepo>();
            services.AddScoped<ITeacherRepo, TeacherRepo>();
            services.AddScoped<ITutorGroupRepo, TutorGroupRepo>();
            services.AddScoped<ITeacherCourseRepo, TeacherCourseRepo>();

            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CoursesViewModel>, CoursesViewModelFactory>();
            services.AddSingleton<IViewModelFactory<GroupsViewModel>, GroupsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<StudentsViewModel>, StudentsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<TeachersViewModel>, TeachersViewModelFactory>();
            services.AddSingleton<IRootViewModelFactory, RootViewModelAbstractFactory>();

            services.AddScoped<CreateGroupViewModel>();
            services.AddScoped<CreateTeacherViewModel>();
            services.AddScoped<CreateStudentViewModel>();

            services.AddScoped<UpdateStudentViewModel>();
            services.AddScoped<UpdateTeacherViewModel>();
            services.AddScoped<UpdateGroupViewModel>();

            services.AddScoped<DeleteStudentViewModel>();
            services.AddScoped<DeleteGroupViewModel>();
            services.AddScoped<DeleteTeacherViewModel>();

            services.AddScoped<MainViewModel>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            var serviceProvider = services.BuildServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }
    }
}
