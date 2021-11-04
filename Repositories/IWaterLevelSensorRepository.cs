using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;

namespace SmartGarden.Repositories
{
    public interface IWaterLevelSensorRepository
    {
        List<WaterLevelSensor> GetAllWaterLevelSensors();
        int AddNewWaterLevelSensor(WaterLevelSensorModel sensor);

        WaterLevelSensor GetLastWaterLevelSensor();
    }
}
