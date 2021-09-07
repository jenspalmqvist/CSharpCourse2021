using ReceptBok;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceptBok
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public int CookingTime { get; set; }
        public List<string> Instructions { get; set; }
    }
}

//Recept()
//	List<Ingrediens>
//	Instruktioner
//	Namn
//	Bild?
//	Tid