using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class AlarmMessage
    {
        //[Key]
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public string Location { get; set; }
        public string AlarmText { get; set; }
        public string Value { get; set; }
        public DateTime DateTime { get; set; }
        public string AccountId { get; set; }

        public AlarmMessage()
        {

        }

        public AlarmMessage(string deviceName, string location, string alarmText, string accountId, string value, DateTime dateTime)
        {
            this.DeviceName = deviceName;
            this.Location = location;
            this.AlarmText = alarmText;
            this.AccountId = accountId;
            this.Value = value;
            this.DateTime = dateTime;
        }
    }
}
