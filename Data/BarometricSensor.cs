using System;

namespace SmartGarden.Data
{
    public class BarometricSensor
    {
        public int Id { get; set; }
        public double TemperatureValue { get; set; }
        public double PressureValue { get; set; }
        public double AltitudeValue { get; set; }
        public DateTime CurrentDate { get; set; } 
    }
}
