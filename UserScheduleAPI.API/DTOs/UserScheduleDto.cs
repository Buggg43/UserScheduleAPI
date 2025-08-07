using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.API.DTOs
{
    public class UserScheduleDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public List<VisitDto> Visits {get ; set;}
    }
}
