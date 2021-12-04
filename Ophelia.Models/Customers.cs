using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("TypeDocumentId")]
        public int TypeDocumentId { get; set; }

        [Column("DocumentNumber")]
        public string DocumentNumber { get; set; }

        [Column("CustomerNames")]
        public string CustomerNames { get; set; }

        [Column("CustomerLastNames")]
        public string CustomerLastNames { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("BirthdayDate")]
        public DateTime? BirthdayDate { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}