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
    [Route("api/callKeyUsers")]
    [ApiController]
    public class CallKeyUserController : ControllerBase
    {
        private readonly CallKeyUserContext usersOfType3;

        public CallKeyUserController(CallKeyUserContext userType3Context)
        {
            this.usersOfType3 = userType3Context;
        }

        //https://localhost:44349/api/callKeyUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallKeyUser>>> GetUsers()
        {
            return await usersOfType3.CallKeyUsers.ToListAsync();
        }

        //https://localhost:44349/api/callKeyUsers/1234
        [HttpGet("{id}")]
        public async Task<ActionResult<CallKeyUser>> GetUser(int id)
        {
            CallKeyUser user = await usersOfType3.CallKeyUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //https://localhost:44349/api/callKeyUsers/
        [HttpPost]
        public async Task<ActionResult<CallKeyUser>> PostUser(CallKeyUser user)
        {
            usersOfType3.CallKeyUsers.Add(user);
            await usersOfType3.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new {id = user.ID }, user);
        }


        // get the IMEI's of the doors that the user has access to
        //https://localhost:44349/api/callKeyUsers/doors/1234
        [HttpGet("{id}")]
        public async Task<ActionResult<List<int>>> GetUserDoors(int id)
        {
            CallKeyUser user = await usersOfType3.CallKeyUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user.doorCodes;
        }
        // add another door to the user
        //https://localhost:44349/api/callKeyUsers/addDoor
        [HttpPost("addDoor")]
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
