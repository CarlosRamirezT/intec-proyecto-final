using System;
using Microsoft.EntityFrameworkCore;

namespace intec_proyecto_final_t_3.Models
{
    public class GeneralDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<States> States { get; set; }
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options)
        {
        }
    }
}
