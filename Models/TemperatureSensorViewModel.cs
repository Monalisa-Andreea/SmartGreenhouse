using SmartGarden.Data;
using System;
using System.Collections.Generic;

namespace SmartGarden.Models
{
    public class TemperatureSensorViewModel
    {
        public DateTime CurrentDate { get; set; }

        public List<TemperatureSensor> Sensors { get; set; }

        public TemperatureSensor Sensor { get; set; }

        public int Last { get; set; }

        public TemperatureSensorViewModel()
        {
            Sensors = new List<TemperatureSensor>();
            Sensor = new TemperatureSensor();
            CurrentDate = DateTime.Now;
            Sensor.CurrentDate = DateTime.Now;
        }
    }
}
