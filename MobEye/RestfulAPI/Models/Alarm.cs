﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class Alarm
    {
        [Key]
        public int MessageID { get; set; }

        //the name of the device
        public string DeviceName { get; set; }

        //the location of the device
        public string Location { get;  set; }

        //alarm text
        public string AlarmText { get; set; }

        //SET/RESET
        public string SetReset { get; set; }

        //priority of the alarm message (0=alert,1=alarm)
        public int Priority { get; set; }

        //date and time of the alarm
        public DateTime DateTime { get; set; }

        //array of recipients id's (imei/phone number)
        public virtual List<User> Recipients { get; set; }

        //if no escalation is required, all recipients get the message at the same time
        public bool Escalation { get; set; }

        //if the message is related to a limit violation, this can be included (not required)
        public string Value { get; set; }
        public Status Status { get; set; }

        public Alarm(int messageID, string deviceName, string location, string alarmText, string setReset, int priority, DateTime dateTime, List<User> recipients, bool escalation, Status status, string value="none")
        {
            MessageID = messageID;
            DeviceName = deviceName;
            Location = location;
            AlarmText = alarmText;
            SetReset = setReset;
            Priority = priority;
            DateTime = dateTime;
            Recipients = recipients;
            Escalation = escalation;
            Value = value;
            Status = status;
        }

        public Alarm()
        {
        }
    }
}
