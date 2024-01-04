using Task10.Models;

namespace Task10.ViewModels
{
    public class GroupViewModel : ViewModelBase
    {
        private readonly Group _group;

        public int Id => _group.Id;
        public string? Name => _group.Name;
        public int? CourseId => _group.CourseId;

        public GroupViewModel(Group group)
        {
            _group = group;
        }
    }
}
