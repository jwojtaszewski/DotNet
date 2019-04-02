using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Sensor
    {
        private static int nameIterator;
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
            name = "Sensor" + nameIterator.ToString();
        }

    }
}
