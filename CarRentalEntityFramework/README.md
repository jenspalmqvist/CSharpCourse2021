# Markdown File

1. Installera nuget-paket genom att klista in följande i Package Manager Console: 
	Install-Package Microsoft.EntityFrameworkCore -Version 5.0.12
	Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.12
	Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.12
2. Skapa Context.cs med en override OnConfiguring där ni sätter connectionsträngen till databasen 
3. Skapa klasserna Car/RentalOffice/Employee med tillhörande properties
4. Lägg till DbSet för klasserna ovan i Context
5. Skapa DataAccess.cs och lägg till metoder för att återställa databasen samt skriva/läsa data
6. Migrera om ni vill, det är inte livsviktigt i det här sammanhanget, men migreringar är det som används i produktion.
