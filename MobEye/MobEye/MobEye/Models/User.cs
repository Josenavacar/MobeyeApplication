using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }

        public List<Device> Devices { get; set; } 

        public User() { }
        public User(string Username, string Password, Role role,List<Device>devices)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = role;
            this.Devices = devices;
        }

        public bool CheckInformation()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
        }
    }
}
