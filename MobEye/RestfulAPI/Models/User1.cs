using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User1 : User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int[] DoorID { get; set; }

        public User1(int[] doors, String username, String password, int userPhoneNumber, string deviceImei) : base(userPhoneNumber, deviceImei)
        {
            this.Username = username;
            this.Password = password;
            this.DoorID = doors;
        }

        public User1(int[] doors, String username, String password, string deviceImei) : base(deviceImei)
        {
            this.Username = username;
            this.Password = password;
            this.DoorID = doors;
        }


    }
}
