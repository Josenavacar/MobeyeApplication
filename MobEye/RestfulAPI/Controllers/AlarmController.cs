using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //API- send message Mobeye input
        [HttpPost]
        public Alarm PostAlarm(AlarmPostModel alarm)
        {
            alarmContext.Alarms.Add(alarm);
            alarmContext.SaveChanges();
            return alarm;
        }
    }
}
