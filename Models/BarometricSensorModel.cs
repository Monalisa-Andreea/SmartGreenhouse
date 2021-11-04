using System;

namespace SmartGarden.Models
{
    public class BarometricSensorModel
    {
        public int Id { get; set; }
        public double TemperatureValue { get; set; }
        public double PressureValue { get; set; }
        public double AltitudeValue { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
