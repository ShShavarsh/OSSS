using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class Driver_Of_Monitor:Interface_Of_Drivers
    {
        int Interface_Of_Drivers.Input()
        {
            return 0;
        }
        public int Output()
        {
            return 0;
        }

        public int I_O_Ctl()
        {
            return 0;
        }

    }
}
