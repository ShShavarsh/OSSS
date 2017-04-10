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

            timer.Add_Func_For_Elapsing(func);

            Console.ReadKey();

        }
       static void func(object sender,EventArgs e)
       {
           Console.WriteLine("Grancvelem,,obrabotka em anum");
       }
       
    }

}
