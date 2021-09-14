﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWorldSyncTest
{
    class ConsoleLogWriter : LogWriter, ILogWriter
    {
        public ConsoleLogWriter() { }

        public void LogError(string message)
        {
            Console.WriteLine($"{timestamp} {MessageType.Error} {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"{timestamp} {MessageType.Info} {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"{timestamp} {MessageType.Warning} {message}");
        }
    }
}
