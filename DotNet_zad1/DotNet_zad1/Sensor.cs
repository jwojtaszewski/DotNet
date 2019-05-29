using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [DataContract]
    public class Sensor
    {
        private static int nameIterator;
        
        public delegate void SensorEventHandler(Object source, Measurement measurement);
        public event SensorEventHandler sensorEvent;
        
        [DataMember(Name="Sensor's Name")]
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 17)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Too long name!");
                }
            }
        }

        public Sensor()
        {
            nameIterator++;
            name = "Sensor_" + nameIterator.ToString();
        }

        public void addMeasurement(String key, double value)
        {
            Measurement measurement = new Measurement();
            measurement.addMeasurment(key,value);
            
            onSensorEvent(measurement);
        }

        protected virtual void onSensorEvent(Measurement measurement)
        {
            if (sensorEvent != null)
            {
                sensorEvent(this, measurement);
            }
            
        }

    }
}
