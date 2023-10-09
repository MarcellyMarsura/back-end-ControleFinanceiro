using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Interfaces;
using WebAPI.Application.Mapper.Profiles;
using WebAPI.Application.Services;
using WebAPI.Domain.Interfaces;
using WebAPI.Infrastructure.Data.Repository;

namespace WebAPI.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            IServiceProvider provider = services.BuildServiceProvider();

            services.AddSingleton(configuration);

            //AutoMapper
            services.AddSingleton<IMapper>(r => {
                var mapperConfiguration = new MapperConfiguration(mc =>
                {
                    mc.AddProfile<ExemploProfile>();
                });

                return mapperConfiguration.CreateMapper();
            });

            //Application Layer
            services.AddScoped<IExemploService, ExemploService>();

            //Data Layer
            services.AddScoped<IExemploRepository, ExemploRepository>();
            
        }
    }
}
