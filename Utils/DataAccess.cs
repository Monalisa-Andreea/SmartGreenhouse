using Microsoft.Extensions.Configuration;
using SmartGarden.Models;
using SmartGarden.Repositories;
using System;
using System.Globalization;
using System.IO.Ports;

namespace SmartGarden.Utils
{
    public class DataAccess
    {
        public SerialPort sp;


        private readonly ILightSensorRepository _lightSensorRepository;
        private readonly ISoilMoistureSensorRepository _soilMoistureSensorRepository;
        private readonly IWaterLevelSensorRepository _waterLevelSensorRepository;
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        private readonly IBarometricSensorRepository _barometricSensorRepository;

        private int? lightValue = null;
        private int? soilMoistureValue = null;
        private int? waterlLevelValue = null;
        private double? humidityValue = null;
        private double? temperatureCValue = null;
        private double? temperatureFValue = null;
        private double? temperatureValue = null;
        private double? pressureValue = null;
        private double? altitudeValue = null;

        public DataAccess(ILightSensorRepository lightSensorRepository, ISoilMoistureSensorRepository soilMoistureSensorRepository,
            IWaterLevelSensorRepository waterLevelSensorRepository, ITemperatureSensorRepository temperatureSensorRepository,
            IBarometricSensorRepository barometricSensorRepository, SerialPort port)
        {
            sp = port;
            _lightSensorRepository = lightSensorRepository;
            _soilMoistureSensorRepository = soilMoistureSensorRepository;
            _waterLevelSensorRepository = waterLevelSensorRepository;
            _temperatureSensorRepository = temperatureSensorRepository;
            _barometricSensorRepository = barometricSensorRepository;
        }

        public void Generate()
        {
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            sp.Open();
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string aux = sp.ReadLine();
            string input = aux;
            Console.WriteLine(input);

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            if (input.Contains(config["ObjectSensor:Light"]))
            {
                string data = receivedData(config["ObjectSensor:Light"], input);
                try
                {
                    lightValue = Int32.Parse(data);
                }
                catch
                {
                    lightValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Soil"]))
            {
                string data = receivedData(config["ObjectSensor:Soil"], input);
                try
                {
                    soilMoistureValue = Int32.Parse(data);
                }
                catch
                {
                    soilMoistureValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Water"]))
            {
                string data = receivedData(config["ObjectSensor:Water"], input);
                try
                {
                    waterlLevelValue = Int32.Parse(data);
                }
                catch
                {
                    waterlLevelValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Humidity"]))
            {
                string data = receivedData(config["ObjectSensor:Humidity"], input);
                try
                {
                    humidityValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    humidityValue = null; 
                }
                
            }
            if (input.Contains(config["ObjectSensor:TemperatureC"]))
            {
                string data = receivedData(config["ObjectSensor:TemperatureC"], input);
                try
                {
                    temperatureCValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    temperatureCValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:TemperatureF"]))
            {
                string data = receivedData(config["ObjectSensor:TemperatureF"], input);
                try
                {
                    temperatureFValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    temperatureFValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Temperature"]))
            {
                string data = receivedData(config["ObjectSensor:Temperature"], input);
                try
                {
                    temperatureValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    temperatureValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Pressure"]))
            {
                string data = receivedData(config["ObjectSensor:Pressure"], input);
                try
                {
                    pressureValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    pressureValue = null;
                }
            }
            if (input.Contains(config["ObjectSensor:Altitude"]))
            {
                string data = receivedData(config["ObjectSensor:Altitude"], input);
                try
                {
                    altitudeValue = double.Parse(data, CultureInfo.InvariantCulture);
                }
                catch
                {
                    altitudeValue = null;
                }
            }
            if (lightValue.HasValue)
            {
                var lightSensor = new LightSensorModel();
                lightSensor.Value = (int)lightValue;
                lightSensor.CurrentDate = DateTime.Now;
                var id = _lightSensorRepository.AddNewLightSensor(lightSensor);
                lightValue = null;
            }
            if (soilMoistureValue.HasValue)
            {
                var soilMoistureSensor = new SoilMoistureSensorModel();
                soilMoistureSensor.Value = (int)soilMoistureValue;
                soilMoistureSensor.CurrentDate = DateTime.Now;
                var id = _soilMoistureSensorRepository.AddNewSoilMoistureSensor(soilMoistureSensor);
                soilMoistureValue = null;
            }
            if (waterlLevelValue.HasValue)
            {
                var waterLevelSensor = new WaterLevelSensorModel();
                waterLevelSensor.Value = (int)waterlLevelValue;
                waterLevelSensor.CurrentDate = DateTime.Now;
                var id = _waterLevelSensorRepository.AddNewWaterLevelSensor(waterLevelSensor);
                waterlLevelValue = null;
            }
            if (humidityValue.HasValue && temperatureCValue.HasValue && temperatureFValue.HasValue)
            {
                var temperatureSensor = new TemperatureSensorModel();
                temperatureSensor.HumidityValue = (double)humidityValue;
                temperatureSensor.TemperatureCValue = (double)temperatureCValue;
                temperatureSensor.TemperatureFValue = (double)temperatureFValue;
                temperatureSensor.CurrentDate = DateTime.Now;
                var id = _temperatureSensorRepository.AddNewTemperatureSensor(temperatureSensor);
                humidityValue = null;
                temperatureCValue = null;
                temperatureFValue = null;
            }
            if (temperatureValue.HasValue && pressureValue.HasValue && altitudeValue.HasValue)
            {
                var barometricSensor = new BarometricSensorModel();
                barometricSensor.TemperatureValue = (double)temperatureValue;
                barometricSensor.PressureValue = (double)pressureValue;
                barometricSensor.AltitudeValue = (double)altitudeValue;
                barometricSensor.CurrentDate = DateTime.Now;
                var id = _barometricSensorRepository.AddNewBarometricSensor(barometricSensor);
                temperatureValue = null;
                pressureValue = null;
                altitudeValue = null;
            }
        }

        private string receivedData(string sensorName, string input)
        {
            if (input.Contains(sensorName))
            {
                return input.Replace(sensorName, string.Empty);
            }
            return null;
        }
    }
}
