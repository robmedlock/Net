using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Observer
{
    public class Observer : IObserver
    {
        public void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Observer Notify called");
        }
    }

}
