using UserScheduleAPI.API.DTOs;

namespace UserScheduleAPI.API.Services
{
    public class SlotBuilder
    {
        public enum SlotType
        {
            Available,
            Reserved
        }
        public IEnumerable<SlotDto> BuildSlots(DateTime start, DateTime end, int visitLengthMinutes)
        {
            if(visitLengthMinutes<15)
                return Enumerable.Empty<SlotDto>();
            if(start >= end)
                return Enumerable.Empty<SlotDto>();

            var slots = new List<SlotDto>();
            DateTime startVisit = start;
            DateTime endVisit = start.AddMinutes(visitLengthMinutes);
            while(endVisit <= end)
            {
                var slot = new SlotDto();

                slot.StartTime= startVisit;
                slot.EndTime= endVisit;

                slots.Add(slot);

                startVisit = endVisit;
                endVisit = startVisit.AddMinutes(visitLengthMinutes);
            }
            return slots;
        }
    }
}
