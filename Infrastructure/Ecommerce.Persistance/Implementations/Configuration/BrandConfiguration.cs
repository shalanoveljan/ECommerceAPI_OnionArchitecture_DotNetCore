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
    public class BrandConfiguration:IEntityTypeConfiguration<Brand>,ISeedData<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50);

            builder.HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

            AddSeedData(builder, 5);
        }
        /// <summary>
        /// Adds seed data to the specified EntityTypeBuilder.
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to configure the seed data for.</param>
        /// <param name="count">The number of seed data entries to add.</param>
        public void AddSeedData(EntityTypeBuilder<Brand> builder, in int count)
        {
            Faker faker = new Faker();
            for (int i = 0; i < count; i++)
            {
                builder.HasData(new Brand()
                {
                    Name = faker.Commerce.Categories(1)[0],
                    IsDeleted = 0,
                    CreatedDate = DateTime.Now,
                    Id = i + 1
                });
            }
        }
    }
}
