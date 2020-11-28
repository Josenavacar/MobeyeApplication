using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MobEye.Controls;
using MobEye.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(OTPAutoFillControl), typeof(OTPAutoFillControlRenderer))]
namespace MobEye.iOS
{
    public class OTPAutoFillControlRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.TextContentType = UITextContentType.OneTimeCode;
            }
        }
    }
}