using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("Parameters")]
    public class Parameters
    {
        [Key]
        [Column("ParameterId")]
        public Guid ParameterId { get; set; }

        [Column("ParameterKey")]
        public string ParameterKey { get; set; }

        [Column("ParameterValueInt")]
        public int? ParameterValueInt { get; set; }

        [Column("ParameterValueString")]
        public string ParameterValueString { get; set; }

        [Column("ParameterValueDate")]
        public DateTime? ParameterValueDate { get; set; }

        [Column("ParameterValueBool")]
        public bool? ParameterValueBool { get; set; }
    }
}