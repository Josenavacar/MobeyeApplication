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

namespace MobEye
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        private const String url = "https://localhost:44349/api/Alarm";
        private HttpClient httpClient = new HttpClient();
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

        protected override async void OnAppearing()
        {
            //var content = await httpClient.GetStringAsync(url);
            //var alarmMessage = JsonConvert.DeserializeObject<List<AlarmMessage>>(content);

            //alarmMessages = new ObservableCollection<AlarmMessage>(alarmMessage);

            //Message_List.ItemsSource = alarmMessages;

            //base.OnAppearing();
        }
    }
}