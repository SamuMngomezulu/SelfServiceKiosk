using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfServiceKiosk.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [MaxLength(20)]
        public string TransactionType { get; set; } = "Deposit";

        public int? Reference { get; set; } // OrderId if purchase

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}