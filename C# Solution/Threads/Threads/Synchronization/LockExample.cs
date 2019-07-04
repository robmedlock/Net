using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class LockExample
    {
        public static void Start()
        {
            int numTasks = 5;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            //start 5 tasks with shared state
            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state).DoTheJob());
            }

            //wait for tasks to complete
            for (int i = 0; i < numTasks; i++)
            {
                tasks[i].Wait();
            }

            Console.WriteLine("summarized {0}", state.State);
        }
    }

    public class SharedState
    {
        public int State { get; set; }
    }

    public class Job
    {
        SharedState sharedState;
        public Job(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }
        public void DoTheJob()
        {
            for (int i = 0; i < 1000; i++)
            {
                // lock (sharedState)
                {
                    sharedState.State += 1;
                    //sharedState.IncrementState();
                }
            }

        }
    }


}
