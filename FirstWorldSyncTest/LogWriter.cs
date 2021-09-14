using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWorldSyncTest
{
    abstract class LogWriter
    {
        protected enum MessageType
        {
            Error,
            Info,
            Warning
        }
        
        protected string GetTimestamp() => DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss+ffff");
    }
}
