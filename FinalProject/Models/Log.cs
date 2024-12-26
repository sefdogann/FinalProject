using FinalProject.Models;

namespace FinalProject.Models
{
    public class Log : BaseEntity
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
