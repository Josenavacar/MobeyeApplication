using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class Device
    {
        private int id;
        private string deviceName;
        private Command command;

        /// <summary>
        /// Device constructor
        /// </summary>
        public Device()
        {

        }

        /// <summary>
        /// Constructor for devices
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceName"></param>
        /// <param name="command"></param>
        public Device(int id, string deviceName, Command command)
        {
            this.id = id;
            this.deviceName = deviceName;
            this.command = command;
        }

        /// <summary>
        /// ID property
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Device name property
        /// </summary>
        public string DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// Door command property
        /// </summary>
        public Command Command
        {
            get;
            set;
        }
    }
}
