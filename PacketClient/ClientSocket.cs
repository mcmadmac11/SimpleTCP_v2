using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PacketClient
{
    public class ClientSocket
    {
        public static void StartClient() {

            Packet packet = new Packet();
            PacketHeader header = new PacketHeader();
            //build source port
            Byte[] sourcePort = new Byte[16];
            String sourceport = "340";

            sourcePort = convertToByte(sourceport, sourcePort.Length);
            header.SourcePort = sourcePort;

            Byte[] destinatioPort = new Byte[16];
            String destinationport = "341";
            destinatioPort = convertToByte(destinationport, destinatioPort.Length);
            header.DestinationPort = destinatioPort;
                        
            Byte[] SequenceNumber = new Byte[32];
            String sequenceNumString = "321";
            SequenceNumber = convertToByte(sequenceNumString, SequenceNumber.Length);
            header.SequenceNumber = SequenceNumber;

            Byte[] AcknowledgementNumber = new Byte[32];
            string AckNumber = "234";
            AcknowledgementNumber = convertToByte(AckNumber, AcknowledgementNumber.Length);
            header.AcknowlegmentNumber = AcknowledgementNumber;

            Byte[] DataOffset = new Byte[32];
            String DataOffsetString = "123";
            DataOffset = convertToByte(DataOffsetString, DataOffset.Length);

            Byte[] NS = new Byte[1];
            String NSString = "1";
            NS = convertToByte(NSString, NS.Length);
            header.NS = NS;

            Byte[] CWR = new Byte[1];
            String CWRString = "3";
            NS = convertToByte(CWRString, CWR.Length);
            header.CWR = CWR;

            Byte[] ECE = new Byte[1];
            String ECEString = "1";
            ECE = convertToByte(ECEString, ECE.Length);
            header.ECE = ECE;

            Byte[] URG = new Byte[1];
            String URGString = "1";
            URG = convertToByte(URGString, URG.Length);
            header.URG = URG;

            Byte[] ACK = new Byte[1];
            String ACKString = "1";
            ACK = convertToByte(ACKString, ACK.Length);
            header.ACK = ACK;

            Byte[] PSH = new Byte[1];
            String PSHString = "1";
            PSH = convertToByte(PSHString, PSH.Length);
            header.PSH = PSH;

            Data data = new Data();
            data.val2 = 5;



            packet.Data = data;
            packet.Header = header;

            List<Byte> results = packet.SerializePacket();



        // Data buffer for incoming data.
        byte[] bytes = new byte[1024];

        // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,11000);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp );

            // Connect the socket to the remote endpoint. Catch any errors.
            try {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());

              

                // Send the data through the socket.
                int bytesSent = sender.Send(results.ToArray());

             

                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            } catch (ArgumentNullException ane) {
                Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
            } catch (SocketException se) {
                Console.WriteLine("SocketException : {0}",se.ToString());
            } catch (Exception e) {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        } catch (Exception e) {
            Console.WriteLine( e.ToString());
        }
    }

        public static Byte[] convertToByte(String input, int size)
        {
            int pos = 0;
            Byte[] results = new Byte[size];
            foreach (char s in input.ToArray())
            {
                Byte values = Convert.ToByte(s); //unhandled exception, value either too large or too small

                results[pos] = values;
                pos++;
            }

            return results;
        }


        public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }

    }
}



