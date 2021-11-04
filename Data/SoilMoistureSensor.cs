using System;

namespace SmartGarden.Data
{
    public class SoilMoistureSensor
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
