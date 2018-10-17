using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWrapper.Models;
using ApiWrapper.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiWrapper
{
    public class Startup
    {
        private string _version;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _version = typeof(Startup).Assembly.GetName().Version.ToString();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("Connection");
            services.AddDbContext<InvoiceContext>(options => options.UseSqlServer(connection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddTransient<IDBService, DBService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IResponseGenerator, ResponseGenerator>();
            services.AddTransient<IWrapperHandler, WrapperHandler>();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Info
               {
                   Version = _version,
                   Title = "ApiWrapper",
                   Description = "ASP.NET Core web API wrapper",
                   TermsOfService = "None"
               });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiWrapper");
            });

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<InvoiceContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
