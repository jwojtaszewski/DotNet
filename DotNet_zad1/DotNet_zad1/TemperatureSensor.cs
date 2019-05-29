using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    [DataContract]
    class TemperatureSensor : Sensor,ITemperature
    {
        private Boolean tempFlag = false;
        private String tmpDegrees = "";
        
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
                if (tempFlag)
                {
                    tmpDegrees = Degrees;
                }
                Degrees = value;
                tempFlag = true;
            }
        }

        [DataMember(Name="Temperature")]
        private double Temperature;
        public double temperature
        {
            get
            {
                if (tempFlag)
                {
                    if (Degrees.Equals("C") && tmpDegrees.Equals("F"))
                    {
                        Temperature += 270;
                    }
                    else if (Degrees.Equals("F")&& tmpDegrees.Equals("C"))
                    {
                        Temperature -= 270;
                    }
                }

                return Temperature;
            }

            set
            {
                Temperature = value;
            }
        }

        public String getTemperature()
        {
            return temperature + degrees;
        }
        
    }
}
