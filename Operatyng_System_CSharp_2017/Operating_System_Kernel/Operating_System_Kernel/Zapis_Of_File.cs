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
        short[] name = new short[16];

        int index_of_i_Node_;

        public Zapis_Of_File(int index)
        {
            index_of_i_Node_ = index;
        }

    }
}
