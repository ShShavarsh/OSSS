using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class File_Attributes
    {

        byte Protection;
        byte Read_Only;//0 or 1 
        byte Write_Only;//0 or 1
        byte Read_Write;//0 or 1
        byte Hidden;//0 or 1
        byte System_File;//0 or 1
        byte Special_File;//0 or 1
        short Size_Of_Zapis;//  ??
        long Create_Time_;
        long Last_Access;
        long Last_Change;
        int Current_Size;
        static int Max_Size;//2mb
        byte Exe_Or_Not_Exe;

    }
}
