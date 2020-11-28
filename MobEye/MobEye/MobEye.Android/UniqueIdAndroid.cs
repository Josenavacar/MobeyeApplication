using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobEye.Droid;
using Xamarin.Forms;
using MobEye.Models;

[assembly:Xamarin.Forms.Dependency(typeof(UniqueIdAndroid))]
namespace MobEye.Droid
{
    public class UniqueIdAndroid:IDevice
    {
        public string GetIdentifier() 
        {
            return Settings.Secure.GetString(Forms.Context.ContentResolver, Settings.Secure.AndroidId);
        }
    }
}