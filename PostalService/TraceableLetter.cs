using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    class TraceableLetter : Letter, ITraceable
    {
        public PostOffice CurrentLocation { get; set; }
        public int TrackingNumber { get; set; }

        // Variabler som krävs av klassen vi ärver av (Letter) måste skickas in
        // när vi skapar ett nytt TraceableLetter för att sedan skickas in i : base()
        public TraceableLetter(Address senderAddress, Address recipientAddress, double weight, PostOffice currentLocation, int trackingNumber)
            : base(senderAddress, recipientAddress, weight)
        {
            CurrentLocation = currentLocation;
            TrackingNumber = trackingNumber;
        }

        public void UpdateLocation(PostOffice newLocation)
        {
            CurrentLocation = newLocation;
        }
    }
}