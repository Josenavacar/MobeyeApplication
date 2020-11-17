using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoorPage : ContentPage
    {
        public DoorPage()
        {
            InitializeComponent();
        }

        public void OpenDoor(object sender, EventArgs e)
        {
            DisplayAlert("Door Opened", "Success", "Ok");
        }
            
            
    }
}