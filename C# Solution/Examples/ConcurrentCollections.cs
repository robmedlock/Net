using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class ConcurrentCollections
    {
        public static void Main()
        {
            ConcurrentStack<int> s = new ConcurrentStack<int>();

            s.Push(50);
            s.Push(100);
            s.Push(150);
            s.Push(200);
            s.Push(250);
            s.Push(300);

                Console.WriteLine(s);



        }
    }
}
