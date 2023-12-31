﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginPage.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentValidation;
namespace LoginPage.API
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
            //services.AddController();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                        ;
                    });



            });
            //services.AddDbContext<LoginPageDbContext>();
            //services.AddScoped<DbContext, LoginPageDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                options => options.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
            );
            app.UseMvc();
        }
    }
}
