using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserScheduleAPI.API.DTOs;
using UserScheduleAPI.Domain.Entities;
using UserScheduleAPI.Infrastructure.Persistence;

namespace UserScheduleAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PatientController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet("{patientId}/special-info")]
        public async Task<IActionResult> PatientInfo(Guid patientId)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == patientId);
            if (patient == null)
                return NotFound();

            var tagDtos = patient.RequiredTags
                .Select(x => new PatientSpecialInfoDto
                {
                    Name = x.SpecialInfo.Name,
                    Description = x.SpecialInfo.Description
                }).ToList();

            return Ok(tagDtos);

        }
        [HttpPost("{patientId}/special-info")]
        public async Task<IActionResult> AddSpecialInfo(Guid patientId, [FromBody]AssignSpecialInfoDto dto)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == patientId);
            if(patient == null)
                return NotFound();

            var specialInfo = await _context.SpecialInfos.FirstOrDefaultAsync(x => x.Id == dto.SpecialInfoId);
            if(specialInfo == null)
                return BadRequest();

            var patientSpecialInfo = new PatientSpecialInfo
            {
                PatientId = patient.Id,
                SpecialInfoId = specialInfo.Id
            };


            await _context.PatientSpecialInfo.AddAsync(patientSpecialInfo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{patientId}/special-info/{infoId}")]
        public async Task<IActionResult> DeleteSpecialInfo(Guid patientId,Guid infoId)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == patientId);
            if (patient == null)
                return NotFound();

            var specialInfo = await _context.PatientSpecialInfo.FirstOrDefaultAsync(x => x.Id == infoId);
            if (specialInfo == null)
                return BadRequest();

            _context.PatientSpecialInfo.Remove(specialInfo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
