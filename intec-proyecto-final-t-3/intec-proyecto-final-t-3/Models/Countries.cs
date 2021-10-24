using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace intec_proyecto_final_t_3.Models
{
    public class Countries
    {
        public Int32 Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}
