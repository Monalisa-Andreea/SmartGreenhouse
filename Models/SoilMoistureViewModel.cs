using SmartGarden.Data;
using System;
using System.Collections.Generic;

namespace SmartGarden.Models
{
    public class SoilMoistureViewModel
    {
        public DateTime CurrentDate { get; set; }

        public List<SoilMoistureSensor> Sensors { get; set; }

        public SoilMoistureSensor Sensor { get; set; }

        public int Last { get; set; }

        public SoilMoistureViewModel()
        {
            Sensors = new List<SoilMoistureSensor>();
            Sensor = new SoilMoistureSensor();
            CurrentDate = DateTime.Now;
            Sensor.CurrentDate = DateTime.Now;
        }
    }
}
