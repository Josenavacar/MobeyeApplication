using System;
using MobEye.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net.Http.Headers;
using MobEye.Services;
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

        protected override async void OnAppearing()
        {

            if (await SecureStorage.GetAsync("door_status") == "Opened")
            {
                Lbl_Status.Text = "OPENED";
            }

            Door_Pick.ItemsSource = null;
            List<String> devices = new List<string>();
            
            devices.Add((await SecureStorage.GetAsync("device")).ToString());
            Door_Pick.ItemsSource = devices;
            if(devices.Count == 0)
            {
                Btn_Open_Door.IsEnabled = false;
            }
            //Door_Pick.Items.Add("asd");

        }
        /// <summary>
        /// Async method to open a door
        /// Will send a POST request to api and receive a response back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OpenDoor (object sender, EventArgs e)
        {
            //SecureStorage.Remove("door_status");
            DeviceControlService deviceControlService = new DeviceControlService();
            String phoneId = Application.Current.Properties["phoneId"].ToString();
            String device = Door_Pick.SelectedItem.ToString();
            String privateKey = await SecureStorage.GetAsync("private_key");
            String command = Models.Command.DO1.ToString();
            String result = await deviceControlService.SendCommand(phoneId, device, privateKey, command);
            Console.WriteLine(result);
            if (result.Equals("Received"))
            {
                Lbl_Status.Text = "CLOSED";
            }

            await DisplayAlert("Door Opened", result, "Ok");
            Lbl_Status.Text = "CLOSED";
        }   

    }
}