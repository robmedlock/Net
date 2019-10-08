using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int fn = 0, f1 = 1, f2 = 1; fn < 100; fn = f1 + f2)
            {
                f2 = f1; //assign fn-1 to Fn-2
                f1 = fn; //assign fn to = Fn-1
                Console.WriteLine(fn);
            }


        }
    }
}
