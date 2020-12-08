using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Net;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoorPage : ContentPage
    {
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;

        public DoorPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Async method to open a door
        /// Will send a POST request to api and receive a response back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OpenDoor (object sender, EventArgs e)
        {

            // set up the http objects
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (s, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(clientHandler);

            try
            {
                // send request to api and wait for response
                var url = "https://192.168.1.59:45456/api/users/door";
                var jsonData = new StringContent(JsonConvert.SerializeObject(Door_Pick.SelectedItem.ToString()), Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("private_key"));
                var response = await httpClient.PostAsync(url, jsonData);

                // if response successful then save private ket locally
                // then show a popup (display alert) with result before goin to homepage
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    //await SecureStorage.SetAsync("private_key", result);
                    await DisplayAlert("Successful", result, "Close");
                    //await Navigation.PushAsync(new AlarmPage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await DisplayAlert("Door Opened", "Success", "Ok");
        }   
    }
}