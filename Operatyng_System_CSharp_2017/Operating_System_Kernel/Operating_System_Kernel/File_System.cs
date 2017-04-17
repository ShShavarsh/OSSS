using System;
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

            public info_for_read_in_hard_diskEventArgs(int bl_addr, int offs, int size)
            {
                Block_Address = bl_addr;
                Offset = offs;
                Size = size;
            }
        }

        public class info_for_write_in_hard_diskEventArgs : EventArgs
        {
            public int Block_Address { private set; get; }
            public int Offset { private set; get; }
            public byte[] Buffer { private set; get; }
            public int Begin { private set; get; }
            public int End { private set; get; }

            public info_for_write_in_hard_diskEventArgs(int bl_addr, int offs, byte[] buf,int begin,int end )
            {
                Block_Address = bl_addr;
                Offset = offs;
                Buffer = buf;
                Begin = begin;
                End = end;
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
                temp(this, e);
        }

        void Simulate_event_for_read_in_HD(int bl_addr, int offs, int size)
        {
            info_for_read_in_hard_diskEventArgs e = new info_for_read_in_hard_diskEventArgs(bl_addr, offs, size);

            event_func_for_read_from_HD(e);
        }





        public event EventHandler<info_for_write_in_hard_diskEventArgs> event_for_write_in_HD;

        protected virtual void event_func_for_write_in_HD(info_for_write_in_hard_diskEventArgs e)
        {
            EventHandler<info_for_write_in_hard_diskEventArgs> temp = Volatile.Read(ref event_for_write_in_HD);

            if (temp != null)
                temp(this, e);
        }

        void Simulate_event_for_write_in_HD(int bl_addr, int offs, byte[] buf,int begin,int end)
        {
            info_for_write_in_hard_diskEventArgs e = new info_for_write_in_hard_diskEventArgs(bl_addr, offs, buf,begin,end);

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


        public void handler_of_event_from_driver_end_writeing_event(object sender, Driver_Of_HD.end_writeing_in_hard_diskEventArgs e)
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

        public void handler_of_event_from_driver_end_reading_event(object sender, Driver_Of_HD.end_reading_from_hard_diskEventArgs e)
        {

            byte[] buffer = e.buf;
           //stexic eventa krakelu verevi makardak

        }
    }//handlerner@ grancinq event@ brnelu en erb krakvav :D 





    partial class File_System
    {
        Super_Block Superblok = new Super_Block();
        Array_Of_I_Nodes I_node = new Array_Of_I_Nodes();
        Information_Of_Free_Blocks Free_bloks = new Information_Of_Free_Blocks();

        public File_System()
        {

            creat_i_node(1);


        }


        // Create (Создать).
        //Создает файл без данных. Цель вызова состоит в объявлении
        //о появлении нового файла и установке ряда атрибутов.
        public short Cr_File(string name, byte mode)
        {


            if (name[0] != '/' || name[name.Length - 1] == '/')
            {
                throw new ArgumentException("error"); ;
            }


            string directory = string.Empty;
            string namefile = string.Empty;

        
            for (int i = 1; i < name.Length; i++)
            {
                if(name[i]!='/')
                {
                    namefile += name[i];

                }
                else
                {
                    directory += '/';
                    directory += namefile;
                    namefile = string.Empty;
                }

                
            }
          

            if (namefile.Length > 15)
            {
                string cut_file_name = namefile;
                namefile = string.Empty;
                for (int i = 0; i < 15; i++)
                {
                    namefile += cut_file_name[i];
                }

            }

            short[] namefile_of_short = new short[15];

            for (int i = 0; i < namefile.Length; i++)
            {
                namefile_of_short[i] = Convert.ToInt16(namefile[i]);
            }


            byte I_node_index_of_katalog = open_dir(directory);

            byte I_node_index_of_file = creat_i_node(0);

            int j = 0;

            for (; j < 99; j++)
            {


                if (I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].index_of_i_Node_ == 0)
                {

                    I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].name = namefile_of_short;
                    I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].index_of_i_Node_ = I_node_index_of_file;
                    break;

                }

            }

            if (j == 99)
            {
                throw new ArgumentException("tex chka");
            }



            byte fd = open(name, mode);
            // hima petqa tanenq es i_node i parunakutyun@ hard diski vra grenq u et graci arajin biti hascen grenq
            //I_Node_Table.array_Of_I_Nodes[counter] um

            return fd;
            // return file_Deskriptor;


            // I_Node i_node = new I_Node(mode);
            // hima petqa tanenq es i_node i parunakutyun@ hard diski vra grenq u et graci arajin biti hascen grenq
            //I_Node_Table.array_Of_I_Nodes[counter] um


            // return file_Deskriptor;
        }

        //Delete (Удалить). Когда файл больше не нужен, его нужно удалить, чтобы освобо-
        //дить дисковое пространство. Именно для этого и предназначен этот системный
        //вызов.
        public void Del_File( byte fd_file, byte fd_directory)
        {

            for (int i = 0; i < Super_Block.Count_Of_Blocks; i++)
            {
                if (I_node.Arr_I_Node[fd_file].block_addres[i] != -1)
                {
                    Free_bloks.byte_cart[I_node.Arr_I_Node[fd_file].block_addres[i]] = 0;
                    I_node.Arr_I_Node[fd_file].block_addres[i] = -1;
                }
                else
                {
                    break;
                }
            }

            //directory
            for (int i = 0; i < 99; i++)
            {

                if (I_node.Arr_I_Node[fd_directory].arr[i].index_of_i_Node_ == fd_file)
                {
                    I_node.Arr_I_Node[fd_directory].arr[i].index_of_i_Node_ = 0;
                    I_node.Arr_I_Node[fd_directory].arr[i].name = new short[15]; 
                    break;
                }
            }

            ///directori???
            I_node.Bayte_Map_For_I_Nods[fd_file] = 0;
        }

        //Open (Открыть). Перед использованием файла процесс должен его открыть. Цель
        //системного вызова open — дать возможность системе извлечь и поместить в опера-
        //тивную память атрибуты и перечень адресов на диске, чтобы ускорить доступ к ним
        //при последующих вызовах.
        public byte open(string name, byte mode)
        {



            if (name[0] != '/' || name[name.Length - 1] == '/')
            {
                throw new ArgumentException("error");
            }

            string directory = string.Empty;
            string namefile = string.Empty;
            byte index_of_i_node_file = 0;

            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] != '/')
                {
                    namefile += name[i];

                }
                else
                {
                    directory += '/';
                    directory += namefile;
                    namefile = string.Empty;
                }



            }


            byte I_Node_index_Of_Katalog = open_dir(directory);

            short[] name_of_short = new short[15];

            for (int i = 0; i < namefile.Length; i++)
            {
                name_of_short[i] = Convert.ToInt16(namefile[i]);
            }

            int j = 0;
            for (; j < 99; j++)
            {
                if (I_node.Arr_I_Node[I_Node_index_Of_Katalog].arr[j].name == name_of_short)
                {

                    index_of_i_node_file = I_node.Arr_I_Node[I_Node_index_Of_Katalog].arr[j].index_of_i_Node_;
                    break;
                }

            }

            if (j == 99)
            {
                throw new ArgumentException("enc  anunov file chka");


            }
            else
            {

                I_node.Arr_I_Node[index_of_i_node_file].attributes.set_attr(mode);
                
            }

            return index_of_i_node_file;
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
        public int read(byte fd,int buf_size, int add)
        {
            

            int temp = add / Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024);
            int offset = add % Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024);

            int num_of_block;
            int curent_count;


            num_of_block = I_node.Arr_I_Node[fd].block_addres[temp];
            
            

            while(buf_size>= Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024))
            {
                curent_count = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024) - offset;
                if(num_of_block==-1)
                {
                    throw new ArgumentException("block cka");
                }
                Simulate_event_for_read_in_HD(num_of_block, offset, curent_count);
                offset = 0;
                buf_size -= Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024);
                temp++;
                num_of_block = I_node.Arr_I_Node[fd].block_addres[temp];
            }

            if (buf_size != 0)
            {
                if (num_of_block == -1)
                {
                    throw new ArgumentException("block cka");
                }

                Simulate_event_for_read_in_HD(num_of_block, offset, buf_size);
            }

            return 0;
          
        }

        //Write (Произвести запись). Запись данных в файл, как правило, с текущей позиции.
        //Если эта позиция находится в конце файла, то его размер увеличивается. Если теку-
        //щая позиция находится где-то в середине файла, то новые данные пишутся поверх
        //существующих, которые утрачиваются навсегда.
        public int write(byte fd, byte[] buf, int add)
        {
            int temp = add / Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) *1024);
            int offset = add % Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024);
            int num_of_block;
            int buf_lenght = buf.Length;

            num_of_block = I_node.Arr_I_Node[fd].block_addres[temp];

            if (temp != 0 && num_of_block == -1 && I_node.Arr_I_Node[fd].block_addres[temp - 1] == -1)
            {
                throw new ArgumentException("error");
            }

            int begin = 0;
            int end=0;

            while (buf_lenght >= Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) *1024))
            {
                end += Convert.ToInt32(Math.Pow(2, Convert.ToDouble(Super_Block.s_log_block_size)) * 1024) - offset;

                if (num_of_block == 0)
                {

                    num_of_block = add_new_block(fd, temp);

                }


                Simulate_event_for_write_in_HD(num_of_block, offset, buf,begin,end);

                offset = 0;

                temp++;

                num_of_block = num_of_block = I_node.Arr_I_Node[fd].block_addres[temp];

                buf_lenght -=Convert.ToInt32(Math.Pow(2,Convert.ToDouble( Super_Block.s_log_block_size))*1024);

                begin = end;
            }

            if (num_of_block == 0)
            {

                num_of_block = add_new_block(fd, temp);


            }
            end = buf_lenght;
            Simulate_event_for_write_in_HD(num_of_block, offset, buf,begin,end);
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

        public int mkdir(string name/*, byte mode*/)
        {

            if (name[0] != '/' || name[name.Length - 1] == '/')
            {
                throw new ArgumentException("error");
            };

            string directory = string.Empty;
            string namedirectory = string.Empty;

            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] != '/')
                {
                    namedirectory += name[i];

                }
                else
                {
                    directory += '/';
                    directory += namedirectory;
                    namedirectory = string.Empty;
                }



            }


            if (namedirectory.Length > 15)
            {
                string cut_file_name = namedirectory;
                namedirectory = string.Empty;
                for (int i = 0; i < 15; i++)
                {
                    namedirectory += cut_file_name[i];
                }


            }

            short[] namekatalog_of_short = new short[15];

            for (int i = 0; i < namedirectory.Length; i++)
            {
                namekatalog_of_short[i] = Convert.ToInt16(namedirectory[i]);
            }


            byte I_node_index_of_katalog = open_dir(directory);

            byte I_node_index_of_new_katalog = creat_i_node(1);

            int j = 0;

            for (; j < 99; j++)
            {


                if (I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].index_of_i_Node_ == 0)
                {


                    I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].name = namekatalog_of_short;
                    I_node.Arr_I_Node[I_node_index_of_katalog].arr[j].index_of_i_Node_ = I_node_index_of_new_katalog;


                }




            }

            if (j == 99)
            {
                throw new ArgumentException("tex chka");
            }

            byte fd = open_dir(name);
            //Созданный каталог принадлежит фактическому владельцу
            //процесса

            // При успешном завершении mkdir возвращаемое значение равно
            //нулю, в случае ошибки возвращается -1 

            return fd;
        }

        //Delete (Удалить каталог). Удалить можно только пустой каталог. Каталог, содержа-
        //щий только точку и двойную точку, рассматривается как пустой, поскольку они не
        //могут быть удалены.
        public int rmdir(byte fd_remove_directory, byte fd_directory)

        {

            for (int i = 0; i < 99; i++)
            {
                if (I_node.Arr_I_Node[fd_remove_directory].arr[i].index_of_i_Node_ != 0)
                {
                    if (I_node.Arr_I_Node[I_node.Arr_I_Node[fd_remove_directory].arr[i].index_of_i_Node_].attributes.Special_File == 1)
                    {
                        rmdir(I_node.Arr_I_Node[fd_remove_directory].arr[i].index_of_i_Node_, fd_remove_directory);

                    }
                    else
                    {

                        Del_File(I_node.Arr_I_Node[fd_remove_directory].arr[i].index_of_i_Node_, fd_remove_directory);
                    }
                }

            }
            for (int i = 0; i < 99; i++)
            {

                if (I_node.Arr_I_Node[fd_directory].arr[i].index_of_i_Node_ == fd_remove_directory)
                {

                    I_node.Arr_I_Node[fd_directory].arr[i].index_of_i_Node_ = 0;
                    //I_node.Arr_I_Node[fd_directory].arr[i].name  ??????
                    break;
                }
            }
            I_node.Bayte_Map_For_I_Nods[fd_remove_directory] = 0;
            //rmdir удаляет каталог, который должен быть пустым.

            //В случае успешного завершения вызова возвращается нулевое
            //значение. При ошибке возвращается -1,

            return 0;
        }


        //Opendir (Открыть каталог). Каталоги могут быть прочитаны. К примеру, для вы-
        //вода имен всех файлов, содержащихся в каталоге, программа ls открывает каталог
        //для чтения имен всех содержащихся в нем файлов. Перед тем как каталог может
        //быть прочитан, он должен быть открыт по аналогии с открытием и чтением файла.
        public byte open_dir(string name/* byte mode*/)
        {
            if (name[0] != '/' || name[name.Length - 1] == '/')
            {
                throw new ArgumentException("error");
            }

            byte index_I_Node_of_directori = 0;

            byte index_I_Nodes = 0;

            short[] name_directori_of_short = new short[15];


            string name_directori = string.Empty;

            for (int i = 1; i <= name.Length; i++)
            {

                if (name[i] != '/' && i != name.Length)
                {
                    name_directori += name[i];
                }
                else
                {



                    for (int j = 0; j < 15; j++)
                    {
                        if (j != name_directori.Length)
                        {
                            name_directori_of_short[j] = Convert.ToInt16(name_directori[j]);
                        }
                        else
                        {

                            name_directori_of_short[j] = 0;
                        }
                    }

                    index_I_Nodes = 0;


                    for (; index_I_Nodes < 99; index_I_Nodes++)
                    {

                        if (I_node.Arr_I_Node[index_I_Node_of_directori].arr[index_I_Nodes].name == name_directori_of_short)
                        {
                            index_I_Node_of_directori = I_node.Arr_I_Node[index_I_Node_of_directori].arr[index_I_Nodes].index_of_i_Node_;
                            break;
                        }

                    }


                    name_directori = string.Empty;
                }
                if (index_I_Nodes == 99)
                {
                    throw new ArgumentException("et anunov directory chka");

                }

            }

            return index_I_Node_of_directori;
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

        public List<dirent> readdir(byte fd)//, dirent  dirp)
        {


            List<dirent> ob = new List<dirent>();
            dirent temp = new dirent();
            for(byte i=0;i<99; i++)
            {

                if(I_node.Arr_I_Node[fd].arr[i].index_of_i_Node_!=0)
                {
                    temp.name = I_node.Arr_I_Node[fd].arr[i].name;
                    temp.num_in_i_nod = I_node.Arr_I_Node[fd].arr[i].index_of_i_Node_;
                    temp.tex_directoriai_mej = i;
                    ob.Add(temp);

                }

            }
           
            return ob;
        }

    }
    



    partial class File_System
    {
        private byte creat_i_node(byte flag)
        {
            if (Array_Of_I_Nodes.count_of_frii_i_nods == 0)
            {

                throw new ArgumentException("tex chka");
            }

            byte i = 0;

            for (; i < Super_Block.s_inodes_count; i++)
            {

                if (I_node.Bayte_Map_For_I_Nods[i] == 0)
                {
                   
                    I_node.Bayte_Map_For_I_Nods[i] = 1;
                    I_node.Arr_I_Node[i] = new I_Node( flag);
                    break;
                    
                }
               
            }
          
            return i;

        }

        private int add_new_block(byte fd,int num_uf_block_in_file)
        {
            int i = 0;
            for (; i < Super_Block.Count_Of_Blocks; i++)
            {
                if(Free_bloks.byte_cart[i] == 0)
                {
                    Free_bloks.byte_cart[i] = 1;
                    I_node.Arr_I_Node[fd].block_addres[num_uf_block_in_file] = i;
                    break;

                }

            }
            return i;
        }

       public class dirent
        {
         public   byte num_in_i_nod;
         public byte tex_directoriai_mej;
         public short[] name = new short[15];
        }

    }
}