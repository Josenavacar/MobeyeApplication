using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobEye.Models;
using RestfulAPI.Database;
using RestfulAPI.Models;


namespace RestfulAPI.Controllers
{
    [Route("api/users/callkey/")]
    [ApiController]
    public class CallKeyUserController : ControllerBase
    {
        private readonly CallKeyUserContext usersOfType3;

        public CallKeyUserController(CallKeyUserContext userType3Context)
        {
            this.usersOfType3 = userType3Context;
        }

        //https://localhost:44349/api/users/callkey/
        [HttpGet]
        public IEnumerable<CallKeyUser> GetUsers()
        {
            return usersOfType3.CallKeyUsers.ToList();
        }

        //https://localhost:44349/api/users/callkey/1
        [HttpGet("{id}")]
        public CallKeyUser GetUser(int id)
        {
            CallKeyUser user = usersOfType3.CallKeyUsers.Find(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //https://localhost:44349/api/users/callkey/
        [HttpPost]
        public CallKeyUser PostUser([FromBody] CallKeyUser user)
        {
            usersOfType3.CallKeyUsers.Add(user);
            usersOfType3.SaveChangesAsync();
            return user;
        }


        // get the IMEI's of the doors that the user has access to
        //https://localhost:44349/api/users/callkey/doors/1/
        [HttpGet("doors/{id}")]
        public List<int> GetUserDoors(int id)
        {
            CallKeyUser user = usersOfType3.CallKeyUsers.Find(id);

            if (user == null)
            {
                return null;
            }

            return user.doorCodes;
        }

        // add another door to the user
        //https://localhost:44349/api/users/callkey/doors/add/
        [HttpPost("doors/add")]
        public IEnumerable AddDoorToUser([FromBody] int id, int doorCode)
        {
            CallKeyUser user = usersOfType3.CallKeyUsers.Find(id);

            if (user == null)
            {
                return null;
            }

            user.doorCodes.Add(doorCode);
            return "success";
        }
    }
}
