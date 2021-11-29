using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class Car
    {
        public int Id { get; set; }
        //Detta är 'Attributes' som gör så att vi kan vara lite mer specifika kring vad våra kolumner får innehålla
        [StringLength(50)]
        [DisallowNull]
        public string Model { get; set; }
        public int Mileage { get; set; }
        // Detta görs om till en Foreign Key av Entity Framework, på grund av att RentalOffice
        // innehåller en ICollection med Cars. Det blir alltså automatiskt en en-till-många relation.
        public RentalOffice CurrentOffice { get; set; }

        public override string ToString()
        {
            return $"Model: {Model} Mileage: {Mileage} Current office: {CurrentOffice.Name}";
        }
    }
}
