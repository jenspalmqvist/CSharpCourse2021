using System;
using System.Collections.Generic;

namespace ReceptBok
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new ConsoleCompanion();
            RecipeBook book = new RecipeBook();
            book.Title = "Min receptbok";
            book.Recipes.Add(new Recipe());
            RecipeBook book2 = new RecipeBook("Min andra receptbok", new List<Recipe>());
        }
    }
}

//ReceptBok()
//	List<Recept>

//Recept()
//	List<Ingrediens>
//	Instruktioner
//	Namn
//	Bild?
//	Tid

//Ingrediens()
//	Namn
//	Mängd - double
//	Måttenhet - enum