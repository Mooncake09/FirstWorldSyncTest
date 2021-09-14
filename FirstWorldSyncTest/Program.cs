using System;
using System.Threading;

namespace FirstWorldSyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogWriter = new ConsoleLogWriter();
            consoleLogWriter.LogError("some error message");
            Thread.Sleep(3000);
            consoleLogWriter.LogInfo("some info message");
            Thread.Sleep(3000);
            consoleLogWriter.LogWarning("some warning message");
        }
    }
}
