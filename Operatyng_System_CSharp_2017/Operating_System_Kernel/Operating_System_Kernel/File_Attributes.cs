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

        byte Protection{set;get;}

        byte Read_Only{set;get;}//0 no,1 yes

        byte Write_Only{set;get;}//0 or 1

        byte Read_Write{set;get;}//0 or 1

        byte Hidden{set;get;}//0 or 1

        byte System_File{set;get;}//0 or 1

        byte Special_File{set;get;}//0 or 1

        short Current_Size_Of_Zapis{set;get;}//  ??

        long Create_Time_{set;get;}

        long Last_Access{set;get;}

        long Last_Change{set;get;}

        int Current_Size{set;get;}

        int Max_Size{set;get;}//2mb

        byte Exe_Or_Not_Exe{set;get;}

        public void set_attr(byte open_mode,byte hid,byte protec)
        { 
            if(protec==0 || protec==1)
                Protection=protec;//0 no,1 yes
            else Protection=1;//bolor en depqerum erb trvaca linelu urish tiv fayli pashtpanvacutyun@ darnuma 1,kam exception :D

            switch(open_mode)
            {
                case 0:Read_Only=1;Write_Only=0;Read_Write=0;break;
                case 1:Read_Only=0;Write_Only=1;Read_Write=0;break;
                case 2:Read_Only=0;Write_Only=0;Read_Write=1;break;

                default :Read_Only=1;Write_Only=0;Read_Write=0;break;//mnacac bolor depqerum bacvuma menak kardalu hamar,,kam karanq exception qcenq,esim
            }

            if (hid == 0 || hid == 1)
                Hidden = hid;
            else Hidden = 0;//mnacac bolor depqerum hidden chi,,es tipi else ner@ karanq chgrenq
            //default C# um 0 a grvum mechner@ bayc grel em vor parz lini,ete uzum eq karaq optmizaacianer aneq :D 


        
        }

        public  File_Attributes( byte Pr, byte Rd_Onl, byte Wr_Onl, 
            byte Rd_Wr, byte Hid, byte Sys_File, byte Spc_File,short Curr_Sz_Zps,long Crt_Time,long Lst_Acc,long Last_Chng,int Curr_Sz,byte exe)
        { 
          Protection=Pr;
         Read_Only=Rd_Onl;//0 or 1 
         Write_Only=Wr_Onl;//0 or 1
         Read_Write=Rd_Wr;//0 or 1
         Hidden=Hid;//0 or 1
         System_File=Sys_File;//0 or 1
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
