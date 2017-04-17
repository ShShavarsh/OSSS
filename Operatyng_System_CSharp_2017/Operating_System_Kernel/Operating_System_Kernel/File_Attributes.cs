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


        
        public byte Special_File{set;get;}//0 or 1   katalog te sovorakan fail

        public int Create_Time_{set;get;}//

        public int Last_Access{set;get;}//erba bacvel

        public int Last_Change {set;get;}//popoxvel

        public int Current_Size {set;get;}//fili nerka blokneri qanak@

        //static int Max_Size{set;get;}//2mb

        public byte Exe_Or_Not_Exe{set;get;}//katarvoxa te che

        public void set_attr(byte open_mode)//chem manm te es class@ inch interfeysa talis 
        { 

           
        }

        public  File_Attributes(  byte Spc_File,int Crt_Time,int Lst_Acc,int Last_Chng,int Curr_Sz,byte exe)          
        { 
          
         
         Special_File=Spc_File;//0 or 1
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
