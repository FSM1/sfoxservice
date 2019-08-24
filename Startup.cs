using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using sfoxservice.Services;

namespace sfoxservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var SFoxApiConfig = Configuration.GetSection("SFoxApi").Get<ApiSettings>();
            services.AddMvc()
                .AddJsonOptions(options =>
                    options.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerDocument();
            services.AddHttpClient<ISFoxApiClient, SFoxApiClient>(c =>
            {
                c.BaseAddress = new Uri(SFoxApiConfig.BaseAddress);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SFoxApiConfig.ApiKey);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseMvc();
        }
    }
}
