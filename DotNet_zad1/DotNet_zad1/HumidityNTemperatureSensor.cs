using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 
{
    class HumidityNTemperatureSensor : Sensor,ITemperature, IHumidity
    {
    
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
        public string humidity { get; set; }
    }
}
