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
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }

    public class Logger : LogBase
    {
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
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }
        public override void Log(string message)
        {
            using (StreamWriter w = File.AppendText(this.FilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine(DateTime.Now.ToLongDateString());
                w.WriteLine(message);
                w.WriteLine("----------------------------------");
            }
        }
    }
}