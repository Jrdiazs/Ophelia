using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        [Column("InvoiceDetailId")]
        public int InvoiceDetailId { get; set; }

        [Column("InvoiceId")]
        public int InvoiceId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("ProductQuantity")]
        public int ProductQuantity { get; set; }

        [Column("ProductValue")]
        public decimal ProductValue { get; set; }

        [Column("TotalValue")]
        public decimal TotalValue { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}