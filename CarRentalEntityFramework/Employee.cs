using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Då RentalOffice innehåller en ICollection med Employee så blir detta automatiskt en många-till-många relation
        // där en kopplingstabell skapas av Entity Framework utan att vi behöver skriva vilka nycklar som kopplas vart
        public ICollection<RentalOffice> RentalOffices { get; set; } = new List<RentalOffice>();
    }
}
