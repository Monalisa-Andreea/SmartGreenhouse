using System.IO.Ports;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartGarden.Data;
using SmartGarden.Repositories;
using SmartGarden.Utils;

namespace SmartGarden
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SmartGardenContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddTransient<ILightSensorRepository, LightSensorRepository>();
            services.AddTransient<ISoilMoistureSensorRepository, SoilMoistureSensorRepository>();
            services.AddTransient<IWaterLevelSensorRepository, WaterLevelSensorRepository>();
            services.AddTransient<ITemperatureSensorRepository, TemperatureSensorRepository>();
            services.AddTransient<IBarometricSensorRepository, BarometricSensorsRepository>();
            ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

            Thread t2 = new Thread(() =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<SmartGardenContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                var context = new SmartGardenContext(optionsBuilder.Options);

                SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
                
                IWaterLevelSensorRepository _waterLevelSensorRepository = new WaterLevelSensorRepository(context);
                ISoilMoistureSensorRepository _soilMoistureSensorRepository = new SoilMoistureSensorRepository(context);
                ILightSensorRepository _lightSensorRepository = new LightSensorRepository(context);
                ITemperatureSensorRepository _temperatureSensorRepository = new TemperatureSensorRepository(context);
                IBarometricSensorRepository _barometricSensorRepository = new BarometricSensorsRepository(context);

                DataAccess dataAccess = new DataAccess(_lightSensorRepository, _soilMoistureSensorRepository,
                    _waterLevelSensorRepository, _temperatureSensorRepository, _barometricSensorRepository, sp);
                Thread.Sleep(10 * 1000);
                dataAccess.Generate();

            });
            t2.Start();

            Thread t = new Thread(() =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<SmartGardenContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                var context = new SmartGardenContext(optionsBuilder.Options);

                IWaterLevelSensorRepository _waterLevelSensorRepository = new WaterLevelSensorRepository(context);
                EmailClass ec = new EmailClass(_waterLevelSensorRepository);
                while (true)
                {
                    ec.CheckWaterLevel();
                    Thread.Sleep(10 * 1000);
                }
            });
            t.Start();
        }
    }
}