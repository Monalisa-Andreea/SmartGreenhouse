using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartGarden.Repositories
{
    public class LightSensorRepository : ILightSensorRepository
    {
        private SmartGardenContext _smartGardenContext;

        public LightSensorRepository(SmartGardenContext smartGardenContext)
        {
            _smartGardenContext = smartGardenContext;
        }

        public int AddNewLightSensor(LightSensorModel sensor)
        {
            var newSensor = new LightSensor()
            {
                Value = sensor.Value,
                CurrentDate = sensor.CurrentDate
            };
            _smartGardenContext.LightSensors.Add(newSensor);
            _smartGardenContext.SaveChanges();

            return newSensor.Id;
        }

        public List<LightSensor> GetAllLightSensors()
        {
            List<LightSensor> results = (from lightSensor in _smartGardenContext.LightSensors
                                         select new LightSensor
                                         {
                                             Id = lightSensor.Id,
                                             Value = lightSensor.Value
                                         }).ToList();
            return results;
        }

        public LightSensor GetLastLightSensor()
        {
            LightSensor sensor = _smartGardenContext.LightSensors.ToList().Last();
            sensor.CurrentDate = _smartGardenContext.LightSensors.ToList().Last().CurrentDate;
            return sensor;
        }
    }
}
