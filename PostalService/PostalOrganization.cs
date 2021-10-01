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
                Console.WriteLine($"{i + 1}. {PostOffices[i].OfficeName}");
            }
            int selection = InputHelper.GetInt("Välj ett av alternativen ovan: ", min: 1, max: PostOffices.Count);
            return PostOffices[selection - 1]; // -1 är för att välja rätt index i listan trots att vår numrerade lista här ovan börjar på 1;
        }

        public void SendParcels()
        {
            foreach (PostOffice office in PostOffices)
            {
                foreach (Parcel parcel in office.OutgoingParcels)
                {
                    var recievingOffice = PostOffices.Find(office => parcel.RecipientAddress.ZipCode > office.HandlesZipCodesFrom
                                            && parcel.RecipientAddress.ZipCode < office.HandlesZipCodesUpTo);
                    recievingOffice.RecievedParcels.Add(parcel);
                }
                office.OutgoingParcels.Clear();
            }
        }
    }
}