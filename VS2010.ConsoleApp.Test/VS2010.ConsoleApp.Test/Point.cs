using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Test
{
    struct Point
    {
        public int m_x, m_y;

       
         
       
    }
    
    class Rectangle
    {
        public Point m_topLeft=new Point(), m_bottomRight;
        //public  Rectangle()
        //{
        //    m_topLeft = new Point();
        //    m_bottomRight = new Point();
        //}
        public void Method()
        {
            Console.WriteLine(this.m_topLeft.m_x);
        }
    }
}
