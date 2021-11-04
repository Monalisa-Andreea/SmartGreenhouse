using SmartGarden.Data;
using SmartGarden.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartGarden.Repositories
{
    public class BarometricSensorsRepository: IBarometricSensorRepository
    {
        private readonly SmartGardenContext _smartGardenContext;

        public BarometricSensorsRepository(SmartGardenContext smartGardenContext)
        {
            _smartGardenContext = smartGardenContext;
        }

        public int AddNewBarometricSensor(BarometricSensorModel sensor)
        {
            var newSensor = new BarometricSensor()
            {
                TemperatureValue = sensor.TemperatureValue,
                PressureValue = sensor.PressureValue,
                AltitudeValue = sensor.AltitudeValue,
                CurrentDate = DateTime.Now

        };
            _smartGardenContext.BarometricSensors.Add(newSensor);
            _smartGardenContext.SaveChanges();

            return newSensor.Id;
        }

        public List<BarometricSensor> GetAllBarometricSensors()
        {
            List<BarometricSensor> results = (from barometricSensor in _smartGardenContext.BarometricSensors
                                               select new BarometricSensor
                                               {
                                                   Id = barometricSensor.Id,
                                                   TemperatureValue = barometricSensor.TemperatureValue,
                                                   PressureValue = barometricSensor.PressureValue,
                                                   AltitudeValue = barometricSensor.AltitudeValue
                                               }).ToList();
            return results;
        }

        public BarometricSensor GetLastBarometricSensor()
        {
            BarometricSensor sensor = _smartGardenContext.BarometricSensors.ToList().Last();
            return sensor;
        }
    }
}
