using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobEye
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();
        }
        void ConfirmAlarm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Alarm confirmed";
        }
        void SkipAlarm(object sender, EventArgs e)
        {
            (sender as Button).Text = "Alarm skipped";
        }
        void SendMessage (object sender, EventArgs e)
        {
            (sender as Button).Text = "Message sent";
        }
    }
}