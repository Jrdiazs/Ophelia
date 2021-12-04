using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("InventoryQuantity")]
        public int InventoryQuantity { get; set; }

        [Column("PriceByUnit")]
        public decimal PriceByUnit { get; set; }
    }
}