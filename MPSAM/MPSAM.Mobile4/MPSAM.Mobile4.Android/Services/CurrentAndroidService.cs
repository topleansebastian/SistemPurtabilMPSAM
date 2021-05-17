using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MPSAM.Mobile4.Droid.Models;
using MPSAM.Mobile4.Droid.Services;
using MPSAM.Mobile4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(CurrentAndroidService))]
namespace MPSAM.Mobile4.Droid.Services
{
    public class CurrentAndroidService:IAndroidService
    {
        public Thread t;
        public CurrentAndroidService()
        {
            t = new Thread(shit);
      

            String data = null;

            var manager = BluetoothManager.Instance;
            //manager.getAllPairedDevices();

           
            
              
            t.IsBackground = true;
            t.Start();
        }

        
        public void shit()
        {
            while (true)
            {
                if (!String.IsNullOrEmpty(BluetoothManager.Instance.GetDataString()))
                {
                    NewDataGot(BluetoothManager.Instance.DataString, null);
                    BluetoothManager.Instance.DataString = null;
                }

            }
        }
    

        public String GetDeviceModel() => Android.OS.Build.Model + " Itsa me, mario";



     

        public event EventHandler NewDataGot;
    }
}