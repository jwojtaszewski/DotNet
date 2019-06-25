using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class Server
    {
        private Queue queue;
        public static void Main()
        { 
            TcpListener server=null;   
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while(true) 
                {
                    Console.Write("Waiting for a connection... ");
        
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();            
                    Console.WriteLine("Connected!");
                    
                    
                    Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                    t.Start(client);
                    
                }
            }
            catch(SocketException e)
            
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

      
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }   
        
//        public void FirstThread()
//        {
//            int counter = 0;
//            lock(queue)
//            {
//                while(counter < 1000)
//                {
//                    Monitor.Wait(queue);
//                    queue.Enqueue(counter);
//                    Monitor.Pulse(queue);
//                    counter++;
//                }
//            }
//        }
        
        public static void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;
 
            // sets two streams
            NetworkStream stream = client.GetStream();
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
 

            Byte[] bytes = new Byte[256];
            String data = null;
            int i = 0;


            lock (bytes)
            {
//                Monitor.Wait(bytes);
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Data revived: {0}", data);
                    SaveToJSON(data);

                }
//                Monitor.Pulse(bytes);
            }
            stream.Close();
            client.Close();
        }
        private static void SaveToJSON(String jsonString)
        {
            
            var fileName = @"C:\Users\Kuba\Desktop\JSON_C#\file"+ DateTime.Now.ToString("--dd-MM-yyyyTHHmm") +".json";
            
            using (StreamWriter file = File.CreateText(fileName))
            {
                file.Write(jsonString);
                Console.WriteLine("Data saved correctly ");
            }

        }
        
    }
    
}