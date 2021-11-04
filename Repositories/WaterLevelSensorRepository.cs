using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartGarden.Repositories
{
    public class WaterLevelSensorRepository: IWaterLevelSensorRepository
    {
        private readonly SmartGardenContext _smartGardenContext;

        public WaterLevelSensorRepository(SmartGardenContext smartGardenContext)
        {
            _smartGardenContext = smartGardenContext;
        }

        public int AddNewWaterLevelSensor(WaterLevelSensorModel sensor)
        {
            var newSensor = new WaterLevelSensor()
            {
                Value = sensor.Value,
                CurrentDate = sensor.CurrentDate
            };
            _smartGardenContext.WaterLevelSensors.Add(newSensor);
            _smartGardenContext.SaveChanges();

            return newSensor.Id;
        }

        public List<WaterLevelSensor> GetAllWaterLevelSensors()
        {
            List<WaterLevelSensor> results = (from waterLevelSensor in _smartGardenContext.WaterLevelSensors
                                                select new WaterLevelSensor
                                                {
                                                    Id = waterLevelSensor.Id,
                                                    Value = waterLevelSensor.Value
                                                }).ToList();
            return results;
        }

        public WaterLevelSensor GetLastWaterLevelSensor()
        {
            WaterLevelSensor sensor = _smartGardenContext.WaterLevelSensors.ToList().Last();
            return sensor;
        }
    }
}
