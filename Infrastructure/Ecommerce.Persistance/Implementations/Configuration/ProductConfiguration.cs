using Bogus;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistance.Bases.Interfaces.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Implementations.Configuration
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>,ISeedData<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(50);
            builder.Property(b => b.Description).HasMaxLength(1000);


            AddSeedData(builder, 4);
        }
        /// <summary>
        /// Adds seed data to the specified EntityTypeBuilder.
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to configure the seed data for.</param>
        /// <param name="count">The number of seed data entries to add.</param>
        public void AddSeedData(EntityTypeBuilder<Product> builder, in int count)
        {
            Faker faker = new Faker();
            Random random=new Random();
            for (int i = 0; i < count; i++)
            {
                builder.HasData(new Product()
                {
                    Title = faker.Company.CompanyName(),
                    Description = faker.Commerce.ProductDescription(),
                    Discount = random.Next(10,100),
                    Price = random.Next(100,1000),
                    BrandId = random.Next(1, 3),
                    IsDeleted = 0,
                    CreatedDate = DateTime.Now,
                    Id = i + 1
                });
            }
        }
    }
}
