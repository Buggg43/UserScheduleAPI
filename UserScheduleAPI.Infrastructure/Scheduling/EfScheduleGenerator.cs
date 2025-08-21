using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserScheduleAPI.API.Services;
using UserScheduleAPI.Application.DTOs;
using UserScheduleAPI.Application.Scheduling;
using UserScheduleAPI.Application.Scheduling.Services;
using UserScheduleAPI.Application.Services;
using UserScheduleAPI.Domain.Entities;
using UserScheduleAPI.Infrastructure.Persistence;
using static UserScheduleAPI.Application.Scheduling.Services.SlotBuilder;

namespace UserScheduleAPI.Infrastructure.Scheduling
{
    public class EfScheduleGenerator : IScheduleGenerator
    {
        private readonly SlotBuilder _slotBuilder;
        private readonly AppDbContext _context;
        private readonly RestrictionFilter _restrictionFilter;

        public EfScheduleGenerator(AppDbContext context, SlotBuilder slotBuilder, RestrictionFilter restrictionFilter)
        {
            _context = context;
            _slotBuilder = slotBuilder; 
            _restrictionFilter = restrictionFilter;
        }
        public async Task<GeneratedScheduleDto> Generate(GenerateScheduleRequestDto request)
        {
            var start = request.StartDate;
            var end = request.EndDate;

            var shifts = await _context.Shifts
                .Include(s => s.User)
                    .ThenInclude(u => u.SpecialTags)
                .Include(s => s.Restrictions)
                .Include(s => s.Visits)
                .AsNoTracking()
                .Where(s => s.Date >= start && s.Date <= end)
                .ToListAsync();

            var dto = new GeneratedScheduleDto();

            return dto;
        }
        private async Task<UserScheduleDto> GenerateVisitsForShift(Shift shift, Guid userId)
        {
            var shiftStart = shift.Date + shift.StartTime;
            var shiftEnd = shift.Date + shift.EndTime;

            var slots = _slotBuilder.BuildSlots(shiftStart, shiftEnd, 15);
            /*
            if (!restriction.IsNullOrEmpty())
            var restriction = shift.Restrictions;
            {
                var ranges = new List<TimeRange>();

                foreach (var i in restriction)
                {
                    var range = new TimeRange();
                    range.Start = shift.Date + i.StartTime;
                    range.End = shift.Date + i.EndTime;
                    range.Reason = i.Reason;
                    ranges.Add(range);
                }
                var marked = _restrictionFilter.MarkRestrictedSlots(slots, ranges);
            }*/
            var ranges = (shift.Restrictions ?? Enumerable.Empty<ShiftRestriction>())
                .Select(r => new TimeRange { Start = shift.Date + r.StartTime, End = shift.Date + r.EndTime, Reason = r.Reason })
                .ToList();

            var marked = await _restrictionFilter.MarkRestrictedSlots(slots, ranges);
            var free = marked.Where(x => x.Type == SlotType.Available).ToList();

            var user = await _context.Users.Include(x => x.SpecialTags)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null) return null;


            var userTagIds = new HashSet<int>(user.SpecialTags.Select(x => x.SpecialInfoId));

            var patients = await _context.Patient
                .Include(p => p.RequiredTags)
                .AsNoTracking()
                .Where(p => (p.RequiredTags ?? new List<PatientSpecialInfo>()).All(r => userTagIds.Contains(r.SpecialInfoId)))
                .ToListAsync();

            var visits = new List<VisitDto>();
            foreach (var patient in patients)
            {
                var reservation = free.FirstOrDefault(x => x.Type == SlotType.Available);
                if (reservation is null) continue;
                visits.Add(new VisitDto
                {
                    FullName = patient.FirstName + " " + patient.LastName,
                    Address = patient.Address,
                    Age = patient.Age,
                    Date = reservation.StartTime,
                    StartTime = reservation.StartTime.TimeOfDay,
                    EndTime = reservation.EndTime.TimeOfDay,
                    Tags = patient.RequiredTags,
                    Notes = patient.Notes + ". Reason: " + reservation.Reason,
                });
                reservation.Type = SlotType.Reserved;
            }
            var schedule = new UserScheduleDto 
            {
                UserId = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                Visits = visits
            };

            return schedule;
        }
    }
}
