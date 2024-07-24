using Ecommerce.Application.Bases.Interfaces.Repositories;
using Ecommerce.Application.Bases.Interfaces.UnitOfWorks;
using Ecommerce.Persistance.Context;
using Ecommerce.Persistance.Implementations.Repositories;
using Ecommerce.Persistance.Implementations.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Registrations
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

             services.Add(new ServiceDescriptor(typeof(IReadRepository<>), typeof(ReadRepository<>), ServiceLifetime.Scoped));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

    }
  }
