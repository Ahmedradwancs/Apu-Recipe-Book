using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Recipe

    {
        private string name;
        private FoodCategory category;
        private string[] ingredients;
        private string description;



        public Recipe(int maxIngredients)
        {
            this.ingredients = new string[maxIngredients];
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
        public bool CheckIndex(int index)
        {
            return index >= 0 && index < ingredients.Length;
        }

        public int FindVacantPosition()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (string.IsNullOrEmpty(ingredients[i]))
                {
                    return i;
                }
            }
            return -1;
        }



        public void DeleteIngredientAt(int index)
        {
            if (CheckIndex(index))
            {
                ingredients[index] = null;
            }
        }

        public bool ChangeIngredientAt(int index, string value)
        {
            if (CheckIndex(index))
            {
                ingredients[index] = value;
                return true;
            }
            return false;
        }

        public String[] GetIngredients()
        {
            return ingredients;
        }

        public string GetIngredientAt(int index)
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
            foreach (var ingredient in ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    count++;
                }
            }
            return count;
        }

        public string GetIngredientsAsString()
        {
            /*   StringBuilder sb = new StringBuilder();
               foreach (string ingredient in ingredients)
               {
                   if (!string.IsNullOrEmpty(ingredient))
                   {
                       sb.AppendLine(ingredient);
                   }
               }
               return sb.ToString();
            */
            return string.Join(", ", ingredients.Where(ingredient => !string.IsNullOrEmpty(ingredient)));
        }

        public string Name
        {
            get { return name; }
            set
            {
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


        public override string ToString()
        {

            int namePad = 20;
            int categoryPad = 35;
            int ingredientCountPad = 36;

            string nameColumn = Name.PadRight(namePad);
            string categoryColumn = Category.ToString().PadLeft(categoryPad);
            string ingredientCountColumn = IngredientCount().ToString().PadLeft(ingredientCountPad);

            return $"{nameColumn}{categoryColumn}{ingredientCountColumn}";
        }

        public void DefaultValues()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = null;
            }
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