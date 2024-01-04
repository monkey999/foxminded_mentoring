namespace A_Domain.Repo_interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepo Groups { get; }
        ICourseRepo Courses { get; }
        IStudentRepo Students { get; }
        ITeacherRepo Teachers { get; }
        ITutorRepo Tutors { get; }
        ITutorGroupRepo TutorGroups { get; }
        ITeacherCourseRepo TeacherCourses { get; }

        Task SaveAsync();
        void Save();
    }
}
