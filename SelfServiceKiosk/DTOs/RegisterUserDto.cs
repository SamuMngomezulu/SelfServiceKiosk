using System.ComponentModel.DataAnnotations;

namespace SelfServiceKiosk.DTOs
{
    public class RegisterUserDto
    {
        [Required, MaxLength(50)]
        public required string Username { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public required string Email { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }
    }
}