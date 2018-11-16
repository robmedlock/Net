using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    class Class1
    {
        public static void Main(string[] args)
        {
            IObserver observer = new Observer1();
            Observable observable = new Observable();
            observable.RegisterObserver(observer.Notify);

            observable.NotifyObservers();
            Console.ReadKey();
        }
    }
}
