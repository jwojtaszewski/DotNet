using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Measurement
    {
        IDictionary<string, double> Measurments = new Dictionary<string, double>();

        public void addMeasurment(string key, double value) {
            Measurments[key] = value;
        }
    }
}