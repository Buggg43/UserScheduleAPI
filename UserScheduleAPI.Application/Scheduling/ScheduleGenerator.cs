using Microsoft.EntityFrameworkCore;
using UserScheduleAPI.Application.DTOs;
using UserScheduleAPI;

namespace UserScheduleAPI.Application.Scheduling
{
    public interface IScheduleGenerator
    {
        Task<GeneratedScheduleDto> Generate(GenerateScheduleRequestDto request);
    }
    public class ScheduleGenerator : IScheduleGenerator
    {
        private readonly AppDbContext _context;
        public ScheduleGenerator(AppDbContext context)
        {
            _context = context;
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
                .Where(s => s.Date >= start && s.Date <= end)
                .ToListAsync();

            var dto = new GeneratedScheduleDto();

            return dto;
        }
    }
}
