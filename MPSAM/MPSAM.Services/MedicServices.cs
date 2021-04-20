using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Services
{

    public class MedicServices
    {
        //here is applied Singleton Design Pattern
        public static MedicServices ClassObject
        {
            get
            {
                if (privateInMemoryObject == null) privateInMemoryObject = new MedicServices();
                return privateInMemoryObject;
            }
        }
        private static MedicServices privateInMemoryObject { get; set; }
        private MedicServices()
        {
        }
    }
}
