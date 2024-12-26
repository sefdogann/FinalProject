using FinalProject.Data;
using System;
using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;

namespace YourNamespace.Services
{
    public class DatabaseLogger : ICustomLogger
    {
        private readonly AppDbContext _context;

        public DatabaseLogger(AppDbContext context)
        {
            _context = context;
        }

        public void Log(string message)
        {
            try
            {
                var logEntry = new Log
                {
                    Message = message,
                    Timestamp = DateTime.Now
                };
                _context.Logs.Add(logEntry);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hata işleme burada yapılabilir
                Console.WriteLine($"Logging to database failed: {ex.Message}");
            }
        }
    }
}
