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
    public class DetailConfiguration:IEntityTypeConfiguration<Detail>,ISeedData<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(50);
            builder.Property(b => b.Description).HasMaxLength(250);

            builder.HasOne(b => b.Category)
                .WithMany(p => p.Details)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);


            AddSeedData(builder,3);
        }

        /// <summary>
        /// Adds seed data to the specified EntityTypeBuilder.
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to configure the seed data for.</param>
        /// <param name="count">The number of seed data entries to add.</param>

        public void AddSeedData(EntityTypeBuilder<Detail> builder, in int count)
        {
            Faker faker = new Faker();
            Random random=new Random();
            for (int i = 0; i < count; i++)
            {
                builder.HasData(new Detail()
                {
                    Title = faker.Company.CompanyName(),
                    Description = faker.Commerce.ProductDescription(),
                    CategoryId = random.Next(1, 3),
                    IsDeleted = 0,
                    CreatedDate = DateTime.Now,
                    Id = i + 1
                });
            }
        }
    }
}
