using System;

namespace SmartGarden.Data
{
    public class TemperatureSensor
    {
        public int Id { get; set; }
        public double HumidityValue { get; set; }
        public double TemperatureCValue { get; set; }
        public double TemperatureFValue { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
