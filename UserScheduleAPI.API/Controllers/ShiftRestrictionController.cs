using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserScheduleAPI.Infrastructure.Persistence;

namespace UserScheduleAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftRestrictionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ShiftRestrictionController(AppDbContext context)
        {
            _context = context;
        }

    }
}
