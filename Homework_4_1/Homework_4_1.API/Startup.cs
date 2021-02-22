using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Homework_4_1.Business;
using Homework_4_1.Business.Abstract;
using Homework_4_1.Business.Concrete;
using Homework_4_1.DataAccess;
using Homework_4_1.Entities.Concrete;



namespace Homework_4_1.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var productPath = Path.GetFullPath(exePath + "\\..\\..\\..\\..\\products.txt");
            MainDbContext.Contextconfig confiContextconfig = new MainDbContext.Contextconfig();
            confiContextconfig.AddConfig(
                new MainDbContext.DbSetConfig(typeof(Product),
                    productPath));
            
            services.AddSingleton(confiContextconfig);
            services.AddSingleton<MainDbContext,MainDbContext>();
            services.AddScoped<IService<Product>,ProductService>(); 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Homework_4_1.DI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Homework_4_1.DI v1"));
            }

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
