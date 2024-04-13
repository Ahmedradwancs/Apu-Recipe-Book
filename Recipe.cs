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

    // Constructor
    public Recipe(string name, FoodCategory category, int maxIngredients)
    {
        this.Name = name;
        this.Category = category;
        this.ingredients = new string[maxIngredients];
    }

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

    public string[] Ingredients
    {
        get { return ingredients; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    // Method to add an ingredient
    public void AddIngredient(string ingredient)
    {
        // Check if there's space to add the ingredient
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (string.IsNullOrEmpty(ingredients[i]))
            {
                ingredients[i] = ingredient;
                return;
            }
        }
        throw new InvalidOperationException("Cannot add more ingredients. Maximum limit reached.");
    }

    // Method to remove an ingredient
    public void RemoveIngredient(string ingredient)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == ingredient)
            {
                ingredients[i] = null;
                return;
            }
        }
        throw new InvalidOperationException("Ingredient not found.");
    }
}
  
    
}

