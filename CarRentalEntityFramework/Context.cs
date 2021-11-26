using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    // Context ärver en massa matnyttiga funktioner från DbContext som gör att vi kan ta bort/återskapa databasen
    // samt lägga till och plocka ut information därifrån. (EnsureCreated/EnsureDeleted/Add osv., de används i DataAccess)
    internal class Context : DbContext
    {
        // Varje DbSet representerar en Tabell i vår databas som kommer att innehålla kolumner som motsvarar properties i klasserna
        public DbSet<Car> Cars { get; set; }

        public DbSet<RentalOffice> RentalOffices { get; set; }

        public DbSet<Employee> Employees { get; set; }

        // OnConfiguring körs när vi skapar vår Context, här sätter vi connectionsträngen för vår databas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; 
Database = CarRental; 
Trusted_Connection = true;  
User Id = carrental; password = carrental");
            }
        }
    }
}
