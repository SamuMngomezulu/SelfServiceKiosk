using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using SelfServiceKiosk.Data;
using SelfServiceKiosk.Models;
using SelfServiceKiosk.DTOs;

namespace SelfServiceKiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(RegisterUserDto registerUserDto)
        {
            // Validating input
            if (await _context.Users.AnyAsync(u => u.Username == registerUserDto.Username))
            {
                return BadRequest("Username is already taken");
            }

            if (await _context.Users.AnyAsync(u => u.Email == registerUserDto.Email))
            {
                return BadRequest("Email is already registered");
            }

            // Password Encryption with new user
            var user = new User
            {
                Username = registerUserDto.Username,
                Email = registerUserDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password),
                AccountBalance = 0,
                IsActive = true
            };

            // Default user role assignment
            var userRole = new UserRole
            {
                User = user,
                RoleId = 2 
            };

            await _context.Users.AddAsync(user);
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(RegisterUser), new { id = user.UserId }, user);
        }
    }
}