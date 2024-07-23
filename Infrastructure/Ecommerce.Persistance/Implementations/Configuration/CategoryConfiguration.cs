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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>, ISeedData<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50);

            AddSeedData(builder, 5);
        }

        /// <summary>
        /// Adds seed data to the specified EntityTypeBuilder.
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to configure the seed data for.</param>
        /// <param name="count">The number of seed data entries to add.</param>
        public void AddSeedData(EntityTypeBuilder<Category> builder, in int count)
        {
            Faker faker = new Faker();
            int parentCategoryCount = 3;

            for (int i = 0; i < count; i++)
            {
                int parentId = (i < parentCategoryCount) ? 0 : (i % parentCategoryCount) + 1;

                builder.HasData(new Category()
                {
                    Name = faker.Commerce.Categories(1)[0],
                    ParentId = parentId,
                    Priority = 1,
                    IsDeleted = 0,
                    CreatedDate = DateTime.Now,
                    Id = i + 1
                });
            }
        }
    }

}
