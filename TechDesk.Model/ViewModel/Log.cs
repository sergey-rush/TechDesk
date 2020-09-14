using System;
using TechDesk.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TechDesk.Model.ViewModel
{
    public class Log
    {
        public Log()
        {
            
        }

        public Log(LogLevel logLevel, string info, string dataType)
        {
            LogLevel = logLevel;
            Info = info;
            DataType = dataType;
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel LogLevel { get; set; }
        public string Info { get; set; }
        public string DataType { get; set; }
        public DateTime Created { get; set; } 
    }
}