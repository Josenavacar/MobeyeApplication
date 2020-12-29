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
            String code = Entry_Code.Text;
            Console.WriteLine(code);
            var register = await registrationAndAuthorizationService.Register("aaaa1111", code);
            Console.WriteLine(register.ToString()+" this is private key");
            String privateKey = register.ToString();
            Console.WriteLine(privateKey + " this is private key String");
            await SecureStorage.SetAsync("privateKey", privateKey);
            var secureStrogaePrivateKey = await SecureStorage.GetAsync("privateKey");
            Console.WriteLine(secureStrogaePrivateKey.ToString() + " this is secure storage");
            Application.Current.Properties["phoneCode"] = code;
            Console.WriteLine(Application.Current.Properties["phoneCode"]+"here");
            /*
            Console.WriteLine("predi try");
            try
            {
                // set up the http objects
                clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslPolicyErrors) => { return true; };
                httpClient = new HttpClient(clientHandler);

                if (Entry_Code.Text.Length == 6)
                {
                    User user3 = new User("user3", Entry_Code.Text, Role.STANDARDU3);

                    // send request to api and wait for response
                    var url = "https://192.168.1.59:45455/api/users/registration";
                    var jsonData = new StringContent(JsonConvert.SerializeObject(Entry_Code.Text), Encoding.UTF8, "application/json");
                    Console.WriteLine(jsonData);
                    var response = await httpClient.PostAsync(url, jsonData);
                    
                    Console.WriteLine(response);
                    

                    // if response successful then save private ket locally
                    // then show a popup (display alert) with result before goin to homepage
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        await SecureStorage.SetAsync("private_key", result);
                        await DisplayAlert("Successful", result, "Close");
                        await Navigation.PushAsync(new DoorPage());
                    }
                }
                else if(Entry_Code.Text.Length == 5)
                {
                    User user2 = new User("user2", Entry_Code.Text, Role.STANDARDU2);

                    // send request to api and wait for response
                    var url = "https://192.168.1.59:45455/api/users/registration";
                    var jsonData = new StringContent(JsonConvert.SerializeObject(Entry_Code.Text), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(url, jsonData);

                    // if response successful then save private ket locally
                    // then show a popup (display alert) with result before goin to homepage
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        await SecureStorage.SetAsync("private_key", result);
                        await DisplayAlert("Successful", result, "Close");
                        await Navigation.PushAsync(new AlarmPage());
                    }
                }
                else if(Entry_Code.Text.Length < 5)
                {
                    await DisplayAlert("Empty code", "Enter your code to login!", "Close");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption");
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
        */}

        /// <summary>
        /// Method to get a new code?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResendCode(object sender, EventArgs e)
        {
            DisplayAlert("Code resent", "Your code has been resend, it could take up to 5 minutes to arrive!", "Close");
        }
    }
}