using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulAPI.Models.Tests
{
    [TestClass()]
    public class AlarmTests
    {
        [TestMethod()]
        public void EmptyConstructorTest()
        {
            Alarm alarm = new Alarm();
            Assert.IsNotNull(alarm);
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            Alarm alarm = new Alarm("alarm1", "Eindhoven", "Temperature is too high", "123");
            Assert.AreEqual(alarm.deviceName, "alarm1");
            Assert.AreEqual(alarm.location, "Eindhoven");
            Assert.AreEqual(alarm.alarmText, "Temperature is too high");
            Assert.AreEqual(alarm.accountId, "123");
        }

        [TestMethod()]
        public void SetDeviceNameTest()
        {
            Alarm alarm = new Alarm();
            alarm.deviceName = "alarm1";
            Assert.AreEqual(alarm.deviceName, "alarm1");
        }

        [TestMethod()]
        public void SetLocationTest()
        {
            Alarm alarm = new Alarm();
            alarm.location = "Eindhoven";
            Assert.AreEqual(alarm.location, "Eindhoven");
        }

        [TestMethod()]
        public void SetAlarmTextTest()
        {
            Alarm alarm = new Alarm();
            alarm.alarmText = "Temperature is too high";
            Assert.AreEqual(alarm.alarmText, "Temperature is too high");
        }

        [TestMethod()]
        public void SetAccountIdTest()
        {
            Alarm alarm = new Alarm();
            alarm.accountId = "123";
            Assert.AreEqual(alarm.accountId, "123");
        }



    }
}