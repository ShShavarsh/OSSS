using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    public class Monitor
    {
        public void Output(Byte[] buffer)
        {
            // From byte array to string
            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            Console.WriteLine(s);
        }
    }
}
