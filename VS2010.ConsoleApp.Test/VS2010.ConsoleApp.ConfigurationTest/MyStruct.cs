using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
   public   struct MyStruct
    {
        public int Length;
        public int Width;
        public int Height;

        public double X;
        public double Y;
        public double Z;

        public override string ToString()
        {
            return "L: " + Length + ", W: " + Width + ", H: " + Height +
                   ", X: " + X + ", Y: " + Y + ", Z: " + Z;
        }
    }
}
