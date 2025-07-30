using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserScheduleAPI.Infrastructure.Persistence;

namespace UserScheduleAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet] // potem na Admin
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
