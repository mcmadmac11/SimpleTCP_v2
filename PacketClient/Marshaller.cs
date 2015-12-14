﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace PacketClient
{
    public class Marshaller
    {

        public static byte[] SerializeExact(object anything)
        {
            int structsize = Marshal.SizeOf(anything);
            IntPtr buffer = Marshal.AllocHGlobal(structsize);
            Marshal.StructureToPtr(anything, buffer, false);
            byte[] streamdatas = new byte[structsize];
            Marshal.Copy(buffer, streamdatas, 0, structsize);
            Marshal.FreeHGlobal(buffer);
            return streamdatas;
        }


        public static object RawDeserialize(byte[] rawdatas, Type anytype)
        {
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length) return null;
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }
    }
}
