using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class RecipeManager

    {
        private Recipe[] recipeList;
        private int numOfRecipes;

        public RecipeManager(int maxNumOfRecipes)
        {
            recipeList = new Recipe[maxNumOfRecipes];
            numOfRecipes = 0;
        }

        public bool Add(Recipe recipe)
        {
            if (numOfRecipes < recipeList.Length)
            {
                recipeList[numOfRecipes] = recipe;
                numOfRecipes++;
                return true;
            }
            return false;
        }   

        public bool RemoveRecipeAt(int index)
        {
            if (index >= 0 && index < numOfRecipes)
            {
                recipeList[index] = null;
                MoveElementLeft(index);
                numOfRecipes--;
                return true;
            }
            return false;
        }

        public bool EditRecipe(int index, Recipe recipe)
        {
            if (index >= 0 && index < numOfRecipes)
            {
                recipeList[index] = recipe;
                return true;
            }
            return false;
        }

        public Recipe GetRecipeAt(int index)
        {
            if (index >= 0 && index < numOfRecipes)
            {
                return recipeList[index];
            }
            return null;
        }

        public int NumOfRecipes()
        {
            return numOfRecipes;
        }

        public void UpdateRecipe(Recipe recipe)
        {
            for (int i = 0; i < numOfRecipes; i++)
            {
                if (recipeList[i] != null && recipeList[i].Name.Equals(recipe.Name, StringComparison.OrdinalIgnoreCase))
                    recipeList[i].ClearIngredients();
                foreach (string ingredient in recipe.GetIngredients())
                {
                    if (!string.IsNullOrEmpty(ingredient))
                    {
                        recipeList[i].AddIngredient(ingredient);
                    }
                }
                break;
            }
        }

        private void MoveElementLeft(int index)
        {
            for (int i = index; i < numOfRecipes - 1; i++)
            {
                recipeList[i] = recipeList[i + 1];
            }
            recipeList[numOfRecipes - 1] = null;
        }



    }
}