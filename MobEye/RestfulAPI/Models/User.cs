using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserPhoneNumber { get; set; }
        public string DeviceImei { get; set; }

        public User(string username, string password, int userPhoneNumber, string deviceImei)
        {
            this.Username = username;
            this.Password = password;
            this.UserPhoneNumber = userPhoneNumber;
            this.DeviceImei = deviceImei;
        }

        public User()
        {

        }

        public User(string deviceImei)
        {
            this.DeviceImei = deviceImei;
        }
    }
}
