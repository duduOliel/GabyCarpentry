using Models.Carpentry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry
{
    public class ItemModel
    {
        
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

        public ICollection<byte[]> images { get; set; }

        public ICollection<IPart> parts { get; set; }

        public ICollection<String> tags { get; set; }
    }
}
