# SQL - Chinook database

## 1Intro

Det som står inom parantes är de kolumner som ska hämtas. T.ex i fråga 3 så ska bara ArtistName-kolumnen hämtas.

## 2)

Lista all info om alla artister


## 3)

Lista alla artisters namn. Sortera på namn. (ArtistName)



## 4)

Lista de 10 första artisterna, sorterat på namn. (ArtistId, Name)



## 5)

Lista alla artister som börjar på "Academy" (Name)



## 6)

Lista alla album där den andra bokstaven i titeln är “a” och den tredje bokstaven är “r”
(Title)



## 7)

Lista alla album där första bokstaven på titeln är en vokal



## 8)

Lista alla album tillsammans med artister för albumen (ArtistName, AlbumTitle)




## 9)

Förklara skillnaden mellan
- inner join
- left join
- right join
- full join

    


## 10)

Lista de 10 artister som släppt flest album (NrOfAlbums, ArtistName)



## 11)

Lista namn på alla album som har en eller flera track's som är Jazz eller Blues. Ett album ska bara finnas i listan en gång. (AlbumTitle)

## 12)

Albumet "Let There Be Rock" (av AC/DC) innehåller 8 låtar. Modifiera databasen så det går att ordna låtar i nummerordning. 

Uppdatera sedan databasen så låtarna i "Let There Be Rock" är numrerade från 1 till 8. (du kan lösa detta genom att på valfritt sätt, t.ex genom flera *update*-kommandon)

(kan även automatisera numreringen, men det är rätt svårt)

Alternativ lösning, som automatiserar uppdateringen 

## 13)

Skriv en sqlfråga som visar de genres som är mest populära. 

Lista genre och antal tracks i den genren. Visa den genre som har flest tracks först och sedan i nedåtstigande ordning. Visa endast de genres som har fler än 100 tracks.
(GenreName, NrOfTracks)


## 14)

Skapa en variabel som sparar CustomerId utifrån kunden "Leonie Köhler"

Använd denna variabel för att lista alla datum när en faktura till Leonie Köhler gått iväg
(InvoiceDate)


## 15)

Skapa en temporär tabell #CustomerWithSupport som innehåller förnamn och efternamn på en kund och dess supportpersonal 
(CustomerFirstName, CustomerLastName, SupportFirstName, SupportLastName)

## 16)

Lista alla anställda som har en chef och deras chef.

Resultatet ska vara två kolumner (ej 4) med den anställdes och chefens fullständiga namn

(EmployeeName, BossName)



## 17)

Ta reda på hur många tecken den längsta epostadressen har bland alla kunder
(LongestMail)



## 18)

Ta reda på den eller de låtar som pågår längst tid
Resultatet ska vara en rad med låttitel och längden på låten i minuter
(Name, Minutes)


## 19)

Gör en av kolumner i Customer unique. Motivera ditt val 

## 20)

Lista hur mycket som har fakturerat för varje år (2009-2013). Sortera så senaste åren visas först (2013)
(Year, Sum)



## 21)

(Svår!)

Lista alla artister och hur många spellistor de är med i.

## 22)

Beräkna vilken mediatyp som bidragit mest till den ekonomiska omsättningen 

## 23)

Lista alla låtar Dan Miller köpt 

## 24)

Ta ut de tio artister med lägst id och sortera dem baklänges efter namn. Resultatet ska alltså bli:

	Billy Cobham
	BackBeat
	Audioslave
	Apocalyptica
	Antônio Carlos Jobim
	Alice In Chains
	Alanis Morissette
	Aerosmith
	Accept
	AC/DC

Ta hänsyn till att dessa artisters id nödvändigtvis inte måste vara mellan 1 till 10

## 25)

Ta fram den längsta spellistan. (Name, TotalLengthInHours)

## 26)

Lista alla anställda som har en chef och deras chefs chef. (EmployeeName, BossesBossName)


## 27)

Lista hur många kunder och anställda det finns i varje land (Country, NumberOfCustomers, NumberOfEmployees)

Resultatet bör se ut som nedan:
	Country     NumberOfCustomers   NumberOfEmployees
	Argentina   1                   0
	Australia   1                   0
	Austria     1                   0
	Belgium     1                   0
	Brazil      5                   0
	Canada      8                   8
	....etc



## 27)

Visa vilka fem kompositörer som har genererat mest vinst, och hur många låtar de sålt (Kompositör, antal sålda låtar, total försäljning)

Förväntat resultat:

	Steve Harris									58	57.42
	U2												33	32.67
	Billy Corgan									23	22.77
	Bill Berry-Peter Buck-Mike Mills-Michael Stipe	22	21.78
	Titãs											22	21.78

