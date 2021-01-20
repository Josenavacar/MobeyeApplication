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


        /// <summary>
        /// Method to open login page (with a code)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginCode(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginWithCode("Setup With Your SMS Code"));
        }

        /// <summary>
        /// Method to open home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugHome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        /// <summary>
        /// Method to change app's language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ChangeLanguage(object sender, EventArgs args)
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

            }
        }
    }
}