using GigHubApp.Models;

namespace GigHubApp.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
    }
}