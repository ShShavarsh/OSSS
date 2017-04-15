using System;
using System.Collections.Generic;
using System.IO;//FileStream
using System.Text;
using System.Threading;//Volatile

namespace Operating_System_Kernel
{
    partial class Hard_Disk//dashter@,kanstruktornerer@,tiper@ es part um tox linen
    {
        private FileStream Stream { set; get; }

        private string Path { set; get; }


        public class EventArgs_ : EventArgs
        {
            public bool Read_Bool { private set; get; }

            public int Read_Count { private set; get; }

            public byte[] Buf {private set; get; }

            public EventArgs_(bool read, int count,byte[] buf)
            {
                Read_Bool = read;
                Read_Count = count;
                Buf = buf;
            }
        }

        public Hard_Disk(string path = @"D:\HARD_DISK.txt")
        {
            this.Path = path;

            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(path);
                }
                // Create the file.
                Stream = File.Create(path);
            }//end try

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {
                Stream.Close();
            }
        }
    }


    partial class Hard_Disk//Read i het kapvac amen inch tox es masum linen
    {
        public event EventHandler<EventArgs_> reading_end;

        protected virtual void Event_Func_reading_end(EventArgs_ e)
        {
            EventHandler<EventArgs_> temp = Volatile.Read(ref reading_end);
            if (temp != null) temp(this, e);
        }

        public void SimulateEvent_for_reading_end(bool read, int count, byte[] buf)
        {
            // Создать объект для хранения информации, которую нужно передать получателям уведомления
            EventArgs_ e = new EventArgs_(read, count,buf);
            // Вызвать виртуальный метод, уведомляющий объект о событии Если ни один из производных типов не переопределяет этот метод,
            // объект уведомит всех зарегистрированных получателей уведомления
            Event_Func_reading_end(e);
        }

        public void read(long addr, int size)
        {
            int count;

            byte[] vec = new byte[size];

            using (FileStream sr = File.OpenRead(Path))
            {
                /*
               public override long Seek(long offset, SeekOrigin origin)
               addr,Int64
               Указатель относительно начальной точки origin, от которой начинается поиск
               */
                sr.Seek(addr, SeekOrigin.Begin);

                //public virtual void Lock(long position,long length)
                //position
                //Начало диапазона для блокировки. 
                //Значение этого параметра должно быть больше или равно нулю (0).
                //length
                //Диапазон, который нужно блокировать.
                sr.Lock(addr, size);

                // public override int Read(byte[] array,int offset,int count)
                //count= 

                count = sr.Read(vec, 0, size);

                //array
                //При возврате из этого метода содержит указанный массив байтов,
                //в котором значения в диапазоне от offset до (offset + count - 1)) заменены байтами, считанными из текущего источника.
                //offset
                //Смещение в байтах в массиве array, в который будут помещены считанные байты
                //count
                //Максимальное число байтов, предназначенных для чтения.

                //public virtual void Unlock(long position,long length)
                sr.Unlock(addr, size);
                //position
                //Начало диапазона, который должен быть разблокирован.
                //length
                //Диапазон, который должен быть разблокирован.

                try
                {
                    if (count != size)
                    {
                        SimulateEvent_for_reading_end(false, count, vec);//evanta uxarkum vor vochbarehajoxa kardace prce,nor heto exceptiona qcum
                        throw new Exception("can't read from HD expected count of bytes");
                    }
                    else
                        SimulateEvent_for_reading_end(true, count, vec);//eventa uxarkum vor barehajox kardacela prcela
                }
                catch (Exception ob)
                {
                    Console.WriteLine(ob.Message);
                }
            }
            
        }
    }


   

    partial class Hard_Disk //Write i het kapvac ameninch es masuma pahvum
    {
        //sra void utyun@ harci taka
        public void write(long addr, byte[] data)
        {

            using (FileStream wr = File.OpenWrite(Path))
            {
                //public override long Seek(long offset,SeekOrigin origin)
                wr.Seek(addr, SeekOrigin.Begin);
                //addr,Int64
                //Указатель относительно начальной точки origin, от которой начинается поиск
                // SeekOrigin.Begin
                //Задает начальную, конечную или текущую позицию как опорную точку для offset,
                //используя значение типа SeekOrigin

                wr.Lock(addr, data.Length);

                //public override void Write(byte[] array,int offset,int count)
                wr.Write(data, 0, data.Length);

                wr.Unlock(addr, data.Length);

                SimulateEvent_for_writeing(true, data.Length);
            }
        }
            public event EventHandler<EventArgs_> writeing_end;

            protected virtual void Event_Func_writeing_end(EventArgs_ e)
            {
                EventHandler<EventArgs_> temp = Volatile.Read(ref writeing_end);
                if (temp != null) temp(this, e);
            }

             public void SimulateEvent_for_writeing(bool write, int count)
            {
                // Создать объект для хранения информации, которую нужно передать получателям уведомления
                EventArgs_ e = new EventArgs_(write, count,null);
                // Вызвать виртуальный метод, уведомляющий объект о событии Если ни один из производных типов не переопределяет этот метод,
                // объект уведомит всех зарегистрированных получателей уведомления
                Event_Func_writeing_end(e);
            }

        }


    partial class Hard_Disk//handler ner@ tox es partt um linen
    {

        public void add_handler_in_hard_disk(Driver_Of_HD drv_hd)//es funkcianeri anunner@ voroshel@ nervaynacnox processsaaaa
        {
            drv_hd.Event_For_HD_Read += handler_of_read_from_driver;
            drv_hd.Event_For_HD_Write += handler_of_write_from_driver;
        }

        public void handler_of_read_from_driver(object sender,Driver_Of_HD.HD_Read_EventArgs_ e)//esi driver ic ekac read eventi handlerna
        {
           read(e.qani_hat_karda,e.vortexic_sksac_karda);
        }

        public void handler_of_write_from_driver(object sender, Driver_Of_HD.HD_Write_EventArgs_ e)//esi driver ic ekac write eventi handlerna
        {
            write(e.offset,e.buf);
        }
    }

    
}

