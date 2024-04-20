using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment4
{
    /// <summary>
    /// Represents a recipe with ingredients.
    /// </summary>
    public class Recipe
    {
        private string name;
        private FoodCategory category;
        private string[] ingredients;
        private string instructions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class with a maximum number of ingredients.
        /// </summary>
        /// <param name="maxIngredients">The maximum number of ingredients the recipe can have.</param>
        public Recipe(int maxIngredients)
        {
            ingredients = new string[maxIngredients];
        }

        /// <summary>
        /// Adds an ingredient to the recipe.
        /// </summary>
        /// <param name="ingredient">The ingredient to add.</param>
        /// <returns>True if the ingredient was added successfully; otherwise, false.</returns>
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

        /// <summary>
        /// Edits an existing ingredient in the recipe.
        /// </summary>
        /// <param name="oldIngredient">The old ingredient to replace.</param>
        /// <param name="newIngredient">The new ingredient to replace with.</param>
        /// <returns>True if the ingredient was edited successfully; otherwise, false.</returns>
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

        /// <summary>
        /// Removes an ingredient from the recipe.
        /// </summary>
        /// <param name="ingredient">The ingredient to remove.</param>
        /// <returns>True if the ingredient was removed successfully; otherwise, false.</returns>
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

        /// <summary>
        /// Checks if the given index is within the valid range of ingredients.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is valid; otherwise, false.</returns>
        public bool CheckIndex(int index)
        {
            return index >= 0 && index < ingredients.Length;
        }

        /// <summary>
        /// Finds the index of the first vacant position in the ingredients array.
        /// </summary>
        /// <returns>The index of the first vacant position, or -1 if no vacant position is found.</returns>
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

        /// <summary>
        /// Deletes the ingredient at the specified index.
        /// </summary>
        /// <param name="index">The index of the ingredient to delete.</param>
        public void DeleteIngredientAt(int index)
        {
            if (CheckIndex(index))
            {
                ingredients[index] = null;
            }
        }

        /// <summary>
        /// Changes the ingredient at the specified index.
        /// </summary>
        /// <param name="index">The index of the ingredient to change.</param>
        /// <param name="value">The new value of the ingredient.</param>
        /// <returns>True if the ingredient was changed successfully; otherwise, false.</returns>
        public bool ChangeIngredientAt(int index, string value)
        {
            if (CheckIndex(index))
            {
                ingredients[index] = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets all ingredients in the recipe.
        /// </summary>
        /// <returns>An array containing all ingredients.</returns>
        public string[] GetIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// Gets the ingredient at the specified index.
        /// </summary>
        /// <param name="index">The index of the ingredient to retrieve.</param>
        /// <returns>The ingredient at the specified index.</returns>
        public string GetIngredientAt(int index)
        {
            if (index < 0 || index >= ingredients.Length)
            {
                throw new IndexOutOfRangeException("Invalid ingredient index.");
            }
            return ingredients[index];
        }

        /// <summary>
        /// Gets the number of ingredients in the recipe.
        /// </summary>
        /// <returns>The number of ingredients in the recipe.</returns>
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

        /// <summary>
        /// Gets the string representation of all ingredients in the recipe.
        /// </summary>
        /// <returns>A string containing all ingredients separated by commas.</returns>
        public string GetIngredientsAsString()
        {
            return string.Join(", ", ingredients);
        }

        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the category of the recipe.
        /// </summary>
        public FoodCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        /// <summary>
        /// Gets or sets the instructions of the recipe.
        /// </summary>
        public string Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }

        /// <summary>
        /// Gets a string representation of the recipe for display purposes.
        /// </summary>
        /// <returns>A formatted string representation of the recipe.</returns>
        public override string ToString()
        {
            const int namePad = 20;
            const int categoryPad = 20;
            const int ingredientCountPad = 30;

            string nameColumn = Name.PadRight(namePad);
            string categoryColumn = Category.ToString().PadLeft(categoryPad);
            string ingredientCountColumn = IngredientCount().ToString().PadLeft(ingredientCountPad);

            return $"{nameColumn}{categoryColumn}{ingredientCountColumn}";
        }

        /// <summary>
        /// Resets all ingredients to their default values (null).
        /// </summary>
        public void DefaultValues()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = null;
            }
        }

        /// <summary>
        /// Clears all ingredients from the recipe.
        /// </summary>
        public void ClearIngredients()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = null;
            }
        }
    }
}
