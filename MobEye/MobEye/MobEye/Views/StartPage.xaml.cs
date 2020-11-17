using System;
using System.Collections.Generic;
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
            await Navigation.PushAsync(new LoginWithCode("Setup with your SMS code"));
        }
    }
}