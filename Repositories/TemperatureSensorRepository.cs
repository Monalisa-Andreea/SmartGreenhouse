using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartGarden.Repositories
{
    public class TemperatureSensorRepository: ITemperatureSensorRepository
    {
        private readonly SmartGardenContext _smartGardenContext;

        public TemperatureSensorRepository(SmartGardenContext smartGardenContext)
        {
            _smartGardenContext = smartGardenContext;
        }

        public int AddNewTemperatureSensor(TemperatureSensorModel sensor)
        {
            var newSensor = new TemperatureSensor()
            {
                HumidityValue = sensor.HumidityValue,
                TemperatureCValue = sensor.TemperatureCValue,
                TemperatureFValue = sensor.TemperatureFValue,
                CurrentDate = sensor.CurrentDate
            };
            _smartGardenContext.TemperatureSensors.Add(newSensor);
            _smartGardenContext.SaveChanges();

            return newSensor.Id;
        }

        public List<TemperatureSensor> GetAllTemperatureSensors()
        {
            List<TemperatureSensor> results = (from temperatureSensor in _smartGardenContext.TemperatureSensors
                                              select new TemperatureSensor
                                              {
                                                  Id = temperatureSensor.Id,
                                                  HumidityValue = temperatureSensor.HumidityValue,
                                                  TemperatureCValue = temperatureSensor.TemperatureCValue,
                                                  TemperatureFValue = temperatureSensor.TemperatureFValue
                                              }).ToList();
            return results;
        }

        public TemperatureSensor GetLastTemperatureSensor()
        {
            TemperatureSensor sensor = _smartGardenContext.TemperatureSensors.ToList().Last();
            return sensor;
            
        }
    }
}
