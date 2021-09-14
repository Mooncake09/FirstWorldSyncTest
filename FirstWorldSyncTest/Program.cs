using System;
using System.Threading;

namespace FirstWorldSyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogWriter = new ConsoleLogWriter();
            var fileLogWriter = new FileLogWriter(@"E:\FWS_FileLogWriter");
            fileLogWriter.LogError("some message");
        }
    }
}
