using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
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
//            WeatherStation weatherStation2 = new WeatherStation();
//            
//            tSensor.sensorEvent += weatherStation2.subscribeMeasurement;
//            tSensor.addMeasurement("pres", tSensor.temperature);

            
//            Console.WriteLine(tSensor.);


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
            Connect(tSensor.getTemperature());
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
        
        static void Connect(String message) 
        {
            try 
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                String server = "127.0.0.1";
                TcpClient client = new TcpClient(server, port);
    
                // Translate the passed message into ASCII and store it as a Byte array
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);         

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
    
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                
                // Receive the TcpServer.response.
    
                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
//                Int32 bytes = stream.Read(data, 0, data.Length);
//                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
//                Console.WriteLine("Received: {0}", responseData);         

                // Close everything.
                stream.Close();         
                client.Close();         
            } 
            catch (ArgumentNullException e) 
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            } 
            catch (SocketException e) 
            {
                Console.WriteLine("SocketException: {0}", e);
            }
    
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
        
    }
    
}