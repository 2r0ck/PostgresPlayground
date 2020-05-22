using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PostgresPlayGround.Db;
using PostgresPlayGround.Services;

namespace PostgresPlayGround
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins= "DebugCORS";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder                                     
                                       .WithOrigins("http://localhost:4201")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddControllers();
            
            var pg_conn = Configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContextPool<PlaygroundContext>(contextBuilder => 
            { 
                contextBuilder.UseNpgsql(pg_conn);                
                contextBuilder.UseLoggerFactory(LoggerFactory.Create(logBuilder => { logBuilder.AddDebug(); }));
                contextBuilder.EnableSensitiveDataLogging();

            },128);
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped(typeof(IGoodsRepository), typeof(GoodsRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); 
            });
           

            app.UseSpa(config => {

                config.Options.SourcePath = "play-app";
                if (env.IsDevelopment())
                {
                    //config.UseAngularCliServer(npmScript: "start");
                    config.UseProxyToSpaDevelopmentServer("http://localhost:4201");
                }

            });

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
