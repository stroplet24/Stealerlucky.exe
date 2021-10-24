using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLucky
{
    class Startjabbers
    {
        public static int count = 0;
        public static int Start(string GetLucky_Dir)
        {
            Pidgin.Start(GetLucky_Dir); 
            Psi.Start(GetLucky_Dir); 
        
            return count;
        }
    }
}
