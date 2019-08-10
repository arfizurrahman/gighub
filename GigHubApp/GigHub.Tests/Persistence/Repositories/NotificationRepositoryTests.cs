using FluentAssertions;
using GigHub.Tests.Extensions;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;
using GigHubApp.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private NotificationsRepository _repository;
        private Mock<DbSet<Notification>> _mockNotifications;
        private Mock<DbSet<UserNotification>> _mockUserNotifications;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockNotifications = new Mock<DbSet<Notification>>();
            _mockUserNotifications = new Mock<DbSet<UserNotification>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Notifications).Returns(_mockNotifications.Object);
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockUserNotifications.Object);

            _repository = new NotificationsRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetNewNotificationsWithArtist_NotificationForADifferentUser_ShouldNotBeReturned()
        {

            var notification = Notification.GigCanceled(new Gig());
            var user = new ApplicationUser() { };

            var userNotification = new UserNotification(user, notification) { };

            _mockUserNotifications.SetSource(new[] { userNotification });

            var userNotifications = _repository.GetNewNotificationsWithArtist("2");
            userNotifications.Should().BeEmpty();
        }

        [TestMethod]
        public void GetNewNotificationsWithArtist_GetNotificationsThatAreRead_ShouldNotBeReturned()
        {

            var notification = Notification.GigCanceled(new Gig());
            var user = new ApplicationUser() { };

            var userNotification = new UserNotification(user, notification) { };
            userNotification.Read();

            _mockUserNotifications.SetSource(new[] { userNotification });

            var userNotifications = _repository.GetNewNotificationsWithArtist("2");
            userNotifications.Should().BeEmpty();
        }
    }
}
