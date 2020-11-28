using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestfulAPI.Database;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [Route("api/messages/")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly AlarmContext alarmContext;

        public AlarmController(AlarmContext alarmContext)
        {
            this.alarmContext = alarmContext;
        }

        //API-send message get Mobeye input
        [HttpGet]
        public List<Alarm> GetAlarms()
        {
            return alarmContext.Alarms.Include(alarm => alarm.Recipients).ToList();
        }


        [HttpPost]
        public Alarm PostAlarm(AlarmPostModel alarm)
        {
            alarmContext.Alarms.Add(alarm);
            alarmContext.SaveChanges();
            return alarm;
        }

        [HttpPost("status")]
        public JObject PostStatus(JObject items)
        {
            //string answer = $"'Phone IMEI': '{status.User.DeviceImei}', 'private key': 'temp', 'Message ID': '{status.Alarm.MessageID}', 'Status': '{status.Alarm.Status}'";

            //string answer = $"'Phone IMEI': '{sender.DeviceImei}'";
            //string answer = $"'Phone IMEI': '{alarm.MessageID}'";

            //JObject jsonAnswer = JObject.Parse(answer);

            return (JObject)items;
        }
    }
}
