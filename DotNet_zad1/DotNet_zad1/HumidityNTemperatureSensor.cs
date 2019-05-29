using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 
{
    [DataContract]
    class HumidityNTemperatureSensor : Sensor,ITemperature, IHumidity
    {
        [DataMember(Name="Temperature")]
        private double Temperature;
        public double temperature
        {
            get
            {
                if (Degrees.Equals("C"))
                {
                    Temperature += 270;
                }
                else if (Degrees.Equals("F"))
                {
                    Temperature -= 270;
                }
                return Temperature;
            }

            set
            {
                Temperature = value;
            }
        }
        [DataMember(Name="Degrees")]
        private string Degrees;
        public string degrees
        {
            get
            {
                return Degrees + "-degrees";
            }

            set
            {
                Degrees = value;
            }
        }
        [DataMember(Name="Humidity")]
        public string humidity { get; set; }
    }
}
