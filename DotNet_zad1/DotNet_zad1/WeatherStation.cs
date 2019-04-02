using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class WeatherStation 
    {

        static void Main(string[] args)
        {

            List<Sensor> sensors = new List<Sensor>();

            PressureSensor pSensor = new PressureSensor { pressure = 21 };
            TemperatureSensor tSensor = new TemperatureSensor { degrees = "C", temperature = 30,Name="hejhej" };
            HumidityNTemperatureSensor htSensor = new HumidityNTemperatureSensor {temperature = 22, degrees = "F", humidity = "good" };

            sensors.Add(pSensor);
            sensors.Add(tSensor);
            sensors.Add(htSensor);

            Console.WriteLine(tSensor.temperature +" "+tSensor.degrees);

            Console.WriteLine();
            foreach (Sensor aSensor in sensors)
            {
                Console.WriteLine(aSensor.Name);
            }



            string content = JsonConvert.SerializeObject(sensors);
            File.WriteAllText(@"sensors.json", content);
            Console.WriteLine("Data Stored");

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}