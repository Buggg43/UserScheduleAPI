using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.API.DTOs
{
    public class ShiftAssigmentDto
    {
        public int ShiftId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date {  get; set; }
        public List<SpecialInfo> Tags { get; set; }
        public string? Notes { get; set; }
    }
}
