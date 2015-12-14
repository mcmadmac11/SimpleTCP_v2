using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketClient
{
    public class PacketHeader
    {
        public Byte[] SourcePort { get; set; }
        public Byte[] DestinationPort { get; set; }
        public Byte[] SequenceNumber { get; set; }
        public Byte[] AcknowlegmentNumber { get; set; }
        public Byte[] DataOffset { get; set; }
        public Byte[] Reserved { get; set; }
        public Byte[] NS { get; set; }
        public Byte[] CWR { get; set; }
        public Byte[] ECE { get; set; }
        public Byte[] URG { get; set; }
        public Byte[] ACK { get; set; }
        public Byte[] PSH { get; set; }
  
        public Byte[] RST { get; set; }
        public Byte[] SYN { get; set; }
        public Byte[] FIN { get; set; }
        public Byte[] Windowsize { get; set; }
        public Byte[] Checksum { get; set; }
        public Byte[] UrgentPointer { get; set; }
        public Byte[] Options { get; set; }

        public PacketHeader()
        {

          
            DestinationPort = new Byte[16];
            SourcePort = new Byte[16];
            SequenceNumber = new Byte[32];
            AcknowlegmentNumber = new Byte[32];
            DataOffset = new Byte[4];
            Reserved = new Byte[4];
            NS = new Byte[4];
            CWR = new Byte[4];
            ECE = new Byte[4];
            URG = new Byte[4];
            ACK = new Byte[4];
            PSH = new Byte[4];
            URG = new Byte[4];
            ACK = new Byte[4];
            PSH = new Byte[4];
            RST = new Byte[4];
            SYN = new Byte[4];
            FIN = new Byte[4];
            Windowsize = new Byte[4];
            Checksum = new Byte[4];
            UrgentPointer = new Byte[4];
            Options = new Byte[4];
        }
     
    }
}
