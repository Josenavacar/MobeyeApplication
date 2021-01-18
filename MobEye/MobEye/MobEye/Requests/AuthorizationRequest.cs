using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Requests
{
    class AuthorizationRequest
    {
        public String phoneId { get; set; }
        public String privateKey { get; set; }

        public AuthorizationRequest(String phoneId,String privateKey)
        {
            this.phoneId = phoneId;
            this.privateKey = privateKey;
        }
        //"phoneId":"aaaa1111",
//"privateKey":"pkaaaa1111"
    }
}
