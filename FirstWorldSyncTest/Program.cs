using System;
using System.Collections.Generic;
using System.Threading;

namespace FirstWorldSyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogWriter = new ConsoleLogWriter();
            var fileLogWriter = new FileLogWriter(@"E:\FWS_FileLogWriter");
            var multipleLogWriter = new MultipleLogWriter(new List<ILogWriter> { consoleLogWriter, fileLogWriter});

            multipleLogWriter.LogError("some error message");
            multipleLogWriter.LogInfo("some info message");
            multipleLogWriter.LogWarning("some warning message");
        }
    }
}
