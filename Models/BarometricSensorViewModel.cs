using SmartGarden.Data;
using System;
using System.Collections.Generic;

namespace SmartGarden.Models
{
    public class BarometricSensorViewModel
    {
        public DateTime CurrentDate { get; set; }

        public BarometricSensor Sensor { get; set; }

        public List<BarometricSensor> Sensors { get; set; }

        public BarometricSensorViewModel()
        {
            Sensors = new List<BarometricSensor>();
            
            CurrentDate = DateTime.Now;
            Sensor = new BarometricSensor();
        }
    }
}
