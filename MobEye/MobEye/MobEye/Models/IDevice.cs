using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    /// <summary>
    /// Interface for devices
    /// </summary>
    public interface IDevice
    {
        string GetIdentifier();
    }
}
