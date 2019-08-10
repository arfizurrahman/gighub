using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;

namespace GigHub.Tests.Extensions
{
    public static class ApiControllerExtensions
    {
        public static void MockCurrentUser(this ApiController controller, string userId, string userName)
        {
            var identity = new GenericIdentity(userName);

            identity.AddClaim(
                new Claim("http://shemas.xmlsoap.org/ws/2005/05/indentity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://shemas.xmlsoap.org/ws/2005/05/indentity/claims/nameidentifier", userId));

            var principal = new GenericPrincipal(identity, null);

            controller.User = principal;

        }
    }
}
