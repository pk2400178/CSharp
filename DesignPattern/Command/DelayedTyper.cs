using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DelayedTyper : Command
    {
        private long itsDelay;
        private char itsChar;
        private static bool stop = false;
        private static ActiveObjectEngine ActiveObjectEngine = new ActiveObjectEngine();

        public DelayedTyper(long delay, char c)
        {
            this.itsDelay = delay;
            this.itsChar = c;
        }

        private class StopCommand : Command
        {
            public void Execute()
            {
                DelayedTyper.stop = true;
            }
        }

        static void Main(string[] args)
        {
            ActiveObjectEngine.AddCommand(new DelayedTyper(100, '1'));
            ActiveObjectEngine.AddCommand(new DelayedTyper(300, '3'));
            ActiveObjectEngine.AddCommand(new DelayedTyper(500, '5'));
            ActiveObjectEngine.AddCommand(new DelayedTyper(700, '7'));

            Command command = new StopCommand();
            ActiveObjectEngine.AddCommand(new SleepCommand(20000, ActiveObjectEngine, command));
            ActiveObjectEngine.Run();
        }

        public void Execute()
        {
            Console.Write(itsChar);
            if(!stop)
            {
                DelayAndRepeat();
            }
        }

        private void DelayAndRepeat()
        {
            ActiveObjectEngine.AddCommand(
                new SleepCommand(itsDelay, ActiveObjectEngine, this));
        }
    }
}
