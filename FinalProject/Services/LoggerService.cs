using Microsoft.Extensions.Logging;
using FinalProject.Interfaces;

namespace FinalProject.Services
{
    public class LoggerService
    {
        private readonly ICustomLogger _logger;

        public LoggerService(ICustomLogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
