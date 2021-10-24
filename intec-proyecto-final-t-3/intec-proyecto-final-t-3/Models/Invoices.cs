using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intec_proyecto_final_t_3.Models
{
    public class Invoices
    {
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey("Customers")]
        public Int32 CustomerId { get; set; }

        [Required]
        [Display(Name = "State")]
        [ForeignKey("InvoiceStates")]
        public Int32 StateId { get; set; }

        [Display(Name = "Date Invoice")]
        public DateTime DateInvoice { get; set; }

        [Display(Name = "Date Due")]
        public DateTime DateDue { get; set; }

        [Display(Name = "Amount Untaxed")]
        public double AmountUntaxed { get; set; }

        [Display(Name = "Amount Tax")]
        public double AmountTax { get; set; }

        [Display(Name = "Amount Total")]
        public double AmountTotal { get; set; }
    }

    public class InvoicesLines
    {
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Invoice")]
        [ForeignKey("Invoices")]
        public Int32 InvoiceId { get; set; }

        [Required]
        [Display(Name = "Product")]
        [ForeignKey("Products")]
        public Int32 ProductId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Display(Name = "Subtotal")]
        public double Subtotal { get; set; }

    }
}
