using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    interface ITraceable
    {
        // Properties som måste implementeras av klasser som implementerar ITraceable
        public PostOffice CurrentLocation { get; set; }

        public int TrackingNumber { get; set; }

        // Metod som måste implementeras av klasser som implementerar ITraceable
        public void UpdateLocation(PostOffice newLocation);

        // En metod som har en implementation måste inte skapas i klasser som implementerar ITraceable, t.ex:
        public void MethodWithImplementation()
        {
            //Implementationskod för metoden
        }
    }
}