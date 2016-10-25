using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry
{


    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public ItemModel orderdItem { get; set; }

        [Display(Name = "Full name")]
        public string clientName { get; set; }

        [Display(Name = "Phone number")]
        public string phoneNumber { get; set; }

        [Display(Name = "Address")]
        public string SheepingAddress { get; set; }

        [Display(AutoGenerateField = false)]
        public OrderStatus status { get; set; }

    }
    public enum OrderStatus
    {
        New, Ready, Delivered
    }
}
