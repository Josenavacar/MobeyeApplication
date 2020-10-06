using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class Alarm
    {
        private string deviceName { get; set; }
        private string location { get; set;}
        private string alarmText { get; set; }
        private int[] recipients { get; set; }
        private string accountId { get; set; }

        public Alarm(string deviceName, string location, string alarmText, int[] recipients, string accountId)
        {
            this.deviceName = deviceName;
            this.location = location;
            this.alarmText = alarmText;
            this.recipients = recipients;
            this.accountId = accountId;
        }
        public Alarm()
        {
            this.recipients = new int[20];
        }

       

   
    }
}
