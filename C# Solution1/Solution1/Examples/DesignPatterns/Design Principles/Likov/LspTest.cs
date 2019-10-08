using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Principles.Likov
{
    // Derived types must be completely substitutable for their base types.
    // Violation of Likov's Substitution Principle
    class Rectangle
    {
        protected int width;
        protected int height;

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }


        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }


        public virtual int Area
        {
            get
            {
                return Width * Height;
            }
        }
    }


    //a rectangle can't be subsituted for a square
    class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                width = value; 
                height = value;
            }
        }

        public override int Height
        {
            set
            {
                width = value;
                height = value;
            }
        }
    }

    public class LspTest
    {
        private static Rectangle getNewRectangle()
        {
            return new Square();
        }

        static void Main(string[] args)
        {
            Rectangle r = LspTest.getNewRectangle();
            r.Width = 5;
            r.Height = 10;
            Console.WriteLine(r.Area);
            Console.ReadKey();
        }
    }

}
