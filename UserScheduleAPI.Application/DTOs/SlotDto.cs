using static UserScheduleAPI.Application.Scheduling.Services.SlotBuilder;

namespace UserScheduleAPI.Application.DTOs
{
    public class SlotDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SlotType Type { get; set; } = SlotType.Available;
        public string? Reason { get; set; }
    }
}
