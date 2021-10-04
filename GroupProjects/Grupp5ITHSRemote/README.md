# Grupparbete1
  
## ASCII-baserat Dungeon-spel i konsolfönster.
  
* Spelare som flyttar runt i en Dungeon för att hitta skatten.
* Spelaren ska undvika eller besegra monster.
* Spelaren har olika föremål, som vapen och health potions.
  
När användaren trycker på WASD så flyttas karaktären runt på kartan.
  
* Interfacet visar vad som kommer ske för action när användaren trycker på respektive WASD.
Ex.  
W - Up, Move  
A - Left, blocked by wall  
S - Down, Attack monster  
D - Right, Pick Up Health Potion  
Ska det vara möjligt att utföra flera olika actions mot en och samma ruta, ex. en ruta som innehåller ett monster?  
  
### Main loop
Uppdatera spelarens status (Flytta runt, healing, attack, etc.)  
Uppdatera status för alla monster (Flytta runt, healing, attack, etc.)  
Uppdatera status för eventuellt andra saker  
Rita ut ny karta  
Visa status/alternativ  
Ta in input  
*Något mer, vilken ordning?*  
  
### IRepresentable - Interface för objekt som ska kunna representeras på kartan  
Alla objekt som ska ritas ut på kartan behöver ha ett tecken som representerar objektet,
och även en position.  
För att göra det enhetligt hur detta representeras läggs den funktionaliteten i ett interface.  
  
### Character - Generisk basklass för alla karaktärer (spelare, fiender, djur, etc.)
* Health  
* Name
* IRepresentation
* CoinPurse  
Funktion för Move(Direction), kallar på funktion hos Kartan att uppdatera position av karaktärsobjekt till specifik ruta. Kan overload:as hos underklasser för att implementera mer logik.  
Kan aktivera funktioner hos objekt i inventory för att utföra andra handlingar än att gå.  
  
### Player : Character  
Klass som ärver från Character, kontrollerbar av användaren.

### NonPlayerCharacter : Caracter
Klass som ärver från Character, kontrolleras ej av spelaren.  
Representerar monster i spelet, innehåller några mallar för defaultmonster i konstruktorn.  
  
### Equipment-objekt : IRepresentable
Property för hur mycket skada eller healing som det kan göra.  
Innehåller ett Verb-property som säger vad det kallas att använda objektet. Exempelvis "Attack" eller "Swing" för svärd, "Drink" för Potions, etc.  
  
### Map-objekt
Innehåller två 2D-arrayer för hela spelvärlden, där varje element visar vad rutan innehåller.  
*public MapTile[,] staticMap; // Walls, floors.*  
*public IRepresentable[,] dynamicMap; // Stuff that move or change, player, monsters, items, etc.*  
Stödmetoder för att göra kartskapande enklare:  
DrawRect(x,y, width, height, borderObject, fillObject) - Placerar ut en rektangel på kartan med väggar av *borderObject* och fylld med *fillObject*.  
DefaultMap() för att skapa en standardkarta.  
  
### MapTile : IRepresentable  
Representerar statiska objekt i spelvärlden som inte flyttar på sig.  
Utöver IRepresentable så har den property *Walkable* som visar var karaktärer kan gå.  

### Victory/lose condition 
* Game Over-skärm
* Victory-skärm
  
### Referensmaterial
Liknande spel: https://en.wikipedia.org/wiki/Rogue_(video_game)
  
## Screenshots/Resultat  
  
![Screenshot of start screen](https://raw.githubusercontent.com/mikosken/Grupparbete1/main/Screen1.png)  
  
![Screenshot of game](https://raw.githubusercontent.com/mikosken/Grupparbete1/main/Screen2.png)  
  
![Screenshot of victory screen](https://raw.githubusercontent.com/mikosken/Grupparbete1/main/Screen3.png)  
  
### Classes  
  
![Class diagram](https://raw.githubusercontent.com/mikosken/Grupparbete1/main/ClassDiagram1.png)  
