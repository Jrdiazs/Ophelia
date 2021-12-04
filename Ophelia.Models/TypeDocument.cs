using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ophelia.Models
{
    [Table("TypeDocument")]
    public class TypeDocument
    {
        [Key]
        [Column("TypeDocumentId")]
        public int TypeDocumentId { get; set; }

        [Column("TypeDocumentName")]
        public string TypeDocumentName { get; set; }


        [Column("TypeDocumentNameShort")]
        public string TypeDocumentNameShort { get; set; }
    }
}