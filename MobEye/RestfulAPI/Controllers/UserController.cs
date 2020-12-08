using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestfulAPI.Database;
using RestfulAPI.Models;
using RestfulAPI.Services;

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

        //https://localhost:44349/api/users/registration
        [HttpPost("registration")]
        public JValue PostRegisterUser([FromBody] JValue data)
        {
            var random = new Random();
            string privateKey = string.Empty;
            int length = 5;

            for (int i = 0; i < length; i++)
            {
                privateKey = String.Concat(privateKey, random.Next(10).ToString());
            }

            return (JValue)privateKey;
        }


        //https://localhost:44349/api/users/door
        [HttpPost("door")]
        public JValue PostDoorUser([FromBody] JValue data)
        {
            

            return (JValue)Request.Headers["Authorization"].ToString();
        }
    }
}
