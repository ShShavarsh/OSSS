using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;




namespace Operating_System_Kernel
{

     partial class Driver_Of_HD:Interface_Of_Drivers//Driveri en masna vor@ eventa krakum vorpeszi hard diski vra grvi
    {//++++++++++++++++++++++++++++++++++++++++++++++++++++
        public event EventHandler<HD_Write_EventArgs_> Event_For_HD_Write;

        protected virtual void Event_Func_Write(HD_Write_EventArgs_ e)
        {
            EventHandler<HD_Write_EventArgs_> temp=Volatile.Read(ref Event_For_HD_Write);
            if (temp != null)
                temp(this, e);
        }

        void Simulate_Event_Write_In_HD(byte[] arr, int offset)
        {
            HD_Write_EventArgs_ e = new HD_Write_EventArgs_(arr, offset);
            Event_Func_Write(e);
        }

        public int Input(byte[] arr,int Addres_of_Block,short offset)//etninput in piti kanchi faylyin hamakargi eventi abrabotchik@
        {
            //offset @ en iskakan ofseti mnacordna eli......by Mesrop :D 
            Simulate_Event_Write_In_HD(arr, Addres_of_Block + offset);
            return 0;
        }
     }/////////vrodi normalaaaaa

   


















     partial class Driver_Of_HD : Interface_Of_Drivers//esi driveri en masna vor@ eventa krakum vorpeszi kardacvi hard dikicc
         //hard disk@ kkarda,,kardacac@ kdni inch vor byte[] i mech u kkraki+++++++++++++++++++++++++++
     {

         public event EventHandler<HD_Read_EventArgs_> Event_For_HD_Read;

         protected virtual void Event_Func_Read(HD_Read_EventArgs_ e)
         {
             EventHandler<HD_Read_EventArgs_> temp = Volatile.Read(ref Event_For_HD_Read);
             if (temp != null)
                 temp(this, e);
         }

         void Simulate_Event_Read_from_HD(int addr, int size)
         {
             HD_Read_EventArgs_ e = new HD_Read_EventArgs_(addr, size);
             Event_Func_Read(e);
         }



         public int Output(int addres, int size)//kardal hd ic sksac addres erord byte ic size hat
         {
             Simulate_Event_Read_from_HD(addres, size);
             return 0;
         }

     }













   



partial class Driver_Of_HD : Interface_Of_Drivers//hard diski eventnerin obrabotka anox funkcianern en grvas stex
{                                                //+++++++++++++++++++++++
    
    public void handler_of_hard_disk_read(object sender,Hard_Disk.EventArgs_ e)
    {
        byte[] buf=e.Buf;
        bool result_bool=e.Read_Bool;
        int count=e.Read_Count;

    }

    public void handler_of_hard_disk_write(object sender, Hard_Disk.EventArgs_ e)
    {
        byte[] buf = e.Buf;
        bool result_bool = e.Read_Bool;
        int count = e.Read_Count;

    }
    
}












    partial class Driver_Of_HD : Interface_Of_Drivers//Eventargseri tiperi masna voronq petq en in nfo i kargov hard diskin
    {                                                    //++++++++++++++++++++++++++

        public class HD_Read_EventArgs_ : EventArgs//es info i mijocov kardacvelua hard diskic
            //kardaluc heto hard disk@ kdni kardacac@ buf i mech u kkraki
        {

            public int vortexic_sksac_karda;
            public int qani_hat_karda;
            
           

            public HD_Read_EventArgs_(int vortuc,int shqaam)
            {
                vortexic_sksac_karda = vortuc;
                qani_hat_karda  =shqaam;
            }
        }

        public class HD_Write_EventArgs_ : EventArgs//en infona vori mijocov grvelua hard diski vra
        {
            public byte [] buf;
            public int offset;

            public HD_Write_EventArgs_(byte[] arr, int ofset)
            {
                buf = arr;
                offset = ofset;
            }

        }

    }











    partial class Driver_Of_HD//es masum kgrancvenq file systemi eventneri hamar
        //u handlerner@ ksarqenq, obrabotka kanenq:D 
    { 
    
        public void add_handler_for_events_of_file_system(File_System fs)
        {
            fs.event_for_read_from_HD += handler_of_eventsForRead_frim_File_system;

            fs.event_for_write_in_HD += handler_of_eventsForWrite_frim_File_system;
        }

        public void handler_of_eventsForRead_frim_File_system(object sender, File_System.info_for_read_in_hard_diskEventArgs e)
        {

            e.Block_Address;
            e.Offset;
            e.Size;
            
            //es info ov petqa kraki event  vor@ kbrni hard diski obrabotchik@
        }

        public void handler_of_eventsForWrite_frim_File_system(object sender,File_System.info_for_write_in_hard_diskEventArgs e)
        {
            
            
            e.Block_Address;
            e.Buffer;
            e.Offset;
            //es info ov petqa kraki event  vor@ kbrni hard diski obrabotchik@
        }
    }












    partial class Driver_Of_HD : Interface_Of_Drivers//xar@ baner en ste
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
    {
        public Driver_Of_HD()
        {
        }

        public void add_handler_hard_disk(Hard_Disk hd)
        {
            hd.writeing_end += handler_of_hard_disk_write;
            hd.reading_end  += handler_of_hard_disk_read;
        }


        int Interface_Of_Drivers.I_O_Ctl()
        {
            return 0;
        }
    }

















    partial class Driver_Of_HD : Interface_Of_Drivers//handlerner file systemi hamar,,------------------------------
    {
        public void handler_of_hard_Disk_Write(object sender, Hard_Disk.EventArgs_ e)
        {
            //some code
            HD_Write_EventArgs_ E = new HD_Write_EventArgs_();//es E i tip@ urish piti lini vapshe,,eti faylayin hamakar
            //gin info uxarkelu hamara
            fire_an_event_write(E);//ese petqa brni faylayin hamakarg@

        }

        public void handler_of_hard_Disk_Read(object sender, Hard_Disk.EventArgs_ e)
        {
            //handleing a anum vopshme
            //some code
            HD_Read_EventArgs_ E = new HD_Read_EventArgs_(e.Read_Bool, e.Read_Count, e.Buf);//es E i tip@ lrriv urish a..faylayin hamakargi hamara
            fire_an_event_write(E);//esi petqa brni faylayin hamakarg@
        }

    }






    partial class Driver_Of_HD//fyile system in event uxarkelu eventargs er@ tox ste linen
    {
        public class end_writeing_in_hard_diskEventArgs : EventArgs
        {

            public bool bool_write;
            public int count_byte;

            public end_writeing_in_hard_diskEventArgs(bool how_write,int count)
            {
                bool_write = how_write;
                count_byte = count;
            }
        }

        public class end_reading_from_hard_diskEventArgs : EventArgs
        {

            public byte[] buf;

            public end_reading_from_hard_diskEventArgs(byte [] buff)
            {
                buf = buff;
            }

        }

    }








    partial class Driver_Of_HD : Interface_Of_Drivers//kardalu event krakelu masna stex file systemi hamar
    {

        public event EventHandler<end_reading_from_hard_diskEventArgs> read_event;//driverna event krakum

        protected virtual void fire_an_event_read(end_reading_from_hard_diskEventArgs e)
        {
            EventHandler<end_reading_from_hard_diskEventArgs> temp = Volatile.Read(ref read_event);
            if (temp != null)
                temp(this, e);//krakum enq event faylayin hamakargi hamar orinak,, aselov vor kardacel enq kardacel enq ,
        }
        void SimulateEvent_read_event_( byte[] buf)
        {
            end_reading_from_hard_diskEventArgs e = new end_reading_from_hard_diskEventArgs(buf);

            fire_an_event_read(e);
             
        }
        
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public event EventHandler<end_writeing_in_hard_diskEventArgs> write_event;//eti en eventna vor@ krakvelua erb
        //uzum enq  orinak filesystemin asenq vor gre prcel enq grel@ hard diski vra
        //vorpes info ktanq te vonc enq gre u inchqan byte enq gre
        protected virtual void fire_an_event_write(end_writeing_in_hard_diskEventArgs e)
        {
            EventHandler<end_writeing_in_hard_diskEventArgs> temp = Volatile.Read(ref write_event);
            if (temp != null)
                temp(this, e);//krakvav
        }

        void Simulate_write_event(bool t, int count)
        {
            end_writeing_in_hard_diskEventArgs e = new end_writeing_in_hard_diskEventArgs(t, count);

            fire_an_event_write(e);
        }
    }
}
