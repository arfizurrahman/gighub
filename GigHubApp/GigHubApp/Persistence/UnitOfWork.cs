using GigHubApp.Core;
using GigHubApp.Core.Repositories;
using GigHubApp.Persistence.Repositories;

namespace GigHubApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository Gigs { get; set; }
        public IAttendanceRepository Attendances { get; set; }
        public IGenreRepository Genres { get; set; }
        public IFollowingRepository Followings { get; set; }
        public INotificationsRepository Notifications { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
            Notifications = new NotificationsRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}