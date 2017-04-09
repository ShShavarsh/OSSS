using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class I_Node
    {
   
        File_Attributes attributes = new File_Attributes();

        int[] block_addres = new int[1013];

        //i_node i chap@ vopshm hamarya 2 bloka anum

        public I_Node(byte mode,byte protec=0,byte Hidd=0) 
        {
            attributes.set_attr(mode,protec,Hidd);
        }

        //mer os um fayli chap@ kara lini maximum 2mb==2^21b
        //mer os um blocki chap@ klini 2kb=2^11b

        //mer hard diski i verchin bloki hascen tiva vor@ poqra int_max ic dra hamar zangvaci tim@ int a

    }
}
