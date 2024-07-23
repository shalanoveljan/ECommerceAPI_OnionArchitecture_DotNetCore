using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        private DbSet<Category> Categories { get; set; }
        private DbSet<Brand> Brands { get; set; }
        private DbSet<Detail> Details { get; set; }
        private DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
