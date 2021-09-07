using System;
using System.Collections.Generic;
using System.Text;

namespace ReceptBok
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public Measure Measure { get; set; }
    }
}

//Ingrediens()
//	Namn
//	Mängd - double
//	Måttenhet - enum