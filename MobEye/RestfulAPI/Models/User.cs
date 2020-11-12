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
        public string username { get; set; }
        public string password { get; set; }
        public int userPhoneNumber { get; set; }
        public string deviceImei { get; set; }

        public User(String username, String password, int userPhoneNumber, String deviceImei)
        {
            this.username = username;
            this.password = password;
            this.userPhoneNumber = userPhoneNumber;
            this.deviceImei = deviceImei;
        }

        public User()
        {

        }
    }
}
