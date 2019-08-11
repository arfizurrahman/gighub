using Moq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace GigHub.IntegrationTests.Extensions
{
    public static class ControllerExtensions
    {
        public static void MockCurrentUser(this Controller controller, string userId, string userName)
        {
            var identity = new GenericIdentity(userName);

            identity.AddClaim(
                new Claim("http://shemas.xmlsoap.org/ws/2005/05/indentity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://shemas.xmlsoap.org/ws/2005/05/indentity/claims/nameidentifier", userId));

            var principal = new GenericPrincipal(identity, null);

            controller.ControllerContext = Mock.Of<ControllerContext>(ctx =>
                ctx.HttpContext == Mock.Of<HttpContextBase>(http => http.User == principal));

        }
    }
}
