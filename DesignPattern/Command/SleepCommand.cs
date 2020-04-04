using System;

namespace Command
{
    public class SleepCommand: Command
    {
        private long sleepTime = 0;
        private ActiveObjectEngine activeObjectEngine;
        private Command wakeUp;

        private DateTime startTime;
        private bool started = false;

        public SleepCommand(long sleepTime, ActiveObjectEngine activeObjectEngine, Command wakeUp)
        {
            this.sleepTime = sleepTime;
            this.activeObjectEngine = activeObjectEngine;
            this.wakeUp = wakeUp;
        }

        public void Execute()
        {
            DateTime currentTiem = DateTime.Now;
            if(!started)
            {
                started = true;
                startTime = currentTiem;
                activeObjectEngine.AddCommand(this);
            }
            else
            {
                TimeSpan span = currentTiem - startTime;
                if(span.TotalMilliseconds < sleepTime)
                {
                    activeObjectEngine.AddCommand(this);
                }
                else
                {
                    activeObjectEngine.AddCommand(wakeUp);
                }
            }
        }
    }
}