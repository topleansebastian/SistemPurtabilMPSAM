using MPSAM.Mobile4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MPSAM.Mobile4.Models
{
    public class AndroidEventReceiver : IAndroidEventReceiver
    {
        public event EventHandler ButtonStateChanged;


        public static AndroidEventReceiver Instance = new AndroidEventReceiver();
        public AndroidEventReceiver()
        {

        }


        public void FireEvent(object data)
        {

            MessagingCenter.Send("event", "Hello");
            //ButtonStateChanged(data, null);
        }
    }
}
