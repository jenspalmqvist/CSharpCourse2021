using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    interface ITraceable
    {
        // Properties som måste finnas i klasser som implementerar ITraceable
        public PostOffice CurrentLocation { get; set; }

        public int TrackingNumber { get; set; }

        // Metod som måste implementeras i klasser som använder ITraceable
        public void UpdateLocation(PostOffice newLocation);

        // En metod som har en implementation (dvs innehåller kod/logik) måste inte finnas i klasserna som använder ITraceable, t.ex:
        public void MethodWithImplementation()
        {
            // Massa häftig kod
        }
    }
}