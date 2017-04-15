﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleToAttribute("Operating_System_User_Space")]
//ay es atribut@ kirarelov menq Operating_System_User_Space assemblyn  sarqum enq mer es assembly in @nker
// u Operating_System_User_Space assembly um tesaneli en linelu mer es essembly i internal classner@
//mer es zborkayi bolor classneri tesaneliutyan tiruyt@ nshvac chi vorovhetev C# um defaylt Internal a
//thanks for reading :D ,bye

namespace Operating_System_Kernel
{
    partial class File_System//EVENTARGS-ern ennnnnnnnnnn 
    {

        public class info_for_read_in_hard_diskEventArgs : EventArgs
        {
            public int Block_Address { private set; get; }
            public int Offset { private set; get; }
            public int Size { private set; get; }

            public info_for_read_in_hard_diskEventArgs(int bl_addr, int offs,int size)
            {
                Block_Address = bl_addr;
                Offset=offs;
                Size = size;
            }
        }

        public class info_for_write_in_hard_diskEventArgs : EventArgs
        {
            public int Block_Address{private set;get;}
            public int Offset{private set;get;}
            public byte[] Buffer{private set;get;}

            public info_for_write_in_hard_diskEventArgs(int bl_addr,int offs,byte [] buf)
            {
                Block_Address = bl_addr;
                Offset = offs;
                Buffer = buf;
            }
        }

        
    }//end partial











    partial class File_System//eventnern en file systemi voronq krakvum en hard diski driveri hamar
    {

        public event EventHandler<info_for_read_in_hard_diskEventArgs> event_for_read_from_HD;

        protected virtual void event_func_for_read_from_HD(info_for_read_in_hard_diskEventArgs e)
        {
            EventHandler<info_for_read_in_hard_diskEventArgs> temp = Volatile.Read(ref event_for_read_from_HD);
            if (temp != null)
                temp(this,e);
        }

        void Simulate_event_for_read_in_HD(int bl_addr, int offs, int size)
        {
            info_for_read_in_hard_diskEventArgs e = new info_for_read_in_hard_diskEventArgs(bl_addr,offs,size);

            event_func_for_read_from_HD(e);
        }





        public event EventHandler<info_for_write_in_hard_diskEventArgs> event_for_write_in_HD;

        protected virtual void event_func_for_write_in_HD(info_for_write_in_hard_diskEventArgs e)
        {
            EventHandler<info_for_write_in_hard_diskEventArgs> temp = Volatile.Read(ref event_for_write_in_HD);

            if (temp != null)
                temp(this, e);
        }

        void Simulate_event_for_write_in_HD(int bl_addr, int offs, byte[] buf)
        {
            info_for_write_in_hard_diskEventArgs e = new info_for_write_in_hard_diskEventArgs(bl_addr,offs,buf);

            event_func_for_write_in_HD(e);
        }

    }//end partial





    partial class File_System//es masum klinen driver ic krakvac 2 eventneri handlerner@
        //vorpeszi es erku handlerner@ karanan obrabotka anen  iranc hamapatasxan eventnr@ iranq petqa grancven eventi hamar
        //grancum@ kanenq funkciayi mijocov,tes nerqev@
    {
        public void add_handlers_for_driver_events(Driver_Of_HD drv)
        {
            
           drv.read_event += handler_of_event_from_driver_end_reading_event;
           drv.write_event += handler_of_event_from_driver_end_writeing_event;
        }


        public void handler_of_event_from_driver_end_writeing_event(object sender,Driver_Of_HD.end_writeing_in_hard_diskEventArgs e)
        { 
        
            /*uremn es funkciayum
             * arden hasanelia
             * te qani byte a grve
             * diski vra u true te false a,
             * aysinqn hajoxa avartve te che
             * grelu process@
             * */
            bool t = e.bool_write;
            int count = e.count_byte;
            //@hn de inch vor petqa karas anes es info i het,,
            //orinak event ov hanes verev ,,cherez interface_of_sys_calls,
            //heto vopshm uzer space 
        }

        public void handler_of_event_from_driver_end_reading_event(object sender,Driver_Of_HD.end_reading_from_hard_diskEventArgs  e)
        {

            byte[] buffer = e.buf;
            /*
             * @hn arden file system um unes driveri eventi mijocov buffer@  vortex grvela hard diskic kardacvac informacian
             * inch or petqa karas anes het@
             */

        }
    }//handlerner@ grancinq event@ brnelu en erb krakvav :D 





    partial class File_System
    {
        Super_Block superblok = new Super_Block();
        Information_Of_Free_Blocks bitavaya_karta = new Information_Of_Free_Blocks();

        public File_System()
        { 
        
        }
        

// Create (Создать).
//Создает файл без данных. Цель вызова состоит в объявлении
//о появлении нового файла и установке ряда атрибутов.
        public short Cr_File(string name,byte mode)
        {
            I_Node i_node = new I_Node(mode);
           // hima petqa tanenq es i_node i parunakutyun@ hard diski vra grenq u et graci arajin biti hascen grenq
           //I_Node_Table.array_Of_I_Nodes[counter] um

            return 0;
           // return file_Deskriptor;
        }

//Delete (Удалить). Когда файл больше не нужен, его нужно удалить, чтобы освобо-
//дить дисковое пространство. Именно для этого и предназначен этот системный
//вызов.
        public void Del_File(int fd)
        { 
        
        }

//Open (Открыть). Перед использованием файла процесс должен его открыть. Цель
//системного вызова open — дать возможность системе извлечь и поместить в опера-
//тивную память атрибуты и перечень адресов на диске, чтобы ускорить доступ к ним
//при последующих вызовах.
        public short open(string name, byte mode)
        {
            return 0;
           // return file_deskriptor;
        }

//Close (Закрыть). После завершения всех обращений к файлу потребность в его
//атрибутах и адресах на диске уже отпадает, поэтому файл должен быть закрыт,
//чтобы освободить место во внутренней таблице. Многие системы устанавливают
//максимальное количество открытых процессами файлов, определяя смысл суще-
//ствования этого вызова. Информация на диск пишется блоками, и закрытие файла
//вынуждает к записи последнего блока файла, даже если этот блок и не заполнен.
        public void close(short fd)
        { 
        //some code
        }

//Read (Произвести чтение). Считывание данных из файла. Как правило, байты по-
//ступают с текущей позиции. Вызывающий процесс должен указать объем необхо-
//димых данных и предоставить буфер для их размещения.
        public int read(short fd,byte [] buffer,int byf_size)
        { 
        //some code

            return 0;
            //return read_count;
        }

//Write (Произвести запись). Запись данных в файл, как правило, с текущей позиции.
//Если эта позиция находится в конце файла, то его размер увеличивается. Если теку-
//щая позиция находится где-то в середине файла, то новые данные пишутся поверх
//существующих, которые утрачиваются навсегда.
        public int write(short fd,byte[] buf,int rd_count)
        { 
            
            
            //some code
            return 0;
       // return wt_count;
        }


//Get attributes (Получить атрибуты). Процессу для работы зачастую необходимо
//считать атрибуты файла. К примеру, имеющаяся в UNIX программа make обычно
//используется для управления проектами разработки программного обеспечения,
//состоящими из множества сходных файлов. При вызове программа make проверяет
//время внесения последних изменений всех исходных и объектных файлов и для
//обновления проекта обходится компиляцией лишь минимально необходимого ко-
//личества файлов. Для этого ей необходимо просмотреть атрибуты файлов, а именно
//время внесения последних изменений.

        public File_Attributes Get_Attr(short fd)
        {
            File_Attributes ob = new File_Attributes();
            return ob;
        }
// Set attributes (Установить атрибуты). Значения некоторых атрибутов могут уста-
//навливаться пользователем и изменяться после того, как файл был создан. Такую
//возможность дает именно этот системный вызов. Характерным примером может
//послужить информация о режиме защиты. Под эту же категорию подпадает боль-
//шинство флагов.
        public void Set_Attr(File_Attributes attr)
        { 
        
        }

//////////////////////////////////////////////////////////////////////////////////////////////////sksuma kataloog@

//Create (Создать каталог). Каталог создается пустым, за исключением точки и двой-
//ной точки, которые система помещает в него автоматически (или в некоторых
//случаях при помощи программы mkdir).

        public int mkdir(string pathname, byte mode)
        {
            //Созданный каталог принадлежит фактическому владельцу
            //процесса

           // При успешном завершении mkdir возвращаемое значение равно
            //нулю, в случае ошибки возвращается -1 

            return 0;
        }

//Delete (Удалить каталог). Удалить можно только пустой каталог. Каталог, содержа-
//щий только точку и двойную точку, рассматривается как пустой, поскольку они не
//могут быть удалены.
        public int rmdir(string pathname)
        {
            //rmdir удаляет каталог, который должен быть пустым.

            //В случае успешного завершения вызова возвращается нулевое
            //значение. При ошибке возвращается -1,

            return 0;
        }


//Opendir (Открыть каталог). Каталоги могут быть прочитаны. К примеру, для вы-
//вода имен всех файлов, содержащихся в каталоге, программа ls открывает каталог
//для чтения имен всех содержащихся в нем файлов. Перед тем как каталог может
//быть прочитан, он должен быть открыт по аналогии с открытием и чтением файла.
        public short open_dir(string name, byte mode)
        {
            return 0;
           // return deskriptor;
        }
//Closedir (Закрыть каталог). Когда каталог прочитан, он должен быть закрыт, чтобы
//освободить пространство во внутренних таблицах системы.

        public void close_dir(short fd)
        {
        
        }

//Readdir (Прочитать каталог). Этот вызов возвращает следующую запись из от-
//крытого каталога. Раньше каталоги можно было читать с помощью обычного
//системного вызова read, но недостаток такого подхода заключался в том, что про-
//граммист вынужден был работать с внутренней структурой каталогов, о которой
//он должен был знать заранее. В отличие от этого, readdir всегда возвращает одну
//запись в стандартном формате независимо от того, какая из возможных структур
//каталогов используется.

       public int readdir(short fd)//, dirent  dirp)
       {
           
           /*
            readdir записывает одну структуру dirent из каталога,
            заданного fd , в область памяти, указанную dirp. Параметр
            count игнорируется; почти всегда считывается одна
            структура dirent.
            Структура dirent определена следующим образом:
           */


        /*
        struct dirent
        {
            long d_ino; // номер inode 
            off_t d_off; // смещение на dirent 
            unsigned short d_reclen;// /* длина d_name 
            char d_name [NAME_MAX+1];//  имя файла (оканчивающееся нулем) 
        }

        */
           //При удачном завершении вызова возвращаемое значение равно 0.
           //При ошибке возвращается -1,
        return 0;
       }

    }

    
}
