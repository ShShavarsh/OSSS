using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleToAttribute("Operating_System_User_Space")]
//ay es atribut@ kirarelov menq Operating_System_User_Space assemblyn  sarqum enq mer es assembly in @nker
// u Operating_System_User_Space assembly um tesaneli en linelu mer es essembly i internal classner@
//mer es zborkayi bolor classneri tesaneliutyan tiruyt@ nshvac chi vorovhetev C# um defaylt Internal a
//thanks for reading :D ,bye

namespace Operating_System_Kernel

{
    class File_System
    {
        Super_Block superblok = new Super_Block();
        Array_Of_I_Nodes I_Node_Table = new Array_Of_I_Nodes();
        Information_Of_Free_Blocks bitavaya_karta = new Information_Of_Free_Blocks();


        /*
         es classum piti linen liq@ metodnercreate file
         * create catalog u tenc nmanatip metodner 
         * open
         */
    }
}
