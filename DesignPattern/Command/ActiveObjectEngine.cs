using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ActiveObjectEngine
    {
        List<Command> commands = new List<Command>();

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public void Run()
        {
            while (commands.Any())
            {
                Command c = commands[0];
                commands.RemoveAt(0);
                c.Execute();
            }
        }
    }
}
