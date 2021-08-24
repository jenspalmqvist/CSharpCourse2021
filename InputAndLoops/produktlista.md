# Produktlista




## Level 1

I första nivån behöver du inte bry dig om formatet på den inmatade produkten.

Användare anger en produkt och trycker *return*. När användaren fått nog så skriver hon *exit* 



## Level 2

Fortsätt med programmet. Lägg till följande:
- Användaren ska kunna skriva *exit* på olika sätt. Stora eller små bokstäver ska inte spela någon roll. Inledande eller avslutande mellanslag ska också accepteras.

## Level 3

Nu ska du validera produktnamnet och bara acceptera ett namn som består av 

    bokstäver bindestreck siffror

Siffer-delen måste vara ett heltal mellan 200 och 500.

Exempel på giltiga produktnamn:
- CE-400
- XX-480
- LABAN-231


Exempel på ogiltiga produktnamn:
- CE400
- XX3-480
- LABAN-100

Ge olika felmeddelande beroende på vilket fel användaren gör.



BONUS: Spara alla giltiga värden och skriv ut dem när användaren har skrivit exit.
