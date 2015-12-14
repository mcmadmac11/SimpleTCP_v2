using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketClient
{






    class Program
    {

        static void Main(string[] args)
        {
           







            //Send accross TCP connection


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
    }
}
