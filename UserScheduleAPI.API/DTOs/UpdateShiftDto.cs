namespace UserScheduleAPI.API.DTOs
{
    public class UpdateShiftDto
    {
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Notes { get; set; }

    }

}
