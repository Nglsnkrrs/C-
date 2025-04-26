using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLib
{

    public enum MessageType
    {
        Error,
        Exception,
        Test,
        Info,
        Warning
    }
    public class Logger
    {
        private readonly string _logFilePath;
        private readonly string[] _fieldOrder;

        public Logger(string configFilePath, string logFilePath)
        {
            _logFilePath = logFilePath;
            _fieldOrder = LoadConfig(configFilePath);
        }

        private string[] LoadConfig(string configFilePath)
        {
            if (!File.Exists(configFilePath))
                throw new FileNotFoundException("Config file not found.");

            var lines = File.ReadAllLines(configFilePath);
            foreach (var line in lines)
            {
                if (line.StartsWith("Order="))
                {
                    var orderPart = line.Substring("Order=".Length);
                    return orderPart.Split(',', StringSplitOptions.RemoveEmptyEntries);
                }
            }

            return new[] { "DateTime", "Type", "User", "Message" };
        }

        public void Log(MessageType type, string message)
        {
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var user = Environment.UserName;
            var typeStr = type.ToString();

            var builder = new StringBuilder();

            foreach (var field in _fieldOrder)
            {
                switch (field.Trim())
                {
                    case "DateTime":
                        builder.Append($"[{dateTime}] ");
                        break;
                    case "Type":
                        builder.Append($"[{typeStr}] ");
                        break;
                    case "User":
                        builder.Append($"[{user}] ");
                        break;
                    case "Message":
                        builder.Append($"{message} ");
                        break;
                }
            }

            var logLine = builder.ToString().TrimEnd();

            File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
        }
    }

}
