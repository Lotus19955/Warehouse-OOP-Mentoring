using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using System.Configuration;

namespace Warehouse_infrastructure
{
    public enum LogLevel
    {
        Trace,
        Debug,
        Information,
        Warning,
        Error,
        Critival,
        Nine
    }
    public abstract class LogBase
    {
        public abstract void Log(string message, LogLevel level);
    }

    public class Logger : LogBase
    {
        private static ValidationService validationService = new ValidationService();
        private string CurrentDirectory
        {
            get;
            set;
        }
        private string FileName
        { 
            get;
            set;
        }
        private string FilePath
        {
            get;
            set;
        }
        public Logger()
        {
            this.CurrentDirectory = @"D:\VS\Проекты\Warehouse-OOP-Mentoring\Logs\";
            this.FileName = "Logger.txt";
            this.FilePath = this.CurrentDirectory + this.FileName;
        }
        public override void Log(string message, LogLevel level)
        {
            validationService.ValidationSavingPath(CurrentDirectory);
            using (StreamWriter w = File.AppendText(this.FilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine(DateTime.UtcNow);
                w.WriteLine($"{level}: " + message) ;
                w.WriteLine("----------------------------------");
            }
        }
    }
}