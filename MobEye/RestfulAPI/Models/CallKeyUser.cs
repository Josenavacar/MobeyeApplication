using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestfulAPI.Models
{
    public class CallKeyUser
    {
        [Key]
        public int ID { get; set; }
        public int accessCode { get; set; }
        public int deviceIMEI { get; set; } // required for first time login
        public int phoneNumber { get; set; } //required for first time login
        [NotMapped]
        public List<int> doorCodes {get; set;}

        public CallKeyUser()
        {

        }
        // first time login
        public CallKeyUser(int deviceIMEI, int phoneNumber, List<int> doorCodes)
        {
            this.accessCode = SetAccessCode();
            this.deviceIMEI = deviceIMEI;
            this.phoneNumber = phoneNumber;
            this.doorCodes = doorCodes;
        }
        public void AddDoor(int doorCode)
        {
            this.doorCodes.Add(doorCode);
        }
        public Boolean OpenDoor(int doorCode)
        {
            foreach(var door in doorCodes)
            {
                if (door == doorCode)
                {
                    return true;
                }
            }
            return false;
        }

        // we don't know yet how exactly this code will be generated, so I made it random
        public int SetAccessCode()
        {
            Random rnd = new Random();
            return rnd.Next(100, 1000);
        }
    }
}
