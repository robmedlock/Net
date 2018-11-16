using System;

namespace Examples
{
    public class RefExample
    {
        public static void Method(ref int i)
        {
            i = i + 44;
        }

        public static void Main()
        {
            int val = 1;
            Method(ref val);
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
}
