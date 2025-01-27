﻿using System;
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
        private const String url = "https://192.168.1.59:45455/api/messages/";
        private HttpClient httpClient;
        private HttpClientHandler clientHandler;
        private ObservableCollection<AlarmMessage> alarmMessages;

        public AlarmPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to confirm alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConfirmAlarm(object sender, EventArgs e)
        {
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
            var newalarmMessage = JsonConvert.DeserializeObject<List<AlarmMessage>>(content);
            alarmMessages = new ObservableCollection<AlarmMessage>(newalarmMessage);
            Message_List.ItemsSource = alarmMessages;
            base.OnAppearing();
        }
    }
}