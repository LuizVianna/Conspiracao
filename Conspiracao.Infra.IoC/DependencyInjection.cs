﻿using Conspiracao.Application.Interfaces;
using Conspiracao.Application.Mappings;
using Conspiracao.Application.Services;
using Conspiracao.Domain.Interfaces;
using Conspiracao.Infra.Data.Context;
using Conspiracao.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            service.AddAuthentication(
                    opt =>
                    {
                        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(option =>
                    {
                        option.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = configuration["jwt:issuer"],
                            ValidAudience = configuration["jwt:audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(
                                                Encoding.UTF8.GetBytes(configuration["jwt:secretkey"])),
                            ClockSkew = TimeSpan.Zero
                        };
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
