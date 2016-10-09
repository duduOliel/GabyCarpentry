using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class ItemModel
    {
        public ItemModel()
        {
            this.Tags = new List<Tag>();
            this.Image = new List<SavedImage>();

        }
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

        public virtual ICollection<SavedImage> Image { get; set; }

        public  ICollection<Tag> Tags { get; set; }

        public virtual Supplier supplier { get; set; }

        public int amountInStock { get; set; }
    }
}
