using ClassLibrary.Entity;
using System;
using System.Text;

namespace Examples
{
    delegate void MyAction<in T>(T obj);

    class InParameters
    {
        public static void Main()
        {
            Action<Object> lessDerivedParameter = (target) => { Console.WriteLine(target.GetType().Name); };
            Action<StringBuilder> moreDerivedParameter = lessDerivedParameter;
            moreDerivedParameter(new StringBuilder());
        }
    }
}
