using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class Tag
    {
        public Tag()
        {

        }
        public Tag(string text)
        {
            this.Text = text;
        }

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Text { get; set; }
        
        public  ICollection<ItemModel> ItemModels { get; set; }
    }
}