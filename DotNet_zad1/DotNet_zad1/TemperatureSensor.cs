using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{

    class TemperatureSensor : Sensor,ITemperature
    {

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


        private double Temperature;
        public double temperature
        {
            get
            {
                if (Degrees.Equals("C"))
                {
                    Temperature+=270;
                }else if (Degrees.Equals("F"))
                {
                    Temperature-=270;
                }
                return Temperature;
            }

            set
            {
                Temperature = value;
            }
        }
    }
}
