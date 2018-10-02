using GridGame.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Library.Interfaces
{
    public interface ILogging
    {
        void SetLogLevel(LogLevel level);

        void Debug(string message, params object[] parameters);
        void Info(string message, params object[] parameters);
        void Warning(string message, params object[] parameters);
        void Error(string message, params object[] parameters);
        void Fatal(string message, params object[] parameters);

        void Debug(Exception exe, string message, params object[] parameters);
        void Info(Exception exe, string message, params object[] parameters);
        void Warning(Exception exe, string message, params object[] parameters);
        void Error(Exception exe, string message, params object[] parameters);
        void Fatal(Exception exe, string message, params object[] parameters);


    }
}
