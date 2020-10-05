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

        public App()
        {
            InitializeComponent();
            BindingContext = this;

            //MainPage = new LoginPage();
            MainPage = new VerificationPage();
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
