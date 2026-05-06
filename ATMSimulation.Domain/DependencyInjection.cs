using ATMSimulation.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSimulation.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services )
        {
            services.AddScoped<IPasswordHasher<Card>, PasswordHasher<Card>>();
            return services;
        }
    }
}
