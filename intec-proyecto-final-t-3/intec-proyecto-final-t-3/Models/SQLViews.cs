using System;
namespace intec_proyecto_final_t_3.Models
{

    public class AddressStatesView
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Country { get; set; }
    }

    public class CitiesView
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
    }

    public class CustomersView
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Street { get; set; }
        public String Street2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Country { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }
        public String Note { get; set; }
    }

    public class InvoicesView
    {
        public Int32 Id { get; set; }
        public String Customer { get; set; }
        public DateTime DateInvoice { get; set; }
        public DateTime DateDue { get; set; }
        public String State { get; set; }
        public double AmountUntaxed { get; set; }
        public double AmountTax { get; set; }
        public double AmountTotal { get; set; }
        public double AmountPaid { get; set; }
        public double AmountDue { get; set; }
    }

    public class InvoicesLinesView
    {
        public Int32 Id { get; set; }
        public Int32 InvoiceId { get; set; }
        public String Product { get; set; }
        public String Description { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal { get; set; }
    }
}
