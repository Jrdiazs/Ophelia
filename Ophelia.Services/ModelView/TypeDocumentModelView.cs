using System.ComponentModel.DataAnnotations;

namespace Ophelia.Services.ModelView
{
    public class TypeDocumentModelView
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeDocumentName { get; set; }

        [Required]
        [MaxLength(20)]
        public string TypeDocumentNameShort { get; set; }
    }
}