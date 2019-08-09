using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;

namespace GigHubApp.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            List<Following> followees = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Include(f => f.Followee)
                .ToList();

            return View(followees);
        }
    }
}