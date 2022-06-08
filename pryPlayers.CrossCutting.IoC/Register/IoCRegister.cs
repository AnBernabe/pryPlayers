using Microsoft.Extensions.DependencyInjection;
using pryPlayers.Business.Contracts.Services;
using pryPlayers.Business.Services;
using pryPlayers.DataAccess.Contracts.Repositories;
using pryPlayers.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.CrossCutting.IoC.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterAppServices(services);
            AddRegisterServices(services);

            return services;
        }

        private static IServiceCollection AddRegisterAppServices(IServiceCollection services)
        {
            return services;
        }
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPlayerServiceRead, PlayerService>();
            services.AddTransient<IPlayerServiceWrite, PlayerService>();

            return services;
        }
        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            return services;
        }

    }

}
