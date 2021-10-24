using System;
using Microsoft.EntityFrameworkCore;

namespace intec_proyecto_final_t_3.Models
{
    public class CountriesDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public CountriesDbContext(DbContextOptions<CountriesDbContext> options) : base(options)
        {
        }
    }
}
