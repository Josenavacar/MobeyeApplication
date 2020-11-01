using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MobEye.Models;
using MobEye.Controls;

namespace MobEye
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        private const String url = "https://10.0.2.2:44349/api/Alarm";
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        private ObservableCollection<AlarmMessage> alarmMessages;

        public AlarmPage()
        {
            InitializeComponent();
        }
        public void ConfirmAlarm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Alarm confirmed";
        }

        public void SkipAlarm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Alarm skipped";
        }

        public void SendMessage (object sender, EventArgs e)
        {
            (sender as Button).Text = "Message sent";
        }

        protected override async void OnAppearing()
        {
            //deviceName.Text = "hhelo";
            //location.Text = "hhelo";
            //alarmText.Text = "hhelo";
            //accountId.Text = "hhelo";

            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(clientHandler);

            var content = await httpClient.GetStringAsync(url);
            var newalarmMessage = JsonConvert.DeserializeObject<List<AlarmMessage>>(content);
            alarmMessages = new ObservableCollection<AlarmMessage>(newalarmMessage);
            Message_List.ItemsSource = alarmMessages;
            base.OnAppearing();

            //var result = await GetApiResponse(url);

            //if (result.IsSuccessful)
            //{
            //    try
            //    {
            //        var alarmMessage = JsonConvert.DeserializeObject<AlarmMessage>(result.JsonResponse);
            //        deviceName.Text = alarmMessage.deviceName;
            //        location.Text = alarmMessage.location;
            //        alarmText.Text = alarmMessage.alarmText;
            //        accountId.Text = alarmMessage.accountId;
            //    }
            //    catch (Exception ex)
            //    {
            //        await DisplayAlert("Error", ex.Message, "OK");
            //    }
            //}
        }

        public async Task<ApiResponse> GetApiResponse(String url)
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httpClient = new HttpClient(clientHandler);
            using (httpClient)
            {
                // If response is good, then get the content, else return an erro message and reason of the error
                var request = await httpClient.GetAsync(url);

                if (request.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        JsonResponse = await request.Content.ReadAsStringAsync()
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        ErrorMessage = request.ReasonPhrase
                    };
                }
            }
        }
    }
}