using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User3 : User
    {
        public int[] DoorID { get; set; }

        public User3(int[] doors, int userPhoneNumber, string deviceImei) : base(userPhoneNumber, deviceImei)
        {
            this.DoorID = doors;
        }

        public User3(int[] doors, string deviceImei) : base(deviceImei)
        {
            this.DoorID = doors;
        }
    }
}
