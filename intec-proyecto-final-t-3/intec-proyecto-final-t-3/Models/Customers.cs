using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intec_proyecto_final_t_3.Models
{
    public class Customers
    {
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Street")]
        public String Street { get; set; }

        [Display(Name = "Street 2")]
        public String Street2 { get; set; }

        [Display(Name = "City")]
        [ForeignKey("Cities")]
        public Int32 CityId { get; set; }

        [Display(Name = "State")]
        [ForeignKey("States")]
        public Int32 StateId { get; set; }

        [Display(Name = "Country")]
        [ForeignKey("Countries")]
        public Int32 CountryId { get; set; }

        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Display(Name = "Phone")]
        public String Phone { get; set; }

        [Display(Name = "Mobile")]
        public String Mobile { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Note")]
        public String Note { get; set; }
    }
}
