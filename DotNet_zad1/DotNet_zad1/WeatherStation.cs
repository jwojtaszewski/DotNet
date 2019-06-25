using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication1
{
    [DataContract]
    [KnownType(typeof(TemperatureSensor))]
    [KnownType(typeof(PressureSensor))]
    [KnownType(typeof(HumidityNTemperatureSensor))]
    class WeatherStation 
    {
        [DataMember(Name="Sensor")]
        private List<Sensor> sensors = new List<Sensor>();

        private List<Measurement> measurements;

        public WeatherStation()
        {

//            PressureSensor pSensor = new PressureSensor { pressure = 21 };
//            TemperatureSensor tSensor = new TemperatureSensor { degrees = "C", temperature = 30,Name="sensor Temp" };
//            HumidityNTemperatureSensor htSensor = new HumidityNTemperatureSensor {temperature = 22, degrees = "F", humidity = "good" };

//            sensors.Add(pSensor);
//            sensors.Add(tSensor);
//            sensors.Add(htSensor);
//            Console.WriteLine(tSensor.getTemperature());
//            measurements  = new List<Measurement>();
        }

        public void subscribeMeasurement(object source, Measurement measurement)
        {
//            measurements.Add(source);
            Console.WriteLine("measurement added:"  );
            
//            foreach (KeyValuePair<string, double> measure in measurements)  
//            {  
//                Console.WriteLine("Key: {0}, Value: {1}",  
//                    measure.Key, measure.Value);  
//            } 
        }

        public void addSensor(Sensor sensor)
        {
            sensors.Add(sensor);
        }

    }
}