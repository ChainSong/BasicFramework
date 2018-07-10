using System;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Logger
{
    public static class RunbowLogger
    {
        private static string LogFilePath = "LogFilePath";

        public static void LogError(string Error)
        {    
            Log(Error, "Error");
        }

        public static void LogException(Exception ex)
        {
            StringBuilder exceptionSB = new StringBuilder();
            exceptionSB.AppendLine(ex.Message);
            exceptionSB.AppendLine(ex.ToString());
            Exception innerException = ex.InnerException;
            if (innerException != null)
            {
                exceptionSB.AppendLine("********************");
                exceptionSB.AppendLine(innerException.Message);
                innerException = innerException.InnerException;
            }

            Log(exceptionSB.ToString(), "Exception");
        }

        public static void LogMessage(string Message)
        {
            Log(Message, "Message");
        }

        public static void LogInfo(string Info)
        {
            Log(Info, "Info");
        }

        private static void Log(string Message, string Category)
        {
            string path = ConfigurationManager.AppSettings[LogFilePath];

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileStream fs = new FileStream(path + "\\log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);

            streamWriter.WriteLine("-----------------------------------------------------------------------------------------");
            streamWriter.WriteLine(DateTime.Now.ToString() + "     " + Category);
            streamWriter.WriteLine(Message);
            streamWriter.WriteLine("-----------------------------------------------------------------------------------------");
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
    }
}
