using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetNewNotificationsWithArtist(string userId);
        IEnumerable<UserNotification> MarkAsRead(string userId);
    }
}