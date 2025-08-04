using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserScheduleAPI.API.DTOs;
using UserScheduleAPI.Domain.Entities;
using UserScheduleAPI.Infrastructure.Persistence;

namespace UserScheduleAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ShiftController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShifts()
        {
            var shifts = await _context.Shifts.ToListAsync();
            return Ok(shifts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShift(int id)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(shift);
        }
        [HttpGet("{shiftId}/restrictions")]
        public async Task<IActionResult> GetAllShiftRestrictions(int shiftId)
        {
            if (shiftId < 0)
                return BadRequest();

            var shiftRestrictions = await _context.ShiftRestrictions.Where(x => x.ShiftId == shiftId).ToListAsync();
            if(!shiftRestrictions.Any())
                return NotFound();

            return Ok(shiftRestrictions);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShift([FromBody] CreateShiftDto dto)
        {
            var newShift = new Shift
            {
                UserId = dto.UserId,// guid should be from claim latter
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Notes = dto.Notes,
            };

            await _context.Shifts.AddAsync(newShift);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShift), new { id = newShift.Id }, newShift);

        }
        [HttpPost("{shiftId}/restrictions")]
        public async Task<IActionResult> AddShiftRestrictions(int shiftId, [FromBody]CreateShiftRestrictionDto dto)
        {
            if (shiftId <= 0)
                return BadRequest();

            var shiftRestriction = new ShiftRestriction
            {
                ShiftId = shiftId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Reason = dto.Reason
            };
            _context.ShiftRestrictions.Add(shiftRestriction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAllShiftRestrictions),
                new { shiftId = shiftId },
                shiftRestriction
            );

        }
        [HttpPut("{shiftId}/restrictions/{id}")]
        public async Task<IActionResult> UpdateShiftRestrictions(int id, int shiftId, [FromBody] UpdateShiftRestrictionDto dto)
        {
            if (id <= 0)
                return BadRequest();

            var shiftRestriction = _context.ShiftRestrictions.FirstOrDefault(x => x.Id == id && x.ShiftId == shiftId);
            if (shiftRestriction == null)
                return NotFound();

            if(dto.StartTime.HasValue)
                shiftRestriction.StartTime = dto.StartTime.Value;

            if (dto.EndTime.HasValue && shiftRestriction.StartTime < dto.EndTime.Value)
                shiftRestriction.EndTime = dto.EndTime.Value;

            if(!dto.Reason.IsNullOrEmpty())
                shiftRestriction.Reason = dto.Reason;

            _context.ShiftRestrictions.Update(shiftRestriction);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShift([FromBody]UpdateShiftDto dto, int id)
        {
            if (id <= 0)
                return BadRequest();

            var shift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
            if (shift == null)
                return NotFound("Not found shift with" + id);

            if(dto.StartTime.HasValue)
                shift.StartTime = dto.StartTime.Value;
            if (dto.EndTime.HasValue)
                shift.EndTime = dto.EndTime.Value;
            if(dto.Date.HasValue)
                shift.Date = dto.Date.Value;
            if (!dto.Notes.IsNullOrEmpty())
                shift.Notes = dto.Notes;
            
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            if (id <= 0)
                return BadRequest();
            
            var deleteShift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
            if(deleteShift == null)
                return NotFound();
            
            _context.Shifts.Remove(deleteShift);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{shiftId}/restrictions/{id}")]
        public async Task<IActionResult> restrictionToDelete(int shiftId, int id)
        {
            if (shiftId == null || shiftId == 0)
                return BadRequest();

            var deleteShift = await _context.ShiftRestrictions.FirstOrDefaultAsync(x => x.Id == id && x.ShiftId == shiftId);
            if (deleteShift == null)
                return NotFound();

            _context.ShiftRestrictions.Remove(deleteShift);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
