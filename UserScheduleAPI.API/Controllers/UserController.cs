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
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}/special-info")]
        public async Task<IActionResult> GetUserSpecialInfo(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var userInfo = await _context.UserSpecialInfos.Where(x => x.UserId == id).ToListAsync();
            if (userInfo == null)
                return NotFound();


            var infoList = new List<SpecialInfoDto>();
            foreach (var i in userInfo)
            {
                var info = await _context.SpecialInfos.FindAsync(i.SpecialInfoId);
                var userSpecialInfo = new SpecialInfoDto {
                    Name = info.Name,
                    Description = info.Description
                };

                infoList.Add(userSpecialInfo);
            }

            return Ok(infoList);
        }
        [HttpPost("{id}/special-info")]
        public async Task<IActionResult> AddUserSpecialInfo(Guid id, [FromBody]AssignSpecialInfoDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            if (dto == null)
                return BadRequest();

            var newInfo = new UserSpecialInfo()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                User = user,
                SpecialInfoId = dto.SpecialInfoId,
            };
            await _context.UserSpecialInfos.AddAsync(newInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddUserSpecialInfo), new { id = newInfo.Id }, newInfo.SpecialInfo);
        }
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.LastName))
                return BadRequest("FirstName and LastName are required.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Age = dto.Age
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto dto, Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
            if (user == null)
                return NotFound();

            if(!string.IsNullOrEmpty(dto.FirstName))
            {
                user.FirstName = dto.FirstName;
            }
            if (!string.IsNullOrEmpty(dto.LastName))
            {
                user.LastName = dto.LastName;
            }
            if (dto.Address != null)
            {
                user.Address = dto.Address;
            }
            if (dto.Age.HasValue)
            {
                user.Age = dto.Age.Value;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}/special-info/{specialInfoId}")]
        public async Task<IActionResult> DeleteSpecialInfo(Guid id, Guid specialInfoId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
            if (user == null)
                return NotFound();
            var info = await _context.UserSpecialInfos.FirstOrDefaultAsync(b => b.Id == specialInfoId);
            if (info == null)
                return NotFound();

            _context.UserSpecialInfos.Remove(info);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (user == null) 
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
