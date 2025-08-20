using UserScheduleAPI.API.DTOs;
using static UserScheduleAPI.API.Services.SlotBuilder;

namespace UserScheduleAPI.API.Services
{
    public class RestrictionFilter
    {
        public IEnumerable<SlotDto> MarkRestrictedSlots(IEnumerable<SlotDto> slots, IEnumerable<TimeRange> restrictions)
        {
            if (slots == null || restrictions == null)
                return null;

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
