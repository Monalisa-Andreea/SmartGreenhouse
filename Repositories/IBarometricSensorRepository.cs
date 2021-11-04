using SmartGarden.Data;
using SmartGarden.Models;
using System.Collections.Generic;

namespace SmartGarden.Repositories
{
    public interface IBarometricSensorRepository
    {
        List<BarometricSensor> GetAllBarometricSensors();

        int AddNewBarometricSensor(BarometricSensorModel sensor);

        BarometricSensor GetLastBarometricSensor();
    }
}
