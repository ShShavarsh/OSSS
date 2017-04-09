using System;

using System.Text;

using System.Threading;




namespace HardWare
{
    
    class CPU
    {
       public  static void Main(string[] args)
        {
            My_Timer timer = new My_Timer();
            timer.timer.Start();
            
            

            Console.ReadKey();

        }

       
    }

}
