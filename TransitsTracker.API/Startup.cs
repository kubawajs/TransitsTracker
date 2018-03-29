using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TransitsTracker.API.Database;
using TransitsTracker.API.ExternalServices.GoogleMaps;
using TransitsTracker.API.Repositories;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Repositories;

namespace TransitsTracker.API
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
            services.AddDbContext<TransitsTrackerContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<IMapService, GoogleMapsService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ITransitService, TransitService>();

            // Repositories
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ITransitRepository, TransitRepository>();

            services.AddMvc()
                    .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
