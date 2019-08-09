using GigHubApp.Core.Models;
using System.Collections.Generic;

namespace GigHubApp.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<Following> GetFollowingsByFollower(string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}