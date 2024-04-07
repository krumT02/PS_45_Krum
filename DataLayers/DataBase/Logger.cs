using DataLayers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayers.DataBase
{
    public class Logger
    {
        private readonly DatabaseContext _context;

        public Logger(DatabaseContext context)
        {
            _context = context;
        }

        public void Log(string message, string level)
        {
            var logEntry = new LogEntry{ Message = message, Level = level,Timestamp = DateTime.UtcNow };
            _context.Logs.Add(logEntry);
            _context.SaveChanges();
            Console.WriteLine($"[{DateTime.UtcNow}] {level}: {message}");
        }
    }

}
