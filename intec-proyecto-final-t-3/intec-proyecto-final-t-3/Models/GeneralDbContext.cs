using System;
using Microsoft.EntityFrameworkCore;
using intec_proyecto_final_t_3.Models;

namespace intec_proyecto_final_t_3.Models
{
    public class GeneralDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<InvoicesLines> InvoicesLines { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<InvoiceStates> InvoiceStates { get; set; }

        public DbSet<AddressStatesView> AddressStatesView { get; set; }
        public DbSet<CitiesView> CitiesView { get; set; }
        public DbSet<CustomersView> CustomersView { get; set; }
        public DbSet<InvoicesView> InvoicesView { get; set; }
        public DbSet<InvoicesLinesView> InvoicesLinesView { get; set; }

        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options)
        {
        }
    }
}
