using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class File_Attributes
    {
       // 0=no,1=yes


        byte Read_Only{set;get;}//0 no,1 yes

        byte Read_Write{set;get;}//0 or 1

        byte Special_File{set;get;}//0 or 1

        short Current_Size_Of_Zapis{set;get;}//  ??

        int Create_Time_{set;get;}

        int Last_Access{set;get;}

        int Last_Change{set;get;}

        int Current_Size{set;get;}

        //static int Max_Size{set;get;}//2mb

        byte Exe_Or_Not_Exe{set;get;}

        public void set_attr(byte open_mode,byte protec)//chem manm te es class@ inch interfeysa talis 
        { 

            switch(open_mode)
            {
                case 0:Read_Only=1;Read_Write=0;break;
                case 1:Read_Only=0;Read_Write=0;break;
                case 2:Read_Only=0;Read_Write=1;break;

                default :Read_Only=1;Read_Write=0;break;//mnacac bolor depqerum bacvuma menak kardalu hamar,,kam karanq exception qcenq,esim
            }

            


        
        }

        public  File_Attributes( byte Pr, byte Rd_Onl, byte Wr_Onl, 
            byte Rd_Wr, byte Hid, byte Sys_File, byte Spc_File,short Curr_Sz_Zps,int Crt_Time,int Lst_Acc,int Last_Chng,int Curr_Sz,byte exe)
        { 
          
         Read_Only=Rd_Onl;//0 or 1 
         Read_Write=Rd_Wr;//0 or 1
         Special_File=Sys_File;//0 or 1
         Special_File=Spc_File;//0 or 1
         Current_Size_Of_Zapis=Curr_Sz_Zps;//  ??
         Create_Time_=Crt_Time;
         Last_Access=Lst_Acc;
         Last_Change=Last_Chng;
         Current_Size=Curr_Sz;
         Exe_Or_Not_Exe=exe;

            //te es EZI glux constructor in inchi hamar grim es el chjokim,,hima el apsosum em jnjem :D 
        }

        public File_Attributes() { }

        
    }
}
