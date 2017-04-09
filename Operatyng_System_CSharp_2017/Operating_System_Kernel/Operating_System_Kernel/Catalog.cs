using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operating_System_Kernel
{
    class Catalog
    {   
            static  int Max_Count_of_Zapis = 100;
            Zapis_Of_File[] Array_Of_Zapis;
            public Catalog()
            {

                Array_Of_Zapis = new Zapis_Of_File[Max_Count_of_Zapis];
                //chgitem vapshe es catalog objekt@ inch interfeysa tali ete ihatke talisa
                //nu piti orinak rename anunov funkcia ta u tenc baner @ erevi funkcianerov?
            }

        
    }
}
