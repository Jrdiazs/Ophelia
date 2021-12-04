using System;
using System.ComponentModel.DataAnnotations;

namespace Ophelia.Services.ModelView
{
    public class InvoiceDetailModelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Invoice { get; set; }

        [Required]
        public int Product { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal ProductValue { get; set; }

        [Required]
        public decimal TotalValue { get; set; }

        public DateTime CreationDate { get; set; }
    }
}