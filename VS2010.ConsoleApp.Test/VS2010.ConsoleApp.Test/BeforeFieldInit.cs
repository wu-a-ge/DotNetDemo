using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Test
{
    sealed class BeforeFieldInit
    {
        public static int s_x = 32;
    }
    sealed class Precise
    {
        public static int s_x;
        static Precise()
        {
            s_x = 32;
        }
    }
}
