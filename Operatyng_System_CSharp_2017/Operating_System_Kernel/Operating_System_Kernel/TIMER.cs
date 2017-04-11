using System;

using System.Timers;

namespace Operating_System_Kernel
{
    public class TIMER
    {
        public  Timer timer { private set; get; }//Конструктор Timer
        //Инициализирует новый экземпляр класса Timer.

        public TIMER(double Interval = 1000.0)
        {
            timer = new Timer();

            timer.Enabled = true;
            //Возвращает или задает значение, определяющее, должен ли объект Timer вызывать событие Elapsed.

            timer.AutoReset = true;
            //Возвращает или задает логическое значение,
            //определяющее, должен ли объект Timer вызывать событие Elapsed один раз (false) или неоднократно (true).


            timer.Interval = Interval;
            
        }

        public void Add_Func_For_Elapsing(ElapsedEventHandler del)
        {
            timer.Elapsed += del;
        }
    }
}
