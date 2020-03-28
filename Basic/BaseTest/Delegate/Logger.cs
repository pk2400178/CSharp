using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest.Delegate
{
    public static class Logger
    {
        public enum Severity
        {
            Verbose,
            Trace,
            Information,
            Warning,
            Error,
            Critical
        }

        private static Severity LogLevel { get; set; } = Severity.Warning;

        public static Action<string> WriteMessage;

        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage(outputMsg);
        }
    }
}
