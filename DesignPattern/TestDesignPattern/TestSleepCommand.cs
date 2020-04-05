using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Command
{
    public class TestSleepCommand
    {
        private class WakeUpCommand: Command
        {
            public bool excuted = false;

            public void Execute()
            {
                excuted = true;
            }
        }


        [Fact]
        public void Testsleep()
        {
            WakeUpCommand wakeUp = new WakeUpCommand();
            ActiveObjectEngine activeObjectEngine = new ActiveObjectEngine();
            SleepCommand sleepCommand = new SleepCommand(1000, activeObjectEngine, wakeUp);
            activeObjectEngine.AddCommand(sleepCommand);

            DateTime start = DateTime.Now;
            activeObjectEngine.Run();
            DateTime end = DateTime.Now;

            double sleepTime = (end - start).TotalMilliseconds;

            Assert.True(sleepTime >= 1000, $"sleep time {sleepTime} expected > 1000");
            //Assert.True(sleepTime <= 1000, $"sleep time {sleepTime} expected < 1000");
            Assert.True(wakeUp.excuted);
        }
    }
}
