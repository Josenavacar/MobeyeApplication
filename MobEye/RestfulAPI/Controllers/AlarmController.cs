using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly Notifications notifications;
        // Context is used here to mock a database
        private readonly UserContext userContext;
        public AlarmController(AlarmContext alarmContext, UserContext userContext)
        {
            this.alarmContext = alarmContext;
            this.userContext = userContext;
            this.notifications = new Notifications(userContext);
        }

        //API-send message get Mobeye input
        //https://localhost:44349/api/messages/
        [HttpGet]
        public List<Alarm> GetAlarms()
        {
            return alarmContext.Alarms.Include(alarm => alarm.Recipients).ToList();
        }

        //https://localhost:44349/api/messages/
        [HttpPost]
        public async Task<HttpResponseMessage> PostAlarm(AlarmPostModel alarm)
        {
            alarmContext.Alarms.Add(alarm);
            alarmContext.SaveChanges();
            var result = await this.notifications.sendToAll();
            //var result = await this.notifications.sendAlarm(alarm);
            Console.WriteLine("result is " + result.ToString());
            return new HttpResponseMessage(result);
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
