using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class Super_Block
    {
        //es bolor dashteri arjeqner@ petqa voroshenq u tenanq ete kan nencner@ vronq petq chen hanenq

        public byte s_inodes_count=100;
       // i-nod-eri qanak,fayleri maximum qanak

        long s_desc_count;//Число индексных дескрипторов в файловой системе

        int Count_Of_Blocks = 102400;//..fayleri qanak * et faylum maximum blockneri qanak
 
        long s_free_index_Descriptors_Count;//Счетчик числа свободных индексных дескрипторов	 

        ulong s_first_data_block;//Первый блок, который содержит данные.?

        byte s_log_block_size=1;//Индикатор размера логического блока: 0 = 1 Кб; 1 = 2 Кб; 2 = 4 Кб	 
	 	
        /*
         * stex petqa lini te vortexa sksum u verchanum free_space_managment@,,
         * i_nodener@ vortexic en sksum u verchanum,,
         * urdeya root katalog
         */
        int begin_byte_cart;//stex grvaca te vortexa hard disk um(faylum)sksum byte_cart i arajin bit@ 
        int end_byte_cart;

        int begin_I_Node_Table;//vortexica sksum i noderi zangvaci arajin bit@
        int end_I_Node_Table;

        int Addr_Root_Catalog;


    }
}
