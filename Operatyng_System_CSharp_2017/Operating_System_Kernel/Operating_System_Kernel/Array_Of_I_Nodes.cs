using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class Array_Of_I_Nodes
    {

        public static int count_of_frii_i_nods = Super_Block.s_inodes_count;

        public byte[] Bayte_Map_For_I_Nods = new byte[Super_Block.s_inodes_count];

        public I_Node[] Arr_I_Node = new I_Node[Super_Block.s_inodes_count];


    }
}
