﻿using System;
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
            Task t2 = Task.Run(() => PrintPlus());
            Console.ReadKey();
            //Task t2 = t1.ContinueWith(antecedent => PrintPlus());
            //Task.WaitAll(new Task[] { t1, t2 });
        }

        void PrintStar()
        {
            //lock (this)
            {
                for (counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("*");
                }
            }
        }

        private void PrintPlus()
        {
            //lock (this)
            {
                for (counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("+");
                }
            }
        }
    }
}