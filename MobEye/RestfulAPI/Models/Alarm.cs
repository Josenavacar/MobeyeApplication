using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class Alarm
    {
        [Key]
        public int ID { get; set; }
        public string deviceName { get; private set; }
        public string location { get; private set; }
        public string alarmText { get; private set; }
        
        public string accountId { get; private set; }

        public Alarm(string deviceName, string location, string alarmText, string accountId)
        {
            this.deviceName = deviceName;
            this.location = location;
            this.alarmText = alarmText;
            this.accountId = accountId;
        }
        public Alarm()
        {
            
        }




    }
}
