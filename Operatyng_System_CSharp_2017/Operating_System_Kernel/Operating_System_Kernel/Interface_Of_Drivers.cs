using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    interface Interface_Of_Drivers
    {
        int Input(byte[] arr, int Addres_of_Block, short offset);

        int Output(byte[] buffer, int addres, int size);

        int I_O_Ctl();
    }
}
