using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobEye.Models;
using System.Windows.Input;
using Xamarin.Essentials;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                //Title, Message, Cancel
                DisplayAlert("Login", "Login Success", "Oke");
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password", "Oke");
            }
        }

        private async void BypassLoginButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmPage());
        }
    }
}