using GigHubApp.Repositories;

namespace GigHubApp.Persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; set; }
        IAttendanceRepository Attendances { get; set; }
        IGenreRepository Genres { get; set; }
        FollowingRepository Followings { get; set; }
        void Complete();
    }
}