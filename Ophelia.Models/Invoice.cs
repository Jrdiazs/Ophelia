using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [Column("InvoiceId")]
        public int InvoiceId { get; set; }

        [Column("InvoiceNumber")]
        public int InvoiceNumber { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("TotalBill")]
        public decimal TotalBill { get; set; }
    }
}