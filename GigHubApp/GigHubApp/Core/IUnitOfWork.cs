using GigHubApp.Core.Repositories;

namespace GigHubApp.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; set; }
        IAttendanceRepository Attendances { get; set; }
        IGenreRepository Genres { get; set; }
        IFollowingRepository Followings { get; set; }
        INotificationsRepository Notifications { get; set; }
        void Complete();
    }
}