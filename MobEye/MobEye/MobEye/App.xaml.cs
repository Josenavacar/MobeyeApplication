using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye
{
    public partial class App : Application
    {
        // change bool value depending on which page you want to access (alarm or no alarm)
        bool alarmActive = true;
        public App()
        {
            InitializeComponent();

            if (alarmActive)
            {
                MainPage = new AlarmPage();
            }
            else
            {
                MainPage = new MainPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
