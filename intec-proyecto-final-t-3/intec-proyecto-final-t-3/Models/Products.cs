using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intec_proyecto_final_t_3.Models
{
    public class Products
    {
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Cost")]
        public double Cost { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

    }
}
