using ApiModels.Configuration;
using Db.MainDatabase;
using Microsoft.EntityFrameworkCore;
using PisciApi.Ioc;

namespace PisciApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<MyAppSettings>(Configuration);
            var connectionString = Configuration["ConnectionString"];
            services.AddDbContext<PisciContext>(options => options.UseSqlServer(connectionString));
            AppMappings.MapDependencies(services);
            services.AddAutoMapper(typeof(MappingsProfile));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllers();
            app.Run();

        }
    }
}
