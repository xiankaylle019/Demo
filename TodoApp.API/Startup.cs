using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoApp.API.Data;
using TodoApp.API.DataContext;

namespace TodoApp.API
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
            services.AddDbContext<AppDataContext>(db => db.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DataSeeder>();
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            seeder.SeedTodo();
            
            app.UseCors(c => c.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin()
            .AllowCredentials());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseMvc(routes => {


                    routes.MapSpaFallbackRoute(
                        name: "spa-fallback",
                        defaults: new { controller = "Main", action = "Index"}
                    );

            });
        }
    }
}
