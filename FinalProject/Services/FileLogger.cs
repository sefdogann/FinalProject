using System;
using System.IO;
using FinalProject.Interfaces;

namespace FinalProject.Services
{
    public class FileLogger : ICustomLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                // Hata işleme burada yapılabilir
                Console.WriteLine($"Logging to file failed: {ex.Message}");
            }
        }
    }
}
