using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulAPI.Models;


namespace RestfulAPI.Services
{
    public interface IRegistration 
    {
        Task<string> Register(String code, long imei);
    }
}