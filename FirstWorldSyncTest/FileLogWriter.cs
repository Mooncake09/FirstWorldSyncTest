using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstWorldSyncTest
{
    class FileLogWriter : LogWriter, ILogWriter
    {
        private DirectoryInfo directory;
        public string ErrorsDirPath { get; private set; }
        public string InfoDirPath { get; private set; }
        public string WarningDirPath { get; private set; }
        public FileLogWriter(string dirPath)
        {
            directory = new DirectoryInfo(dirPath);
            if (!directory.Exists) 
            {
                directory.Create();
                directory.CreateSubdirectory(@"ErrorLogs");
                directory.CreateSubdirectory(@"InfoLogs");
                directory.CreateSubdirectory(@"WarningLogs");
            }
            ErrorsDirPath = directory.GetDirectories().Single(dir => dir.Name == "ErrorLogs").FullName;
            InfoDirPath = directory.GetDirectories().Single(dir => dir.Name == "InfoLogs").FullName;
            WarningDirPath = directory.GetDirectories().Single(dir => dir.Name == "WarningLogs").FullName;
        }
        public void LogError(string message)
        {
            var filePath = CreateFilePathName(MessageType.Error);
            CreateLogFile(filePath, message, MessageType.Error);
        }

        public void LogInfo(string message)
        {
            var filePath = CreateFilePathName(MessageType.Info);
            CreateLogFile(filePath, message, MessageType.Info);

        }

        public void LogWarning(string message)
        {
            var filePath = CreateFilePathName(MessageType.Warning);
            CreateLogFile(filePath, message, MessageType.Warning);
        }

        private string CreateFilePathName(MessageType mt) => mt switch
        {
            MessageType.Error => ErrorsDirPath + @"\" + GetTimestamp().Replace(":", "-") + "_LogError.txt",
            MessageType.Info => InfoDirPath + @"\" + GetTimestamp().Replace(":", "-") + "_LogInfo.txt",
            MessageType.Warning => WarningDirPath + @"\" + GetTimestamp().Replace(":", "-") + "_LogWarning.txt",
            _ => throw new ArgumentOutOfRangeException(nameof(mt), $"Неожиданное значение MessageType: {mt}")
        };

        private void CreateLogFile(string filePath, string message, MessageType mt)
        {
            try
            {
                using var streamWriter = new StreamWriter(filePath, false, Encoding.Default);
                streamWriter.WriteLine($"{GetTimestamp()}   Message Type: {mt}   {message}");
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
