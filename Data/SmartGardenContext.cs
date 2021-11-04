using Microsoft.EntityFrameworkCore;

namespace SmartGarden.Data
{
    public class SmartGardenContext: DbContext
    {
        public SmartGardenContext(DbContextOptions<SmartGardenContext> options)
            :base(options)
        {

        }

        public DbSet<LightSensor> LightSensors { get; set; }
        public DbSet<SoilMoistureSensor> SoilMoistureSensors { get; set; }
        public DbSet<WaterLevelSensor> WaterLevelSensors { get; set; }
        public DbSet<TemperatureSensor> TemperatureSensors { get; set; }
        public DbSet<BarometricSensor> BarometricSensors { get; set; }
    }
}
