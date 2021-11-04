using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartGarden.Repositories
{
    public class SoilMoistureSensorRepository : ISoilMoistureSensorRepository
    {
        private readonly SmartGardenContext _smartGardenContext;

        public SoilMoistureSensorRepository(SmartGardenContext smartGardenContext)
        {
            _smartGardenContext = smartGardenContext;
        }

        public int AddNewSoilMoistureSensor(SoilMoistureSensorModel sensor)
        {
            var newSensor = new SoilMoistureSensor()
            {
                Value = sensor.Value,
                CurrentDate = sensor.CurrentDate
            };
            _smartGardenContext.SoilMoistureSensors.Add(newSensor);
            _smartGardenContext.SaveChanges();

            return newSensor.Id;
        }

        public List<SoilMoistureSensor> GetAllSoilMoistureSensors()
        {
            List<SoilMoistureSensor> results = (from soilMoistureSensor in _smartGardenContext.SoilMoistureSensors
                                                select new SoilMoistureSensor
                                                {
                                                    Id = soilMoistureSensor.Id,
                                                    Value = soilMoistureSensor.Value
                                                }).ToList();
            return results;
        }

        public SoilMoistureSensor GetLastMoistureSensor()
        {
            SoilMoistureSensor sensor = _smartGardenContext.SoilMoistureSensors.ToList().Last();
            return sensor;
            
        }
    }
}
