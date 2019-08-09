using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        Gig GetGig(int gigTd);
        void Add(Gig gig);
    }
}