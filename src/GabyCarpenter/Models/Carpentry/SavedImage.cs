using System.ComponentModel.DataAnnotations;

namespace GabyCarpenter.Models.Carpentry
{
    public class SavedImage
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public virtual ItemModel item { get; set; }
    }

}