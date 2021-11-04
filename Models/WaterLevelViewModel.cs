using SmartGarden.Data;
using System;
using System.Collections.Generic;

namespace SmartGarden.Models
{
    public class WaterLevelViewModel
    {
        public DateTime CurrentDate { get; set; }

        public List<WaterLevelSensor> Sensors { get; set; }

        public WaterLevelSensor Sensor { get; set; }

        public int Last { get; set; }

        public WaterLevelViewModel()
        {
            Sensors = new List<WaterLevelSensor>();
            Sensor = new WaterLevelSensor();
            CurrentDate = DateTime.Now;
            Sensor.CurrentDate = DateTime.Now;
        }
    }
}
