using MobEye.Responses;
using MobEye.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        AlarmService alarmService = new AlarmService();

        public HomePage()
        {
            InitializeComponent();

            //alarmService.CheckForAlarms();
        }

        protected override void OnAppearing() 
        {
            //Lbl_Device_Info.Text = "";
            //Lbl_Alarm_Info.Text = "";
        }


        /// <summary>
        /// Method to direct user to Mobeye's portal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPortal(object sender, EventArgs e)
        {
            //'Device.OpenUri(Uri)' is obsolete: 'OpenUri is obsolete as of version 4.3.0. Use Launcher.OpenAsync (or CanOpenAsync, or TryOpenAsync) from Xamarin.Essentials instead.'
            Device.OpenUri(new Uri("https://www.mymobeye.eu/"));
        }

        private void OpenAlarmPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlarmPage());
        }

        /// <summary>
        /// Method to go to door page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoteControlPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DoorPage());
        }
    }
}
