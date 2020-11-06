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
    public partial class LoginWithCode : ContentPage
    {
        public LoginWithCode(string message)
        {
            InitializeComponent();
            Label_Message.Text = message;
        }
        private async void SignIn(object sender, EventArgs e)
        {
            User user = new User("user3", Entry_Code.Text);
            if (user.CheckInformation())
            {
                await Navigation.PushAsync(new AlarmPage());
            }
            else
            {
                await DisplayAlert("Empty code", "Enter your code to login!", "Close");
            }
        }

        private void ResendCode(object sender, EventArgs e)
        {
            DisplayAlert("Code resent", "Your code has been resend, it could take up to 5 minutes to arrive!", "Close");
        }
    }
}