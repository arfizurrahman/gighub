using AutoMapper;
using GigHubApp.Core;
using GigHubApp.Core.Dtos;
using GigHubApp.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHubApp.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetNewNotificationsWithArtist(userId);



            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }



        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.MarkAsRead(userId).ToList();

            notifications.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();
        }


    }
}
