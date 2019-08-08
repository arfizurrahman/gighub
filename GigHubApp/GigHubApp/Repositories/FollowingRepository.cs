using GigHubApp.Models;
using System.Linq;

namespace GigHubApp.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }
    }
}