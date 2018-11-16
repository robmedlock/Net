using System;

namespace DesignPatterns.Observer
{
    public class Observer1 : IObserver
    {
        public void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Observer Notify called");
        }
    }

}
