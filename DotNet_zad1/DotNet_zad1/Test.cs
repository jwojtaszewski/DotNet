using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Sensor sensor = new Sensor();
            //---------------------------------------------------------
            TemperatureSensor tSensor = new TemperatureSensor { degrees = "C", temperature = 30,Name="sensor Temp" };
            
            WeatherStation weatherStation = new WeatherStation();

            tSensor.sensorEvent += weatherStation.subscribeMeasurement;
            tSensor.addMeasurement("temp", tSensor.temperature);
            
            //-----------------------------------------------------------
//            PressureSensor pSensor = new PressureSensor { pressure = 21 };
            WeatherStation weatherStation2 = new WeatherStation();
            
            tSensor.sensorEvent += weatherStation2.subscribeMeasurement;
            tSensor.addMeasurement("pres", tSensor.temperature);

            
            Console.WriteLine();


            //--------------------------------------------------------------
            
//            weatherStation.addSensor(sensor);
            
//            Sensor sensorTest = new PressureSensor {pressure = 1222};
//            Sensor sensorTest2 = new TemperatureSensor() {temperature = 35};
//            weatherStation.addSensor(sensorTest);
//            weatherStation.addSensor(sensorTest2);
            
//            Console.WriteLine("---------------------------");
//            weatherStation.getSenor("pressure");
//
//            Console.WriteLine("\n--------------------------");
//            List<ITemperature> SensorList = weatherStation.getSensorBySpecyficValue(10);
//            foreach (var temperature in SensorList)
//            {
//                Console.WriteLine(temperature);
//                
//            }

            periodicSave(weatherStation);
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SaveToJSON(WeatherStation station)
        {
            WeatherStation weatherStation = station;
            
            var stream1 = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(weatherStation.GetType());
            
            serializer.WriteObject(stream1,weatherStation);
            
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string jsonString = sr.ReadToEnd();
            

            var fileName = @"C:\Users\Kuba\Desktop\JSON_C#\file"+ DateTime.Now.ToString("--dd-MM-yyyyTHHmm") +".json";
            Console.WriteLine(fileName);
            

            using (StreamWriter file = File.CreateText(fileName))
            {
                file.Write(jsonString);
            }
        }

        private static void periodicSave(WeatherStation station)
        {
            var task = Task.Run(async () => {
                for(;;)
                {
                    Console.WriteLine("file save");
                    await Task.Delay(10000);
                    SaveToJSON(station);
                }
            });
        }
        
    }
    
}