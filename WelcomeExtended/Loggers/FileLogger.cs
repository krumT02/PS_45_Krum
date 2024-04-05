using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly string _name;

        public FileLogger(string name, string filePath)
        {
            _name = name;
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = $"{DateTime.Now}: [{logLevel}] [{_name}] {formatter(state, exception)}\n";
            File.AppendAllText(_filePath, message);
        }
    }
}
