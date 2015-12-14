using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketClient
{
      [Serializable()]
    public class Packet
    {

          public PacketHeader Header { get; set; }
          public Object Data { get; set; }
        

//          Reserved (3 bits)
//    for future use and should be set to zero
//Flags (9 bits) (aka Control bits)
//    contains 9 1-bit flags

//        NS (1 bit) – ECN-nonce concealment protection (experimental: see RFC 3540).
//        CWR (1 bit) – Congestion Window Reduced (CWR) flag is set by the sending host to indicate that it received a TCP segment with the ECE flag set and had responded in congestion control mechanism (added to header by RFC 3168).
//        ECE (1 bit) – ECN-Echo has a dual role, depending on the value of the SYN flag. It indicates:

//            If the SYN flag is set (1), that the TCP peer is ECN capable.
//            If the SYN flag is clear (0), that a packet with Congestion Experienced flag in IP header set is received during normal transmission (added to header by RFC 3168).

//        URG (1 bit) – indicates that the Urgent pointer field is significant
//        ACK (1 bit) – indicates that the Acknowledgment field is significant. All packets after the initial SYN packet sent by the client should have this flag set.
//        PSH (1 bit) – Push function. Asks to push the buffered data to the receiving application.
//        RST (1 bit) – Reset the connection
//       SYN (1 bit) – Synchronize sequence numbers. Only the first packet sent from each end should have this flag set. Some other flags and fields change meaning based on this flag, and some are only valid for when it is set, and others when it is clear.
//        FIN    (1 bit) – No more data from sender

//Windowsize ( 16 bits)
//    the size of the receive window, which specifies the number of window size units (by default, bytes) (beyond the segment identified by the sequence number in the acknowledgment field) that the sender of this segment is currently willing to receive (see Flow control and Window Scaling)
//Checksum (16 bits)
//    The 16-bit checksum field is used for error-checking of the header and data
//Urgent pointer (16 bits)
//    if the URG flag is set, then this 16-bit field is an offset from the sequence number indicating the last urgent data byte
//Options (Variable 0–320 bits, divisible by 32)
//    The length of this field is determined by the data offset field. Options have up to three fields: Option-Kind (1 byte), Option-Length (1 byte), Option-Data (variable). The Option-Kind field indicates the type of option, and is the only field that is not optional. Depending on what kind of option we are dealing with, the next two fields may be set: the Option-Length field indicates the total length of the option, and the Option-Data field contains the value of the option, if applicable. For example, an Option-Kind byte of 0x01 indicates that this is a No-Op option used only for padding, and does not have an Option-Length or Option-Data byte following it. An Option-Kind byte of 0 is the End Of Options option, and is also only one byte. An Option-Kind byte of 0x02 indicates that this is the Maximum Segment Size option, and will be followed by a byte specifying the length of the MSS field (should be 0x04). Note that this length is the total length of the given options field, including Option-Kind and Option-Length bytes. So while the MSS value is typically expressed in two bytes, the length of the field will be 4 bytes (+2 bytes of kind and length). In short, an MSS option field with a value of 0x05B4 will show up as (0x02 0x04 0x05B4) in the TCP options section.
//    Some options may only be sent when SYN is set; they are indicated below as [SYN]. Option-Kind and standard lengths given as (Option-Kind,Option-Length).

//        0 (8 bits) – End of options list
//        1 (8 bits) – No operation (NOP, Padding) This may be used to align option fields on 32-bit boundaries for better performance.
//        2,4,SS (32 bits) – Maximum segment size (see maximum segment size) [SYN]
//        3,3,S (24 bits) – Window scale (see window scaling for details) [SYN][6]
//        4,2 (16 bits) – Selective Acknowledgement permitted. [SYN] (See selective acknowledgments for details)[7]
//        5,N,BBBB,EEEE,... (variable bits, N is either 10, 18, 26, or 34)- Selective ACKnowledgement (SACK)[8] These first two bytes are followed by a list of 1–4 blocks being selectively acknowledged, specified as 32-bit begin/end pointers.
//        8,10,TTTT,EEEE (80 bits)- Timestamp and echo of previous timestamp (see TCP timestamps for details)[9]

//    (The remaining options are historical, obsolete, experimental, not yet standardized, or unassigned)
//Padding
//    The TCP header padding is used to ensure that the TCP header ends and data begins on a 32 bit boundary. The padding is composed of zeros.[10] 
      
        public Packet()
        {
        }

        public List<Byte> SerializePacket()
        {
            List<Byte> serilaizedPacket = new List<byte>();
          serilaizedPacket.AddRange(Header.SourcePort.ToList());
          serilaizedPacket.AddRange(Header.DestinationPort.ToList());
          serilaizedPacket.AddRange(Header.SequenceNumber.ToList());
          serilaizedPacket.AddRange(Header.AcknowlegmentNumber.ToList());
          serilaizedPacket.AddRange(Header.DataOffset.ToList());
          serilaizedPacket.AddRange(Header.Reserved.ToList());
          serilaizedPacket.AddRange(Header.NS.ToList());
          serilaizedPacket.AddRange(Header.CWR.ToList());
          serilaizedPacket.AddRange(Header.ECE.ToList());
          serilaizedPacket.AddRange(Header.URG.ToList());
          serilaizedPacket.AddRange(Header.ACK.ToList());
          serilaizedPacket.AddRange(Header.PSH.ToList());
          serilaizedPacket.AddRange(Header.URG.ToList());
          serilaizedPacket.AddRange(Header.ACK.ToList());
          serilaizedPacket.AddRange(Header.PSH.ToList());
          serilaizedPacket.AddRange(Header.RST.ToList());
          serilaizedPacket.AddRange(Header.SYN.ToList());
          serilaizedPacket.AddRange(Header.FIN.ToList());
          serilaizedPacket.AddRange(Header.Windowsize.ToList());
          serilaizedPacket.AddRange(Header.Checksum.ToList());
            serilaizedPacket.AddRange(Header.UrgentPointer.ToList());
            serilaizedPacket.AddRange(Header.Options.ToList());
            List<Byte> rawData = Marshaller.SerializeExact(Data).ToList();
            serilaizedPacket.AddRange(rawData);

            return serilaizedPacket;
        }
     
    }
}





