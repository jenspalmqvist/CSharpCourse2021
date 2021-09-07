using System;
using System.Collections.Generic;
using System.Text;

namespace ReceptBok
{
    class RecipeBook
    {
        public string Title { get; set; }
        public List<Recipe> Recipes { get; set; }

        public RecipeBook()
        {
            Recipes = new List<Recipe>();
        }

        public RecipeBook(string title, List<Recipe> recipes)
        {
            Title = title;
            Recipes = recipes;
        }
    }
}