﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Gotham.web.Models;
using Gotham.persistence;
using Gotham.domain;

namespace Gotham
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
            services.AddControllersWithViews();

            services.AddDbContext<GothamwebContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GothamwebContext")));

            /*
            services.AddSingleton<IRepository<Capsule>, MockCapsuleRepository>();
            services.AddSingleton<IRepository<Nouvelle>, MockNouvellesRepository>();
            services.AddSingleton<IRepository<Signalement>, MockSignalementsRepository>();*/

            services.AddSingleton<IRepository<Capsule>, RepositoryPattern<Capsule>>();
            services.AddSingleton<IRepository<Nouvelle>, RepositoryPattern<Nouvelle>>();
            services.AddSingleton<IRepository<Signalement>, RepositoryPattern<Signalement>>();
            services.AddSingleton<IRepository<Alerte>, RepositoryPattern<Alerte>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
