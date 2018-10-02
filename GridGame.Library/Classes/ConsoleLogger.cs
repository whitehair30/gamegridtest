using GridGame.Library.Enums;
using GridGame.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Library.Classes
{



    public class ConsoleLogger : ILogging
    {

        private LogLevel _level;

        public ConsoleLogger(LogLevel level = LogLevel.debug)
        {
            _level = level;
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void LogMessage(LogLevel messageLevel, string message, params object[] parameters)
        {
            if(messageLevel >= _level)
            {
                Console.WriteLine(message, parameters);
            }
        }

        private void LogException(LogLevel messageLevel, Exception exe, string message, params object[] parameters)
        {
            if (messageLevel >= _level)
            {
                if(string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message, parameters);
                }
                do
                {
                    Console.WriteLine($"EXCEPETION TYPE: {exe.GetType()} MESSAGE: {exe.Message}");
                    Console.WriteLine($"STACKTRCE: {exe.StackTrace}");
                    exe = exe.InnerException;
                }
                while (exe != null);
            }
        }

        public void Debug(string message, params object[] parameters)
        {
            LogMessage(LogLevel.debug, message, parameters);
        }

        public void Debug(Exception exe, string message, params object[] parameters)
        {
            LogException(LogLevel.debug, exe, message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            LogMessage(LogLevel.error, message, parameters);
        }

        public void Error(Exception exe, string message, params object[] parameters)
        {
            LogException(LogLevel.error, exe, message, parameters);
        }

        public void Fatal(string message, params object[] parameters)
        {
            LogMessage(LogLevel.fatal, message, parameters);
        }

        public void Fatal(Exception exe, string message, params object[] parameters)
        {
            LogException(LogLevel.fatal, exe, message, parameters);
        }

        public void Info(string message, params object[] parameters)
        {
            LogMessage(LogLevel.info, message, parameters);
        }

        public void Info(Exception exe, string message, params object[] parameters)
        {
            LogException(LogLevel.info, exe, message, parameters);
        }

        public void SetLogLevel(LogLevel level)
        {
            _level = level;
        }

        public void Warning(string message, params object[] parameters)
        {
            LogMessage(LogLevel.warning, message, parameters);
        }

        public void Warning(Exception exe, string message, params object[] parameters)
        {
            LogException(LogLevel.warning, exe, message, parameters);
        }
    }
}
