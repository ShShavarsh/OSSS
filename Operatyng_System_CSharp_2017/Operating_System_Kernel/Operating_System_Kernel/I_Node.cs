using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class I_Node
    {


        public static int count_of_block_addres = 1013;

        public File_Attributes attributes ;

        public int[] block_addres;

        public Record_Of_File[] arr;
       

        public I_Node(byte Flag_File_Katalog) 
        {
           
            Array_Of_I_Nodes.count_of_frii_i_nods--;
            attributes = new File_Attributes();


            if (Flag_File_Katalog == 0)
            {

                block_addres = new int[count_of_block_addres];
                for(int i=0;i< count_of_block_addres; i++)
                {
                    block_addres[i] = -1; 
                }


            }
            else
            {

                arr = new Record_Of_File[Array_Of_I_Nodes.count_of_frii_i_nods];

            }
           

        }

       
        //mer os um fayli chap@ kara lini maximum 2mb==2^21b
        //mer os um blocki chap@ klini 2kb=2^11b

        //mer hard diski i verchin bloki hascen tiva vor@ poqra int_max ic dra hamar zangvaci tim@ int a

    }
}
