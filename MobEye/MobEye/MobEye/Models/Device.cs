using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class Device
    {
        int id;
        string deviceName;
        Command command;

        public Device()
        {

        }
        public Device(int id, string deviceName, Command command)
        {
            this.id = id;
            this.deviceName = deviceName;
            this.command = command;
        }

        public int Id
        {
            get;
            set;
        }
        public string DeviceName
        {
            get;
            set;
        }
        public Command Command
        {
            get;
            set;
        }
    }
}
