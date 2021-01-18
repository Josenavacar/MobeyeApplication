using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobEye.Droid
{
    public static class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://mobeyeapp.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=Db2NSzubW1qnFHuHBew8JRno8mkV1UeWT2iuj7nKXAk=";
        public const string NotificationHubName = "MobeyeApp";
    }
}