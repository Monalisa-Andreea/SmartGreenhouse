using System;
using System.Diagnostics;
using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using SmartGarden.Models;
using SmartGarden.Repositories;

namespace SmartGarden.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

        private readonly ILightSensorRepository _lightSensorRepository;
        private readonly ISoilMoistureSensorRepository _soilMoistureSensorRepository;
        private readonly IWaterLevelSensorRepository _waterLevelSensorRepository;
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        private readonly IBarometricSensorRepository _barometricSensorRepository;

        public HomeController(ILightSensorRepository lightSensorRepository, ISoilMoistureSensorRepository soilMoistureSensorRepository,
            IWaterLevelSensorRepository waterLevelSensorRepository, ITemperatureSensorRepository temperatureSensorRepository,
            IBarometricSensorRepository barometricSensorRepository)
        {
            _lightSensorRepository = lightSensorRepository;
            _soilMoistureSensorRepository = soilMoistureSensorRepository;
            _waterLevelSensorRepository = waterLevelSensorRepository;
            _temperatureSensorRepository = temperatureSensorRepository;
            _barometricSensorRepository = barometricSensorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult LightSensor()
        {
            try
            {
                var lightSensorModel = new LightSensorViewModel();
                lightSensorModel.Sensor.Value = _lightSensorRepository.GetLastLightSensor().Value;
                lightSensorModel.Sensors = _lightSensorRepository.GetAllLightSensors();
                lightSensorModel.Sensor.CurrentDate = _lightSensorRepository.GetLastLightSensor().CurrentDate;

                return View(lightSensorModel);
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }
        public IActionResult BarometricSensor()
        {
            try
            {
                var barometricSensorViewModel = new BarometricSensorViewModel();
                barometricSensorViewModel.Sensor.PressureValue = 
                    _barometricSensorRepository.GetLastBarometricSensor().PressureValue;
                barometricSensorViewModel.Sensor.TemperatureValue =
                    _barometricSensorRepository.GetLastBarometricSensor().TemperatureValue;
                barometricSensorViewModel.Sensor.AltitudeValue =
                    _barometricSensorRepository.GetLastBarometricSensor().AltitudeValue;

                barometricSensorViewModel.Sensor.CurrentDate = _barometricSensorRepository.GetLastBarometricSensor().CurrentDate;
                barometricSensorViewModel.Sensors = _barometricSensorRepository.GetAllBarometricSensors();

                return View(barometricSensorViewModel);
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }
        public IActionResult SoilMoistureSensor()
        {
            try
            {
                var soilMoistureSensorModel = new SoilMoistureViewModel();
                soilMoistureSensorModel.Sensor.Value = _soilMoistureSensorRepository.GetLastMoistureSensor().Value;
                soilMoistureSensorModel.Sensors = _soilMoistureSensorRepository.GetAllSoilMoistureSensors();
                soilMoistureSensorModel.Sensor.CurrentDate = _soilMoistureSensorRepository.GetLastMoistureSensor().CurrentDate;

                return View(soilMoistureSensorModel);
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }
        public IActionResult TemperatureSensor()
        {
            try
            {
                var temperatureSensorViewModel = new TemperatureSensorViewModel();
                temperatureSensorViewModel.Sensor.HumidityValue =
                    _temperatureSensorRepository.GetLastTemperatureSensor().HumidityValue;
                temperatureSensorViewModel.Sensor.TemperatureCValue =
                    _temperatureSensorRepository.GetLastTemperatureSensor().TemperatureCValue;
                temperatureSensorViewModel.Sensor.TemperatureFValue =
                    _temperatureSensorRepository.GetLastTemperatureSensor().TemperatureFValue;

                temperatureSensorViewModel.Sensors =
                    _temperatureSensorRepository.GetAllTemperatureSensors();
                temperatureSensorViewModel.Sensor.CurrentDate = _temperatureSensorRepository.GetLastTemperatureSensor().CurrentDate;

                return View(temperatureSensorViewModel);
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }
        public IActionResult WaterLevelSensor()
        {
            try
            {
                var waterLevelViewModel = new WaterLevelViewModel();
                waterLevelViewModel.Sensor.Value = _waterLevelSensorRepository.GetLastWaterLevelSensor().Value;
                waterLevelViewModel.Sensors = _waterLevelSensorRepository.GetAllWaterLevelSensors();
                waterLevelViewModel.Sensor.CurrentDate = _waterLevelSensorRepository.GetLastWaterLevelSensor()
                    .CurrentDate;
              
                return View(waterLevelViewModel);
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
