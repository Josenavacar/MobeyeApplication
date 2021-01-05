using MobEye.Models;
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
    public partial class LoginWithMobeyeAccount : ContentPage
    {
        public LoginWithMobeyeAccount()
        {
            InitializeComponent();
        }

        public async void SignIn(object sender, EventArgs e)
        {
            List<Models.Device> devices = new List<Models.Device>();

            User user = new User(Entry_Username.Text, Entry_Password.Text, Role.ADMIN, devices);
            if (user.CheckInformation())
            {
                await Navigation.PushAsync(new LoginWithCode("Set a code for the next login"));
            }
            else
            {
                await DisplayAlert("Enter your credentials", "Empty username or password!", "Close");
            }
        }
    }
}