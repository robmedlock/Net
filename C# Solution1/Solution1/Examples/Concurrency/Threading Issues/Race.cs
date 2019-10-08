using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    //https://www.csharpstar.com/csharp-race-conditions-in-threading/
    public class Race
    {
        //2 threads are trying to increment shared  counter variable at same time
        private int counter;

        public void Start()
        {
            //var t1 = new Thread(PrintStar);
            //t1.Start();
            //t1.Join();

            //var t2 = new Thread(PrintPlus);
            //t2.Start();
            //t2.Join();

            Task t1 = Task.Run(() => PrintStar());

            //Synchronization using Task.ContinueWith
            //to start a task after another one completes its execution
            Task t2 = t1.ContinueWith(antecedent => PrintPlus());
            Task.WaitAll(new Task[] { t1, t2 });
        }

        void PrintStar()
        {
            //lock (this)
            Monitor.Enter(this);
            try 
            {
                for (counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("*");
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void PrintPlus()
        {
            Monitor.Enter(this);
            try
            {
                for (counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("+");
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}