using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfServiceKiosk.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        public string? ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal ProductPrice { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        public string? ImageUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityAvailable { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string? SupplierInfo { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }

        // Navigation property
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}