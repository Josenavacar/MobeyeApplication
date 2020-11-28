using Microsoft.EntityFrameworkCore;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Database
{
    public class CallKeyUserContext : DbContext
    {
        public CallKeyUserContext(DbContextOptions<CallKeyUserContext> options) : base(options)
        {
        }

        public DbSet<CallKeyUser> CallKeyUsers
        {
            get;
            set;
        }
    }
}