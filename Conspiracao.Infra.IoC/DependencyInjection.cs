using Conspiracao.Application.Interfaces;
using Conspiracao.Application.Mappings;
using Conspiracao.Application.Services;
using Conspiracao.Domain.Interfaces;
using Conspiracao.Infra.Data.Context;
using Conspiracao.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            service.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            service.AddScoped<IPedidoRepository, PedidoRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();

            //Services
            service.AddScoped<IItemService, ItemService>();
            service.AddScoped<IPedidoService, PedidoService>();

            return service;
        }
    }
}
