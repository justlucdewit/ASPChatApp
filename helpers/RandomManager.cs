using System;
using System.Collections.Generic;

namespace aspchat.helpers
{
    public class RandomManager
    {
        public delegate void Job();

        UInt32 counter = 0;
        public List<(int, Job)> Jobs = new List<(int, Job)>();

        public void AddJob(int frequency, Job job)
        {
            Jobs.Add((frequency, job));
        }

        public void Manage()
        {
            foreach ((int, Job) job in Jobs)
            {
                // if frequency can be modulated by the counter
                if (counter % job.Item1 == 0) 
                {
                    // do the job
                    job.Item2();
                }
            }
            counter++;
        }
    }
}
