using System;
using System.Drawing;

namespace Emmetienne.SolutionReplicator.Model.Logging
{
    public class LogModel
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }   
        public LogLevel LogLevel { get; set; }
        public Color Color { get; set; }

        public LogModel()
        {
            Timestamp = DateTime.Now;
        }

        public LogModel(string message, string exception)
        {
            Timestamp = DateTime.Now;
            Message = message;
            Exception = exception;
        }

        public LogModel(string message,string exception, Color color)
        {
            Timestamp = DateTime.Now;
            Message = message;
            Color = color;
            Exception = exception;
        }
    }
}
