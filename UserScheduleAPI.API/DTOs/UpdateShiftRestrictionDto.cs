using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.API.DTOs
{
    public class UpdateShiftRestrictionDto
    {
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Reason { get; set; }
    }

}
