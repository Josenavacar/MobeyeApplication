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
    [Route("api/users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext userContext;

        public UserController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        //https://localhost:44349/api/users/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await userContext.Users.ToListAsync();
        }

        //https://localhost:44349/api/users/1/
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await userContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //https://localhost:44349/api/users/
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            userContext.Users.Add(user);
            await userContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.ID }, user);
        }
    }
}
