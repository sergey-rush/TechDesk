using System;
using TechDesk.Common;

namespace TechDesk.TableModel
{
    public class LogTableModel
    {
        [Column(Name = "Id")]
        public int Id { get; set; }
        [Column(Name = "LogLevel")]
        public int LogLevel { get; set; }
        [Column(Name = "Info")]
        public string Info { get; set; }
        [Column(Name = "DataType")]
        public string DataType { get; set; }
        [Column(Name = "Created")]
        public DateTime Created { get; set; }
    }
}