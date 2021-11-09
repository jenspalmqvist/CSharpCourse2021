Installera detta:

SQL Server 2019 Developer (Välj Basic i installationen): https://go.microsoft.com/fwlink/?linkid=866662
SQL Server Management Studio 18: https://aka.ms/ssmsfullsetup

Öppna Visual Studio Installer (Bör finnas i er startmeny om ni letar lite) och välj "Modify" på den Visual Studio ni använder, Se till att Azure Development och Data storage and processing är ikryssade och installera dem genom att trycka på "Modify"-knappen nere i hörnet

För att använda er av Chinook-databasen, gör detta:

1. Öppna Azure Data Studio (Följer med er installation av SQL Server Management)
2. Skapa en ny connection (Se bild 1 i repot)
3. Fyll i "(localdb)\mssqllocaldb" i Server-fältet (Se bild 2 i repot)
4. Öppna Chinook_SqlServer_AutoIncrementPKs.sql i azure data studio och tryck "Run" ( Se bild 3 i repot)

5. Öppna databasen, högerklicka på en tabell och välj "Select top 1000" för att få upp informationen som finns i tabellen. (Se bild 4 i repot)