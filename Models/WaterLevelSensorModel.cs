using System;

namespace SmartGarden.Models
{
    public class WaterLevelSensorModel
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
