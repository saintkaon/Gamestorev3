﻿using Gamestore.Models;
using Gamestorev3.Server.Interfaces;
using Gamestorev3.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace Gamestorev3.Server.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<StoreDbContext>(op => op.UseSqlServer(config.GetConnectionString("con")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}