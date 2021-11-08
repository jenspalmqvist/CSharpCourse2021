using System;

namespace Generics.Models
{
    class LogEntry
    {
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Message} at {Time}";
        }
    }
}
