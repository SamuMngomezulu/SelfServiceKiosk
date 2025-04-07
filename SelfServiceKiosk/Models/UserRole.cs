using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfServiceKiosk.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}