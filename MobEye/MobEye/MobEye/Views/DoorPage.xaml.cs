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

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoorPage : ContentPage
    {
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
            await DisplayAlert("Door Opened", "Success", "Ok");
        }   
    }
}