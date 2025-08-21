using Microsoft.AspNetCore.Mvc;
using UserScheduleAPI.Application.DTOs;
using UserScheduleAPI.Application.Scheduling;

namespace UserScheduleAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleGenerator _scheduleGenerator;
        public ScheduleController(IScheduleGenerator scheduleGenerator)
        {
            _scheduleGenerator = scheduleGenerator;
        }
        [HttpPost("generate")]
        public ActionResult<GeneratedScheduleDto> Generate([FromBody] GenerateScheduleRequestDto request)
        {
            var schedule = _scheduleGenerator.Generate(request);
            return Ok(schedule);
        }
    }
}
