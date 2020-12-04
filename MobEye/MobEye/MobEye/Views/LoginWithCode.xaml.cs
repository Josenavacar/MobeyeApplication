using MobEye.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithCode : ContentPage
    {
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;

        public LoginWithCode(string message)
        {
            InitializeComponent();
            Label_Message.Text = message;
        }
        private async void SignIn(object sender, EventArgs e)
        {
            try
            {
                // set up the http objects
                clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslPolicyErrors) => { return true; };
                httpClient = new HttpClient(clientHandler);

                // send request to api and wait for response
                var url = "https://145.93.44.225:45456/api/users/registration";
                var jsonData = new StringContent(JsonConvert.SerializeObject(Entry_Code.Text), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, jsonData);

                // if response successful then save private ket locally
                // then show a popup (display alert) with result before goin to homepage
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Preferences.Set("private_key", result);
                    Entry_Code.Text = Preferences.Get("private_key", "");
                    await DisplayAlert("Successful", result, "Close");
                    await Navigation.PushAsync(new HomePage());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //User user = new User("user3", Entry_Code.Text, Role.STANDARDU3);
            //if (user.CheckInformation())
            //{
            //    await Navigation.PushAsync(new AlarmPage());
            //}
            //else
            //{
            //    await DisplayAlert("Empty code", "Enter your code to login!", "Close");
            //}
        }

        private void ResendCode(object sender, EventArgs e)
        {
            DisplayAlert("Code resent", "Your code has been resend, it could take up to 5 minutes to arrive!", "Close");
        }
    }
}