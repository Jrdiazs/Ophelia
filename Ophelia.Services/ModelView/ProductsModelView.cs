using System.ComponentModel.DataAnnotations;

namespace Ophelia.Services.ModelView
{
    public class ProductsModelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public int InventoryQuantity { get; set; }

        [Required]
        public decimal PriceByUnit { get; set; }
    }
}