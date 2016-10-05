using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class Tag
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string text { get; set; }
    }
}