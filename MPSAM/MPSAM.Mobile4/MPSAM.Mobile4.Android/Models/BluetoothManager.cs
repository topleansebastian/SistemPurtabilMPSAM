using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPSAM.Mobile4.Droid.Models
{
    public class BluetoothManager
    {
        public static BluetoothManager Instance = new BluetoothManager();

        private const String UID = "RN42-DA6C";
        private BluetoothDevice result;
        private BluetoothSocket mSocket;
        private BufferedReader reader;
        private System.IO.Stream mStream;
        private InputStreamReader mreader;

        private BluetoothManager() {

            timer.Interval = 10000;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();
        
        }





     
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var data = new System.Random().Next(0,100).ToString();
            if (!String.IsNullOrEmpty(data))
                DataString = data;

        }



        public String GetDataString() => DataString;

        public String DataString = "";


        private System.Timers.Timer timer = new System.Timers.Timer();

        private UUID getUUIDFromString() => UUID.FromString(UID);
        private void openDeviceConnection(BluetoothDevice btDevice)
        {
            try
            {
                mSocket = btDevice.CreateRfcommSocketToServiceRecord(getUUIDFromString());
                mSocket.Connect();

                mStream = mSocket.InputStream;
                mreader = new InputStreamReader(mStream);

                reader = new BufferedReader(mreader);

            }
            catch(Exception exp)
            {
                close(mSocket);
                close(mStream);
                close(mreader);
                throw exp;
            }
        }

        private void close(IDisposable aConnectedObject)
        {
            if (aConnectedObject == null) return;
            try
            {
                aConnectedObject.Dispose();
            }
            catch(Exception exp)
            {
                throw exp;
            }
            aConnectedObject = null;
        }


        public void getAllPairedDevices()
        {
            BluetoothAdapter btAdapter = BluetoothAdapter.DefaultAdapter;
            var devices = btAdapter.BondedDevices;
            if(devices != null && devices.Count > 0)
            {
                foreach(BluetoothDevice mDevice in devices){
                    openDeviceConnection(mDevice);
                }
            }
        }

        public String getDataFromDevice()
        {
            return reader.ReadLine();
        }
    }
}