using static UserScheduleAPI.API.Services.SlotBuilder;

namespace UserScheduleAPI.API.DTOs
{
    public class SlotDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SlotType Type { get; set; } = SlotType.Available;
        public string? Reason { get; set; }
    }
}
