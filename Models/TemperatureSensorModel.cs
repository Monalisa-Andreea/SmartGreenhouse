using System;

namespace SmartGarden.Models
{
    public class TemperatureSensorModel
    {
        public int Id { get; set; }
        public double HumidityValue { get; set; }
        public double TemperatureCValue { get; set; }
        public double TemperatureFValue { get; set; }
        public DateTime CurrentDate { get; set; }

    }
}
