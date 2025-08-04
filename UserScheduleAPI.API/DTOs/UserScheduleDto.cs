using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.API.DTOs
{
    public class UserScheduleDto
    {
        public string FullName { get; set; }
        public List<ShiftAssigmentDto> ShiftList {get ; set;}
    }
}
