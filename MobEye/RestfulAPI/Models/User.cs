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
        public int UserPhoneNumber { get; set; }
        public string DeviceImei { get; set; }

        public User(int userPhoneNumber, string deviceImei)
        {
            this.UserPhoneNumber = userPhoneNumber;
            this.DeviceImei = deviceImei;
        }

        public User(string deviceImei)
        {
            this.DeviceImei = deviceImei;
        }
    }
}
