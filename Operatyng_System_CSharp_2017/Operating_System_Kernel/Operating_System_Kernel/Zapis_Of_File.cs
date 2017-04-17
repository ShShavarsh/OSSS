using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class Zapis_Of_File
    {   
            // name_of_file;
       public short[] name = new short[15];

        public byte index_of_i_Node_;

        public Zapis_Of_File(byte index)
        {
            index_of_i_Node_ = index;
        }

    }
}
