using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.API.DTOs
{
    public class CreateShiftDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Notes { get; set; }
        public Guid UserId { get; set; }
    }

}
