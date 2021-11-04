using System;

namespace SmartGarden.Data
{
    public class WaterLevelSensor
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
