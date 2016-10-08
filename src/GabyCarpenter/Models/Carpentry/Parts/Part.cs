using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry.Parts
{
    public abstract  class Part
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Provider { get; set; }
        public int PartPrice { get; set; }

        [Display(Name = "amount in inventory")]
        public int AmountInInvetory { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public bool IsInvenory { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Thickness { get; set; }
    }
}