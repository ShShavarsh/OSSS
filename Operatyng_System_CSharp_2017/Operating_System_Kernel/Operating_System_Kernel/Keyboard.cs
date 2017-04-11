using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    public class Keyboard
    {

        public byte[] Buffer { private set; get; }

        public byte[] Input()
        {
            // From string to byte array
            Buffer = System.Text.Encoding.UTF8.GetBytes(Console.ReadLine());
            return Buffer;
        }
    }
}
