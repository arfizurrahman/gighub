using GigHubApp.Core;
using GigHubApp.Core.Models;
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
        public FollowingRepository Followings { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}