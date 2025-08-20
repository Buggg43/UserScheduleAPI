using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.Application.DTOs
{
    public class VisitDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? Age {get; set;}
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> Tags { get; set; }
        public string? Notes { get; set; }
    }
}
