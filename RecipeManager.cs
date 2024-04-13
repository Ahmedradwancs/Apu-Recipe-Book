using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class RecipeManager

    {
        private Recipe[] recipes;
        private int maxRecipes;
        private int recipeCount;

        public RecipeManager(int maxRecipes, int maxIngredientsPerRecipe)
        {
            this.maxRecipes = maxRecipes;
            this.recipes = new Recipe[maxRecipes];
            this.MaxIngredientsPerRecipe = maxIngredientsPerRecipe;
        }

        public int MaxIngredientsPerRecipe { get; }

        public void AddRecipe(Recipe recipe)
        {
            if (recipeCount >= maxRecipes)
            {
                throw new InvalidOperationException("Cannot add more recipes. Maximum limit reached.");
            }
            recipes[recipeCount++] = recipe;
        }

        public void RemoveRecipe(Recipe recipe)
        {
            for (int i = 0; i < recipeCount; i++)
            {
                if (recipes[i] == recipe)
                {
                    recipes[i] = null;
                    // Shift elements to remove the gap
                    for (int j = i; j < recipeCount - 1; j++)
                    {
                        recipes[j] = recipes[j + 1];
                    }
                    recipes[recipeCount - 1] = null; // Remove the last element
                    recipeCount--;
                    return;
                }
            }
            throw new InvalidOperationException("Recipe not found.");
        }

        public Recipe GetRecipe(int index)
        {
            if (index < 0 || index >= recipeCount)
            {
                throw new IndexOutOfRangeException("Invalid recipe index.");
            }
            return recipes[index];
        }

        public int RecipeCount => recipeCount;
    }

}
