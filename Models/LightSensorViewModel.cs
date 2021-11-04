using SmartGarden.Data;
using System;
using System.Collections.Generic;

namespace SmartGarden.Models
{
    public class LightSensorViewModel
    {
        public DateTime CurrentDate { get; set; }

        public List<LightSensor> Sensors { get; set; }

        public LightSensor Sensor { get; set; }

        public LightSensorViewModel()
        {
            Sensors = new List<LightSensor>();
            Sensor = new LightSensor();
            CurrentDate = DateTime.Now;
            Sensor.CurrentDate = DateTime.Now;
        }
    }
}
