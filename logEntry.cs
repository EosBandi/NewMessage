using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.NewMessage
{
    class logEntry
    {
        public DateTime Time { get; set; }
        public Byte sysid { get; set; }
        public String MessageText { get; set; }
        public String SeverityText { get; set; }
        [Browsable(false)] public int Severity { get; set; }
        public int Repeats { get; set; }




        public logEntry(DateTime time, string message, int severity, byte systemID = 1)
        {

            string[] severityNames = new string[] { "EMERGENCY", "ALERT", "CRITICAL", "ERROR", "WARNING", "NOTICE", "INFO", "DEBUG" };
            Time = time;
            MessageText = message;
            SeverityText = severityNames[severity];
            Severity = severity;
            sysid = systemID;
        }


    }

}
