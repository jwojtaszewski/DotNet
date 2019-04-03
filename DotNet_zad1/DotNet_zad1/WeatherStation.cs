using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication1
{
    [DataContract]   
    class WeatherStation 
    {
        [DataMember]
        static List<Sensor> sensors;

        static void Main(string[] args)
        {
            
            sensors = new List<Sensor>();

            PressureSensor pSensor = new PressureSensor { pressure = 21 };
            TemperatureSensor tSensor = new TemperatureSensor { degrees = "C", temperature = 30,Name="sensor Temp" };
            HumidityNTemperatureSensor htSensor = new HumidityNTemperatureSensor {temperature = 22, degrees = "F", humidity = "good" };

            sensors.Add(pSensor);
            sensors.Add(tSensor);
            sensors.Add(htSensor);

            Console.WriteLine(tSensor.temperature +" "+tSensor.degrees);

           
            Console.WriteLine();
            foreach (Sensor aSensor in sensors)
            {
                if(aSensor is ITemperature){
                    Console.WriteLine(aSensor.Name);

                    }
            }





          //  string content = JsonConvert.SerializeObject(tSensor,Formatting.Indented);
            //File.WriteAllText(@"sensors.json", content);
            //Console.WriteLine(content);

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}