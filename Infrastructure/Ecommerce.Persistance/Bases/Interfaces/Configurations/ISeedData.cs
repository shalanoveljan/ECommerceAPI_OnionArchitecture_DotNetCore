using Ecommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Bases.Interfaces.Configurations
{
    public interface ISeedData<T> where T : EntityBase, new()
    {
        public void AddSeedData(EntityTypeBuilder<T> builder, in int count);
    }
}
