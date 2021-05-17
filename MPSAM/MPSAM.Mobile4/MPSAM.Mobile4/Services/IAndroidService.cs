using System;
using System.Collections.Generic;
using System.Text;

namespace MPSAM.Mobile4.Services
{
    public interface IAndroidService
    {
        event EventHandler NewDataGot;
        String GetDeviceModel();

       

    }
}
