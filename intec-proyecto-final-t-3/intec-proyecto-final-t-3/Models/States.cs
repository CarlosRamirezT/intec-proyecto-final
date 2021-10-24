using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intec_proyecto_final_t_3.Models
{
    public class States
    {
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        [ForeignKey("Countries")]
        public Int32 CountryId { get; set; }

        public virtual Countries Country { get; set; }
    }
}
