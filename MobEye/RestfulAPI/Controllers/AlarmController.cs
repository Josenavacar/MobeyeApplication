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

        //https://localhost:44349/api/messages/
        [HttpGet] 
        public IEnumerable<Alarm> GetAlarms()
        {
            return alarmContext.Alarms.ToList();
        }

        //https://localhost:44349/api/messages/
        [HttpPost]
        public Alarm PostAlarm(Alarm alarm)
        {
            alarmContext.Alarms.Add(alarm);
            alarmContext.SaveChangesAsync();
            return alarm;
        }
    }
}
