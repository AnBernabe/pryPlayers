using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pryPlayers.Application.Contracts.Mappers;
using pryPlayers.Business.Contracts.Mappers;
using pryPlayers.CrossCutting.IoC.Register;
using pryPlayers.DataAccess;
using pryPlayers.DataAccess.Contracts;
using pryPlayers_API.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pryPlayers_API
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IoCRegister.AddRegistration(services);

            SwaggerConfig.AddRegistration(services);

            services.AddAutoMapper(typeof(ViewModelDtoMapper), typeof(DtoEntityMapper));

            services.AddTransient<IPlayersDBContext, PlayersDBContext>();
            services.AddDbContext<PlayersDBContext>(options =>
            {
                options.UseSqlServer(
                    _configuration.GetConnectionString("PlayersConnection"), builder =>
                    {
                        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        builder.CommandTimeout(60);
                    });
                //options.EnableSensitiveDataLogging(true);
            });

            services.AddCors(confg =>
             confg.AddPolicy("AllowAll",
                 p => p.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SwaggerConfig.AddRegistration(app);

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
