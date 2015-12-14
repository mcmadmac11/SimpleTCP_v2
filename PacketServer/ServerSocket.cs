using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PacketServer
{
    public class ServerSocket
    {
        // Incoming data from the client.
        public static Byte[] Packet { get; set; }

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();
                    Packet = null;

                    while (true)
                    {
                     //   bytes = new byte[1024];
                        int bytesRec = 0;
                        try
                        {
                            bytesRec = handler.Receive(bytes);
                            Packet = bytes;
                            // Show the data on the console.
                            Console.WriteLine("Packet Recieved received");
                            Console.WriteLine(Packet);
                        }
                        catch
                        {

                        }
                    //    Packet += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                      //  if (Packet.IndexOf("<EOF>") > -1)
                      //  {
                     //       break;
//}
                    }

                
                
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }
        public static void Main(String[] args)
        {
            StartListening();

        }

    }


}




