using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;

namespace SmartGarden.Repositories
{
    public interface ITemperatureSensorRepository
    {
        List<TemperatureSensor> GetAllTemperatureSensors();
        int AddNewTemperatureSensor(TemperatureSensorModel sensor);
        TemperatureSensor GetLastTemperatureSensor();
    }
}
