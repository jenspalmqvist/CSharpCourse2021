using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostalService.InputHelper;

namespace PostalService
{
    class PostalOrganization
    {
        public List<PostOffice> PostOffices { get; set; } = new List<PostOffice>();

        public PostOffice SelectPostOffice()
        {
            Console.WriteLine("Tillängliga postkontor:");
            for (int i = 0; i < PostOffices.Count; i++)
            {
                // 'i + 1' är för att vi vill visa en lista som börjar med siffran 1 istället för 0
                Console.WriteLine($"{i + 1}. {PostOffices[i].OfficeName}");
            }
            int selection = InputHelper.GetInt("Välj ett av alternativen ovan: ", min: 1, max: PostOffices.Count);
            // -1 är för att välja rätt index i listan trots att vår numrerade lista här ovan börjar på 1;
            return PostOffices[selection - 1];
        }

        public void SendParcels()
        {
            foreach (PostOffice office in PostOffices)
            {
                foreach (Parcel parcel in office.OutgoingParcels)
                {
                    /* Find går igenom alla objekt i listan PostOffices och returnerar det kontoret som
                     * har ett lägre HandlesZipCodesFrom och ett högre HandlesZipCodesUpTo än paketet 'parcel' från foreach-loopen
                     */
                    var recievingOffice = PostOffices.Find(office =>
                                            parcel.RecipientAddress.ZipCode > office.HandlesZipCodesFrom
                                            && parcel.RecipientAddress.ZipCode < office.HandlesZipCodesUpTo);
                    // Om försändelsen är spårbar, uppdatera platsen den befinner sig på
                    if (parcel is ITraceable)
                    {
                        // Låter oss jobba med parcel som en ITraceable utan att behöva använda mellanvariabler
                        (parcel as ITraceable).UpdateLocation(recievingOffice);
                    }
                    // Lägger till paketet i listan över inkommande paket i kontoret ovan
                    recievingOffice.RecievedParcels.Add(parcel);
                }
                // Tömmer listan med utgående försändelser i kontoret där vi nyss gick igenom den.
                office.OutgoingParcels.Clear();
            }
        }

        public string TrackParcel(int trackingNumber)
        {
            var traceableParcels = new List<ITraceable>();

            // linq-sättet att hitta alla försändelser som implementerar ITraceable och lägga dem i en lista med ITraceables
            foreach (PostOffice office in PostOffices)
            {
                traceableParcels.AddRange(office.OutgoingParcels.Where(parcel => parcel is ITraceable)
                                                             .Select(parcel => parcel as ITraceable)
                                                             .ToList());
                traceableParcels.AddRange(office.RecievedParcels.Where(parcel => parcel is ITraceable)
                                                             .Select(parcel => parcel as ITraceable)
                                                             .ToList());
            }

            // icke-linq sättet att göra samma som ovan
            //foreach (PostOffice office in PostOffices)
            //{
            //    foreach (Parcel parcel in office.OutgoingParcels)
            //    {
            //        if (parcel is ITraceable)
            //        {
            //            traceableParcels.Add(parcel as ITraceable);
            //        }
            //    }
            //    foreach (Parcel parcel in office.RecievedParcels)
            //    {
            //        if (parcel is ITraceable)
            //        {
            //            traceableParcels.Add(parcel as ITraceable);
            //        }
            //    }
            //}
            // Söker upp paketet med samma spårningsnummer som det vi skickar in och hämtar den nuvarande platsens namn
            string currentLocation = traceableParcels.Find(parcel => parcel.TrackingNumber == trackingNumber).CurrentLocation.OfficeName;
            return currentLocation;
        }
    }
}