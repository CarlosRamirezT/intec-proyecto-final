using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intec_proyecto_final_t_3.Models
{
    public class Payments
    {
        public Int32 Id { get; set; }

        [Display(Name = "Invoice")]
        [ForeignKey("Invoices")]
        public Int32 InvoiceId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
