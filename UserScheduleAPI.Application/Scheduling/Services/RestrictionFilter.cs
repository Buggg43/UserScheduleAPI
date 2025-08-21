using UserScheduleAPI.Application.DTOs;
using UserScheduleAPI.Application.Services;
using static UserScheduleAPI.Application.Scheduling.Services.SlotBuilder;

namespace UserScheduleAPI.API.Services
{
    public class RestrictionFilter
    {
        public async Task<IEnumerable<SlotDto>> MarkRestrictedSlots(IEnumerable<SlotDto> slots, IEnumerable<TimeRange> restrictions)
        {
            if (slots == null || restrictions == null)
                return slots;

            foreach(var slot in slots)
            {
                var restriction = restrictions.FirstOrDefault(x => x.Start < slot.EndTime && x.End > slot.StartTime);
                if (restrictions.Any(x => x.Start < slot.EndTime &&  x.End > slot.StartTime))
                {
                    slot.Type = SlotType.Reserved;
                    slot.Reason = restriction.Reason;
                }
            }
            return slots;
        }
    }
}
