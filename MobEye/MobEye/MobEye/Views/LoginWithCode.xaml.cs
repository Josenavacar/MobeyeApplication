using MobEye.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobEye.Services;
using MobEye.Responses;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithCode : ContentPage
    {
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        RegistrationAndAuthorizationService registrationAndAuthorizationService;

        public LoginWithCode(string message)
        {
            InitializeComponent();
            Label_Message.Text = message;
            registrationAndAuthorizationService = new RegistrationAndAuthorizationService();
        }

        /// <summary>
        /// Async method to handle the user login (user 2 and user 3)
        /// Will send a POST request to api
        /// Mobeye will authenticate user and response back with a private key to use for every future POST requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignIn(object sender, EventArgs e)
        {
            SecureStorage.Remove("role");
            String code = Entry_Code.Text;

            if(code == "11111")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID.aaaa1111.ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID.aaaa1111.ToString());
                Application.Current.Properties["phoneCode"] = code;
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                
                if(await SecureStorage.GetAsync("role") == "Account")
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else if (code == "22222")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID.bbbb2222.ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID.bbbb2222.ToString());
                Application.Current.Properties["phoneCode"] = code;
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                if (await SecureStorage.GetAsync("role") == "Account")
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else if (code == "33333")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID.cccc3333.ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID.cccc3333.ToString());
                Application.Current.Properties["phoneCode"] = code;
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new AlarmPage());
                }
            }
            else if (code == "44444")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID.dddd4444.ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID.dddd4444.ToString());
                Application.Current.Properties["phoneCode"] = code;
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new DoorPage());
                }
            }
            else if (code == "55555")
            {
                var register = registrationAndAuthorizationService.Register(PhoneID.eeee5555.ToString(), code);
                await SecureStorage.SetAsync("phone_id", PhoneID.eeee5555.ToString());
                Application.Current.Properties["phoneCode"] = code;
                await registrationAndAuthorizationService.Authorization(await SecureStorage.GetAsync("phone_id"), await SecureStorage.GetAsync("private_key"));
                if (await SecureStorage.GetAsync("role") == "Standard")
                {
                    await Navigation.PushAsync(new AlarmPage());
                }
            }
            else
            {
                await DisplayAlert("Error", "Please enter the correct code", "Close");
            }
        }

        /// <summary>
        /// Method to get a new code?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResendCode(object sender, EventArgs e)
        {
            DisplayAlert("Code resent", "Your code has been resend, it could take up to 5 minutes to arrive!", "Close");
        }


        /// <summary>
        /// Method to open login page (with an mobeye account)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginMobeye(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginWithMobeyeAccount());
        }
    }
}