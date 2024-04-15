using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Recipe

    {
        // Private fields
        private string name;
        private FoodCategory category;
        private string[] ingredients;
        private string description;

   
        // Properties
        public string Name
        {
            get { return name; }
            set
            {
                // Validate the name (you can add more validation if needed)
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Recipe name cannot be empty.");
                }
                name = value;
            }
        }

        public FoodCategory Category
        {
            get { return category; }
            set { category = value; }
        }



        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string[] GetIngredients()
        {
            return ingredients;
        }

        public Recipe( int maxIngredients)
        {
             ingredients = new string[maxIngredients];
        }

        public bool AddIngredient(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (string.IsNullOrEmpty(ingredients[i]))
                {
                    ingredients[i] = ingredient;
                    return true;
                }
            }
            return false; 
        }


        public bool EditIngredient(string oldIngredient, string newIngredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == oldIngredient)
                {
                    ingredients[i] = newIngredient;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveIngredient(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == ingredient)
                {
                    ingredients[i] = null;
                    for (int j = i; j < ingredients.Length - 1; j++)
                    {
                        ingredients[j] = ingredients[j + 1];
                    }
                    ingredients[ingredients.Length - 1] = null;
                    return true;
                }
            }
            return false;
        }

        public string GetIngredient(int index)
        {
            if (index < 0 || index >= ingredients.Length)
            {
                throw new IndexOutOfRangeException("Invalid ingredient index.");
            }
            return ingredients[index];
        }

        public int IngredientCount()
        {
            int count = 0;
            foreach (string ingredient in ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    count++;
                }
            }
            return count;
        }

        public string GetIngredientAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string ingredient in ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    sb.AppendLine(ingredient);
                }
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return name;
        }



        public void ClearIngredients()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = null;
            }
        }
    }
}

