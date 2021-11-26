using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class RentalOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Car innehåller ett RentalOffice, vilket gör att detta blir en en-till-många relation. Denna property syns inte i tabellen.
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        // Då Employee innehåller en ICollection med RentalOffice så blir detta automatiskt en många-till-många relation
        // där en kopplingstabell skapas av Entity Framework utan att vi behöver skriva vilka nycklar som kopplas vart
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
