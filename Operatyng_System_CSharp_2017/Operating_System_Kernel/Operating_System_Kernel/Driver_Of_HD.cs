using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;




namespace Operating_System_Kernel
{
     partial class Driver_Of_HD:Interface_Of_Drivers
    {


         public Driver_Of_HD()
         {
            // x.ev += handler_of_hard_Disk_Write;

         }

        public class  HD_Write_EventArgs_:EventArgs
        {
            public byte[] arr;
            public int OFFSET;
            public HD_Write_EventArgs_(byte[] vec,int ofs)
            {
                arr = vec;
                OFFSET = ofs;
            }

        }

        public event EventHandler<HD_Write_EventArgs_> Event_For_HD_Write;

        protected virtual void Event_Func_Write(HD_Write_EventArgs_ e)
        {
            EventHandler<HD_Write_EventArgs_> temp=Volatile.Read(ref Event_For_HD_Write);
            if (temp != null)
                temp(this, e);
        }

        void Simulate_Event_Write(byte[] arr, int offset)
        {
            HD_Write_EventArgs_ e = new HD_Write_EventArgs_(arr, offset);
            Event_Func_Write(e);
        }

        public int Input(byte[] arr,int Addres_of_Block,short offset)
        {
            //offset @ en oskakan ofseti mnacordna eli......by Mesrop :D 
            Simulate_Event_Write(arr, Addres_of_Block + offset);
            return 0;
        }


        public void handler_of_hard_Disk_Write(object sender, EventArgs e)
        { 
        //handlinga anum vopshm
            //some code

            /*
             vorpeszi es funkician karana obrabotka ani hard  diski write funkicayum trcrac event@,
             * petqa vor es Driver_Of_HD obekt@ grancvi hard_disk obekti eventin
             * harcerii depqum grel obshi chatum. :D 
             * */
        }


     }






    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    partial class Driver_Of_HD:Interface_Of_Drivers
    {

        public class HD_Read_EventArgs_ : EventArgs
        {
            byte[] arr;
            int addr;
            int size;

            public HD_Read_EventArgs_(byte[] arr,int addr,int size)
            {
                this.addr = addr;
                this.arr = arr;
                this.size = size;
            }

            public override string ToString()
            {
                return String.Format("{0},arr {1},addr {2},size {3}",base.ToString(),arr,addr,size);
            }
        }



        public event EventHandler<HD_Read_EventArgs_> Event_For_HD_Read;

        protected virtual void Event_Func_Read(HD_Read_EventArgs_ e)
        {
            EventHandler<HD_Read_EventArgs_> temp = Volatile.Read(ref Event_For_HD_Read);
            if (temp != null)
                temp(this, e);
        }

        void Simulate_Event_Read(byte[] arr, int addr,int size)
        {
            HD_Read_EventArgs_ e = new HD_Read_EventArgs_(arr,addr,size);
            Event_Func_Read(e);
        }
        
        public int Output(byte[] buffer,int addres,int size)
        {
            Simulate_Event_Read(buffer,addres,size);
            return 0;
        }

        public void handler_of_hard_Disk_Read(object sender, EventArgs e)
        {
            //handlinga anum vopshm
            //some code

            /*
             vorpeszi es funkician karana obrabotka ani hard  diski read funkicayum trcrac event@,
             * petqa vor es Driver_Of_HD obekt@ grancvi hard_disk obekti eventin
             * harcerii depqum grel obshi chatum. :D 
             * */
        }
       


    }


    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    partial class Driver_Of_HD : Interface_Of_Drivers
    {
        public int Interface_Of_Drivers.I_O_Ctl()
        {
            return 0;
        }
    }
}
