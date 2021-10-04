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
                // i + 1 är för att vi vill att vår numrerade lista ska börja på 1 och inte 0.
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
                     * har ett högre HandlesZipCodesFrom och ett lägre HandlesZipCodesUpTo än paketet
                     * parcel från den inre foreach-loopen
                     */
                    var recievingOffice = PostOffices.Find(office => parcel.RecipientAddress.ZipCode > office.HandlesZipCodesFrom
                                            && parcel.RecipientAddress.ZipCode < office.HandlesZipCodesUpTo);

                    // Icke-Linq alternativ till Find() ovan:
                    // foreach (PostOffice office2 in PostOffices)
                    // {
                    //    if (office2.HandlesZipCodesFrom < parcel.RecipientAddress.ZipCode
                    //       && office2.HandlesZipCodesUpTo > parcel.RecipientAddress.ZipCode)
                    //    {
                    //        recievingOffice = office2;
                    //        break;
                    //    }
                    // }

                    if (parcel is ITraceable)
                    {
                        (parcel as ITraceable).UpdateLocation(recievingOffice);
                        // Samma fast annorlunda
                        // ((ITraceable)parcel).UpdateLocation(recievingOffice);
                    }
                    recievingOffice.RecievedParcels.Add(parcel);
                }
                office.OutgoingParcels.Clear();
            }
        }

        public string TrackParcel(int trackingNumber)
        {
            var traceableParcels = new List<ITraceable>();

            foreach (PostOffice office in PostOffices)
            {
                // Går igenom alla försändelser och filtrerar ut alla som använder ITraceable
                traceableParcels.AddRange(office.OutgoingParcels.Where(parcel => parcel is ITraceable)
                // Tar försändelserna som hittades i Where() och gör om dem till ITraceables
                                                                .Select(parcel => parcel as ITraceable));

                traceableParcels.AddRange(office.RecievedParcels.Where(parcel => parcel is ITraceable)
                                                               // Tar försändelserna som hittades i Where() och gör om dem till ITraceables
                                                               .Select(parcel => parcel as ITraceable));
                // alternativt:
                // traceableParcels.AddRange(office.OutgoingParcels.OfType<ITraceable>());
            }
            // foreach-sättet för samma funktionalitet
            // foreach (PostOffice office in PostOffices)
            // {
            //    foreach (Parcel parcel in office.OutgoingParcels)
            //    {
            //        if (parcel is ITraceable)
            //        {
            //            traceableParcels.Add(parcel as ITraceable);
            //        }
            //    }
            // }

            string currentLocation = traceableParcels.Find(parcel => parcel.TrackingNumber == trackingNumber)?
                                                                     .CurrentLocation.OfficeName ?? "Felaktigt Kolli-ID";

            //foreach (ITraceable traceable in traceableParcels)
            //{
            //    if (traceable.TrackingNumber == trackingNumber)
            //    {
            //        currentLocation = traceable.CurrentLocation.OfficeName;
            //        break;
            //    }
            //}

            return currentLocation;
        }
    }
}