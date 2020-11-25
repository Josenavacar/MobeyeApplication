using System;
using System.Collections;
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
    [Route("api/devices/")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        public DeviceController()
        {
            
        }
    }
}