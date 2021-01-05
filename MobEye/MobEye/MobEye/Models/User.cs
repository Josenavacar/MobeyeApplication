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

        // User 2
        public User() { }

        // User 3
        public User(string Username, string Password, Role role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = role;
        }

        // User 1
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
