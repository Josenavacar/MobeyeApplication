using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobEye.Models;


namespace RestfulAPI.Services
{
    public interface IAuthorizationService 
    {
        Task<User> getAuthorization();
        Task SendPrivateKeyAndImei(long imei, string privateKey);
        
    }
}