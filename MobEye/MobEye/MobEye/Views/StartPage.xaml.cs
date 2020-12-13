using MobEye.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void LoginMobeye(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginWithMobeyeAccount());
        }

        private async void LoginCode(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginWithCode("Setup With Your SMS Code"));
        }

        private async void DebugHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        void ChangeLanguage(object sender, EventArgs args)
        {
            Picker languageSelect = (Picker)sender;

            int language = languageSelect.SelectedIndex;

            switch(language) 
            {
                case 0:
                    AppResources.Culture = new CultureInfo("en");
                    Navigation.PushAsync(new StartPage());
                break;
                case 1:
                    AppResources.Culture = new CultureInfo("fr");
                    Navigation.PushAsync(new StartPage());
                break;
                case 2:
                    AppResources.Culture = new CultureInfo("nl");
                    Navigation.PushAsync(new StartPage());
                break;
                case 3:
                    AppResources.Culture = new CultureInfo("de");
                    Navigation.PushAsync(new StartPage());
                break;

            }
        }
    }
}