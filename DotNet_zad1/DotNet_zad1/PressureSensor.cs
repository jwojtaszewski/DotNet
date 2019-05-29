using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 
{
    [DataContract]
    class PressureSensor : Sensor ,IPressure
    {
        [DataMember(Name="Pressure")]
        public double pressure { get; set; }
    }
}
