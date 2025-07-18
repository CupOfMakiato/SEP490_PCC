using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Attendance;

namespace Server.Application.Interfaces
{
    public interface IAttendanceService
    {
        public Task<Result<List<ViewAttendanceDTO>>> GetAttendancesByConsultantIdAsync(Guid consultantId);
        public Task<Result<ViewAttendanceDTO>> CreateAttendance(AddAttendanceDTO attendance);
    }
}
