using GigHubApp.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        IQueryable<Gig> GetUpcomingGigs();
        Gig GetGig(int gigTd);
        void Add(Gig gig);
    }
}