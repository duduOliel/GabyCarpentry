﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GabyCarpenter.Models.Carpentry
{
    public class Supplier
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Address must be less than 300 charecters")]
        public string Address { get; set; }

        [RegularExpression("[0-9]{2,3}-?[0-9]{7,8}",ErrorMessage ="Please provide local israely phone numbre")]
        [Display(Name="Phone numbe")]
        public string PhoneNmber { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPersonName { get; set;}

        [Display(Name = "Contact Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}