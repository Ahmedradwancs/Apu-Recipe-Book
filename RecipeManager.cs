using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class RecipeManager
    {
        private Recipe[] recipeList;


        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }


        public bool Add(Recipe recipe)
        {
            int index = FindVacantPosition();
            if (index == -1) return false;

            recipeList[index] = recipe;
            return true;
        }


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


        public void ChangeElement(int index, Recipe recipe)
        {
            if (CheckIndex(index))
            {
                recipeList[index] = recipe;
            }
        }


        public bool CheckIndex(int index)
        {
            return index >= 0 && index < recipeList.Length;
        }


        public void DeleteElement(int index)
        {
            if (CheckIndex(index))
            {
                recipeList[index] = null;
                MoveElementsOneStepToLeft(index);
            }
        }


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


        public int GetCurrentNumberOfRecipes()
        {
            int count = 0;
            foreach (var recipe in recipeList)
            {
                if (recipe != null) count++;
            }
            return count;
        }


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