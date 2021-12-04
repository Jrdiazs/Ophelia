using System;
using System.ComponentModel.DataAnnotations;

namespace Ophelia.Services.ModelView
{
    public class InvoiceModelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int InvoiceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int Customer { get; set; }

        [Required]
        public decimal TotalBill { get; set; }

        public string CustomerName { get; set; }
    }
}