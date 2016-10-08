using GabyCarpenter.Models.Carpentry.Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class ItemModel
    {
        [Key, Column(Order=1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        [StringLength(600, ErrorMessage ="Description must be less than 600 charecters")]
        public String Description { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }

        public float Depth { get; set; }

        public String Color { get; set; }

        public int Price { get; set; }

        public byte[] Images { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
