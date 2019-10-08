using System;

namespace Examples.MoreKeywords
{
    public class RefExample
    {
        public static void Main()
        {
            int number; //argument passed to out parameter must be modified by called method
            string str = "5";
            bool success = Int32.TryParse(str, out number);

            int val = 1; //argument passed to a ref parameter must be initialized 
            PassByRef(ref val);
            Console.WriteLine(val);

            int constant = 5; //in arguments are constants that can’t be modified by the called method
            PassConstByRef(constant);

            Console.ReadKey();
        }
        public static void PassByRef(ref int i)
        {
            i = i + 44;
        }

        //C# 7.2 (properties > build > advanced)
        public static void PassConstByRef(in int i)
        {
            //i = i + 44;
        }
    }

}
