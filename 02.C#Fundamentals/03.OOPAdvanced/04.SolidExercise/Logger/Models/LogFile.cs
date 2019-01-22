using System;
using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
            this.Size = 0;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public string Path { get; }
        public int Size { get; private set; }
        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);
            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }
    }
}
