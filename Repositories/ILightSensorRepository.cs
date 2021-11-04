using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;

namespace SmartGarden.Repositories
{
    public interface ILightSensorRepository
    {
        List<LightSensor> GetAllLightSensors();
        int AddNewLightSensor(LightSensorModel sensor);
        LightSensor GetLastLightSensor();
    }
}
