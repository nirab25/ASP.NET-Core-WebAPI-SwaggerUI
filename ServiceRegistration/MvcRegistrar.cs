using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace AspDotNetCoreWebAPISwaggerUI.ServiceRegistration
{
    public class MvcRegistrar : IServiceRegistrar
    {
        public void RegisterSevices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            
            services.AddRazorPages();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET Core WebAPI with SwaggerUI", Version = "v1" });
            });
        }
    }
}
