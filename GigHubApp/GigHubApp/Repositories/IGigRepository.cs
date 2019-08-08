using GigHubApp.Models;
using System.Collections.Generic;

namespace GigHubApp.Repositories
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