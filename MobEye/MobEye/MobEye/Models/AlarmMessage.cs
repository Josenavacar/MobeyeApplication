using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class AlarmMessage
    {
        //[Key]
        public int ID { get; set; }
        public string deviceName { get; set; }
        public string location { get; set; }
        public string alarmText { get; set; }

        public string accountId { get; set; }
    }
}
