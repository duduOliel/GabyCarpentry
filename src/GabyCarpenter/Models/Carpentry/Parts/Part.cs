﻿using System.ComponentModel.DataAnnotations;

namespace Models.Carpentry
{
    public abstract class Part
    {
        public int id { get; set; }
        public string partNumber { get; set; }
        public string provider { get; set; }
        public int price { get; set; }

        [Display(Name = "amount in inventory"]
        public int amountInInvetory { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

    }
}