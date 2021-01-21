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
using MobEye.Services;
using Xamarin.Essentials;
using MobEye.Responses;

namespace MobEye
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        private const String url = "https://192.168.1.59:45458/api/messages/";
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        private ObservableCollection<AlarmMessage> alarmMessages;
        ConfirmAlarmService confirmAlarmService;
        private const String url = "https://192.168.1.59:45457/api/messages/";
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        private ObservableCollection<AlarmMessage> alarmMessages;
        AlarmService alarmService = new AlarmService();

        public AlarmPage()
        {
            InitializeComponent();
            confirmAlarmService = new ConfirmAlarmService();
        }

        /// <summary>
        /// Method to confirm alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ConfirmAlarm(object sender, EventArgs e)
        {
            int messageID = 1;
            String phoneID = await SecureStorage.GetAsync("phone_id");
            String privateKey = await SecureStorage.GetAsync("private_key");
            String responseStatus = "Confirmed";
            String result = await confirmAlarmService.ConfirmAlarm(phoneID, messageID, responseStatus, privateKey);
            await DisplayAlert("Success", result, "Close");
            alarmMessages.Clear();
            (sender as Button).Text = "Alarm confirmed";
        }

        /// <summary>
        /// Method to skip alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SkipAlarm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Alarm skipped";
        }

        /// <summary>
        /// Async method to display alarm message when page is opened
        /// </summary>
        protected override async void OnAppearing()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(clientHandler);

            var content = await httpClient.GetStringAsync(url);
            var newAlarmMessage = JsonConvert.DeserializeObject<List<AlarmMessage>>(content);

            //var newAlarmMessage = alarmService.CheckForAlarms();
            alarmMessages = new ObservableCollection<AlarmMessage>(newAlarmMessage);
            Message_List.ItemsSource = alarmMessages;
            base.OnAppearing();
        }
    }
}
