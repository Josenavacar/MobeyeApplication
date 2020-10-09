using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobEye.Views;
using Xamarin.Essentials;
using System.Windows.Input;

namespace MobEye
{
    public partial class App : Application
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        // change bool value depending on which page you want to access (alarm or no alarm)
        bool alarmActive = true;

        public App()
        {
            InitializeComponent();
            BindingContext = this;

            if (alarmActive)
            {
                MainPage = new AlarmPage();
            }
            else
            {
                MainPage = new LoginPage();
                //MainPage = new MainPage();
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
