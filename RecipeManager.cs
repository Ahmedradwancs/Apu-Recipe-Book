using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment4
{
    /// <summary>
    /// Manages a collection of recipes.
    /// </summary>
    public class RecipeManager
    {
        private Recipe[] recipeList;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeManager"/> class with a maximum number of elements.
        /// </summary>
        /// <param name="maxNumOfElements">The maximum number of elements the recipe manager can hold.</param>
        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }

        /// <summary>
        /// Adds a recipe to the recipe manager.
        /// </summary>
        /// <param name="recipe">The recipe to add.</param>
        /// <returns>True if the recipe was added successfully; otherwise, false.</returns>
        public bool Add(Recipe recipe)
        {
            int index = FindVacantPosition();
            if (index == -1) return false;

            recipeList[index] = recipe;
            return true;
        }

        /// <summary>
        /// Adds a recipe to the recipe manager with specified name, category, and ingredients.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="category">The category of the recipe.</param>
        /// <param name="ingredients">The ingredients of the recipe.</param>
        /// <returns>True if the recipe was added successfully; otherwise, false.</returns>
        public bool Add(string name, FoodCategory category, string[] ingredients)
        {
            int index = FindVacantPosition();
            if (index == -1) return false;

            Recipe recipe = new Recipe(GetCurrentNumberOfRecipes());
            recipe.Name = name;
            recipe.Category = category;

            foreach (string ingredient in ingredients)
            {
                if (!recipe.AddIngredient(ingredient))
                {
                    break;
                }
            }

            recipeList[index] = recipe;
            return true;
        }

        /// <summary>
        /// Changes the recipe at the specified index.
        /// </summary>
        /// <param name="index">The index of the recipe to change.</param>
        /// <param name="recipe">The new recipe.</param>
        public void ChangeElement(int index, Recipe recipe)
        {
            if (CheckIndex(index))
            {
                recipeList[index] = recipe;
            }
        }

        /// <summary>
        /// Checks if the given index is within the valid range of recipes.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is valid; otherwise, false.</returns>
        public bool CheckIndex(int index)
        {
            return index >= 0 && index < recipeList.Length;
        }

        /// <summary>
        /// Deletes the recipe at the specified index.
        /// </summary>
        /// <param name="index">The index of the recipe to delete.</param>
        public void DeleteElement(int index)
        {
            if (CheckIndex(index))
            {
                recipeList[index] = null;
                MoveElementsOneStepToLeft(index);
            }
        }

        /// <summary>
        /// Finds the index of the first vacant position in the recipe list.
        /// </summary>
        /// <returns>The index of the first vacant position, or -1 if no vacant position is found.</returns>
        public int FindVacantPosition()
        {
            for (int i = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the current number of recipes in the recipe manager.
        /// </summary>
        /// <returns>The current number of recipes.</returns>
        public int GetCurrentNumberOfRecipes()
        {
            int count = 0;
            foreach (var recipe in recipeList)
            {
                if (recipe != null) count++;
            }
            return count;
        }

        /// <summary>
        /// Gets the recipe at the specified index.
        /// </summary>
        /// <param name="index">The index of the recipe to retrieve.</param>
        /// <returns>The recipe at the specified index.</returns>
        public Recipe GetRecipeAt(int index)
        {
            if (CheckIndex(index))
            {
                return recipeList[index];
            }
            return null;
        }

        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index; i < recipeList.Length - 1; i++)
            {
                recipeList[i] = recipeList[i + 1];
            }
            if (recipeList.Length > 0)
            {
                recipeList[recipeList.Length - 1] = null;
            }
        }

        /// <summary>
        /// Converts the list of recipes to an array of strings.
        /// </summary>
        /// <returns>An array of strings representing the recipes.</returns>
        public string[] RecipeListToString()
        {
            string[] recipeStrings = new string[GetCurrentNumberOfRecipes()];
            int counter = 0;
            foreach (var recipe in recipeList)
            {
                if (recipe != null)
                {
                    recipeStrings[counter++] = recipe.ToString();
                }
            }
            return recipeStrings;
        }
    }
}
