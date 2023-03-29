using System;

namespace ConsoleAppIntermediate
{
    public class StopWatch
    {

        private DateTime? StartTime { get; set; }
        private DateTime? StopTime { get; set; }

        public void Start()
        {
            if (this.StartTime != null)
                throw new InvalidOperationException("Watch ALready Started");

            this.StartTime = DateTime.Now;
            Console.WriteLine("Watch Start Time : " + this.StartTime.ToString());

        }

        public void Stop()
        {
            if (this.StartTime == null)
                throw new InvalidOperationException("Start Watch First");


            this.StopTime = DateTime.Now;

            var elapsedTimeSpan = this.StopTime - this.StartTime;
            this.StartTime = null;
            this.StopTime = null;

            Console.WriteLine("Timespan Duration " + elapsedTimeSpan);
        }

    }
}