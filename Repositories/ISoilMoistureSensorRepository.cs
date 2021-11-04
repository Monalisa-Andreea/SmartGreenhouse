using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;

namespace SmartGarden.Repositories
{
    public interface ISoilMoistureSensorRepository
    {
        List<SoilMoistureSensor> GetAllSoilMoistureSensors();
        int AddNewSoilMoistureSensor(SoilMoistureSensorModel sensor);
        SoilMoistureSensor GetLastMoistureSensor();
    }
}
