using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<Following> Followings { get; set; }

    }
}