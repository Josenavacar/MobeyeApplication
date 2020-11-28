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
        public IEnumerable<User> GetUsers()
        {
            return userContext.Users.ToList();
        }

        //https://localhost:44349/api/users/1/
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            User user = userContext.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //https://localhost:44349/api/users/
        [HttpPost]
        public User PostUser(User user)
        {
            userContext.Users.Add(user);
            userContext.SaveChangesAsync();
            return user;
        }

        //https://localhost:44349/api/users/login
        [HttpPost("login")]
        public IEnumerable LoginUser([FromBody] User user)
        {
            var users = userContext.Users.ToList();

            foreach (User u in users)
            {
                if ((user.Username == u.Username) && (user.Password == u.Password))
                {
                    return "success";
                }
            }

            return null;
        }
    }
}
