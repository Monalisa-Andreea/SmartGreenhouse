using Microsoft.Extensions.Configuration;
using SmartGarden.Repositories;
using System;
using System.Net;
using System.Net.Mail;

namespace SmartGarden.Utils
{
    public class EmailClass
    {
        private readonly IWaterLevelSensorRepository _waterLevelSensorRepository;

        private bool sentEmail = false;

        public EmailClass(IWaterLevelSensorRepository waterLevelSensorRepository)
        {
            _waterLevelSensorRepository = waterLevelSensorRepository;
        }

        internal void SendWaterLevelWarningEmail()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            var smtpClient = new SmtpClient(config["Smtp:Host"])
            {
                Port = int.Parse(config["Smtp:Port"]),
                Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]),
                EnableSsl = true,
            };
           if(sentEmail==true) 
                smtpClient.Send(GetWaterLevelWarningEmail());
        }

        private MailMessage GetWaterLevelWarningEmail()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(config["NegativeMessage:From"]),
                Subject = config["NegativeMessage:Subject"],
                Body = config["NegativeMessage:Body"],
                IsBodyHtml = false,
            };
            mailMessage.To.Add(config["NegativeMessage:To"]);
            return mailMessage;
        }

        internal void CheckWaterLevel()
        {
            bool waterIsEmpty = _waterLevelSensorRepository.GetLastWaterLevelSensor().Value <= 100;
               
            if (sentEmail==false && waterIsEmpty==true)
            {
                sentEmail = true;
                SendWaterLevelWarningEmail();
                Console.WriteLine("Sent mail");
            }
            else
            {
                if (sentEmail==true && waterIsEmpty==false)
                {
                    Console.WriteLine("Reset mail");
                    sentEmail = false;
                }
            }
        }
    }
}
