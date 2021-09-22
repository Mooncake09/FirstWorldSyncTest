using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWorldSyncTest
{
    class MultipleLogWriter : LogWriter, ILogWriter
    {
        private List<ILogWriter> LogWriters;
        public MultipleLogWriter(List<ILogWriter> logWriters)
        {
            if (logWriters.Count() != 0)
            {
                LogWriters = logWriters;
            }
            else
            {
                throw new ArgumentNullException("MultipleLogWriter constructor not contain any logWriters instance");
            }
        }
        public void LogError(string message)
        {
            foreach (var lg in LogWriters)
            {
                lg.LogError(message);
            }
        }

        public void LogInfo(string message)
        {
            foreach (var lg in LogWriters)
            {
                lg.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (var lg in LogWriters)
            {
                lg.LogWarning(message);
            }
        }
    }
}
