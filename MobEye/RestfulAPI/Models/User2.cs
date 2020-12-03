using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class User2 : User
    {
        public User2(int userPhoneNumber, string deviceImei) : base(userPhoneNumber, deviceImei)
        {
            
        }

        public User2(String deviceImei) : base(deviceImei)
        {

        }
    }
}
