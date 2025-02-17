using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class Input
    {
        protected static ConsoleKeyInfo keyInfo;

        public Input() 
        {
            
        }


        public static void Process()
        {
            keyInfo = Console.ReadKey();
        }

        public static bool GetKeyDown(ConsoleKey keycode)
        {
            return keyInfo.Key == keycode;
        }

    }
}
