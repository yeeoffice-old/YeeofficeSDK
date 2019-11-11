using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Tools
{
    public class LogHelper
    {
        private log4net.ILog log;

        private LogHelper(Type type)
        {
            log = log4net.LogManager.GetLogger(type);
        }

        public static LogHelper GetLogger(Type type)
        {
            return new LogHelper(type);
        }

        public static void InitLog4Net(string config)
        {
            using (MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(config)))
            {
                log4net.Config.XmlConfigurator.Configure(s);
            }
        }

        public static string Format(string[] Arr)
        {
            StringBuilder message = new StringBuilder();
            if (Arr == null)
            {
                message.Append("Array is Null");
            }
            message.AppendFormat("Array [{0}]", Arr.Length);
            for (int i = 0; i < Arr.Length; i++)
            {
                message.AppendFormat(" {0}:{1}", i, Arr[i]);
            }
            return message.ToString();
        }

        #region 封装Log4net

        public bool IsDebugEnabled { get { return log.IsDebugEnabled; } }

        public void Debug(object message)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }

        public void Debug(object message, Exception ex)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(message, ex);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(format, args);
            }
        }

        public void Error(object message)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }

        public void Error(object message, Exception ex)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }

        public void ErrorFormat(Exception ex, string format, params object[] args)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat(format, args);
                log.Error(ex.Message, ex);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat(format, args);
            }
        }

        public void Fatal(object message)
        {
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
        }

        public void Fatal(object message, Exception ex)
        {
            if (log.IsFatalEnabled)
            {
                log.Fatal(message, ex);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (log.IsFatalEnabled)
            {
                log.FatalFormat(format, args);
            }
        }

        public void Info(object message)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        public void Info(object message, Exception ex)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(message, ex);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (log.IsInfoEnabled)
            {
                log.InfoFormat(format, args);
            }
        }

        public void Warn(object message)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
        }

        public void Warn(object message, Exception ex)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(message, ex);
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (log.IsWarnEnabled)
            {
                log.WarnFormat(format, args);
            }
        }

        public void WarnFormat(Exception ex, string format, params object[] args)
        {
            if (log.IsWarnEnabled)
            {
                log.WarnFormat(format, args);
                log.Warn(ex.Message, ex);
            }
        }

        #endregion 封装Log4net
    }
}
