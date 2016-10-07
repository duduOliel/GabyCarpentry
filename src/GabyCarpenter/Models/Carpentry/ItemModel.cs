using GabyCarpenter.Models.Carpentry.Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry
{
    public class ItemModel
    {
        [Key, Column(Order=1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public String name { get; set; }

        [StringLength(600, ErrorMessage ="Description must be less than 600 charecters")]
        public String description { get; set; }

        public float height { get; set; }

        public float width { get; set; }

        public float depth { get; set; }

        public String color { get; set; }

        public int price { get; set; }

        public byte[] images { get; set; }

        public ICollection<Part> parts { get; set; }

        public ICollection<Tag> tags { get; set; }
    }
}
