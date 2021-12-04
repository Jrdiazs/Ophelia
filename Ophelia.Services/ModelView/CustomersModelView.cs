using System;
using System.ComponentModel.DataAnnotations;

namespace Ophelia.Services.ModelView
{
    public class CustomersModelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TypeDocument { get; set; }

        [Required]
        [MaxLength(20)]
        public string Document { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerNames { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerLastNames { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        public DateTime? BirthdayDate { get; set; }

        public DateTime CreationDate { get; set; }

        public string FullName
        { get { return $"{Document} - {CustomerNames} {CustomerLastNames}"; } }
    }
}