using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string userId);
    }
}