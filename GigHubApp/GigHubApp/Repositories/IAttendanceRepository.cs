using System.Collections.Generic;
using GigHubApp.Models;

namespace GigHubApp.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string userId);
    }
}