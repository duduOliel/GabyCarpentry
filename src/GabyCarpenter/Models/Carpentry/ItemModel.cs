using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class ItemModel
    {
        public ItemModel() { 
        
            this.Image = new List<SavedImage>();

        }

        [Key, Column(Order=1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Order = 1)]
        public String Name { get; set; }

        [StringLength(600, ErrorMessage ="Description must be less than 600 charecters")]
        [Display(Order = 2)]
        public String Description { get; set; }

        [Display(Order = 3)]
        public float Height { get; set; }

        [Display(Order = 4)]
        public float Width { get; set; }

        [Display(Order = 5)]
        public float Depth { get; set; }

        [Display(Order = 6)]
        public String Color { get; set; }

        [Display(Order = 7)]
        public int Price { get; set; }
        
        public virtual ICollection<SavedImage> Image { get; set; }

        [Display(Order = 8)]
        public virtual Supplier supplier { get; set; }

        [Display(Order = 9)]
        public int amountInStock { get; set; }

        [Display(Order = 10)]
        public String tags { get; set; }
    }
}
