using System;
using System.Windows.Forms;

namespace Assignment4
{
    /// <summary>
    /// Represents the main form of the recipe management application.
    /// </summary>
    public partial class FormMain : Form
    {
        private const int MaxNumOfElements = 150;
        private const int MaxNumOfIngredients = 25;

        private RecipeManager recipeManager = new RecipeManager(MaxNumOfElements);
        private Recipe currRecipe = new Recipe(MaxNumOfIngredients);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            foreach (var category in Enum.GetValues(typeof(FoodCategory)))
            {
                comboCategory.Items.Add(category);
            }

            comboCategory.SelectedIndex = 0;
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            listRecipes.MouseDoubleClick += new MouseEventHandler(listRecipes_MouseDoubleClick);
        }

        /// <summary>
        /// Handles the click event of the "Add Recipe" button.
        /// </summary>
        private void btnAddRec_Click(object sender, EventArgs e)
        {
            if (currRecipe.IngredientCount() == 0)
            {
                MessageBox.Show("Please add ingredients to the recipe.");
                return;
            }

            currRecipe.Name = textRecipeName.Text;
            currRecipe.Category = (FoodCategory)comboCategory.SelectedItem;

            // Check if instructions are added
            if (string.IsNullOrEmpty(textInstructions.Text))
            {
                MessageBox.Show("Please add instructions to the recipe.");
                return;
            }

            currRecipe.Instructions = textInstructions.Text;

            bool addedSuccessfully = recipeManager.Add(currRecipe);

            if (addedSuccessfully)
            {
                UpdateGUI();
                currRecipe = new Recipe(MaxNumOfIngredients);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add recipe. The recipe book is full or an error occurred.");
            }
        }


        /// <summary>
        /// Handles the click event of the "Add Ingredients" button.
        /// </summary>
        private void btnAddIng_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textRecipeName.Text) || comboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a name and select a category for the recipe.");
                return;
            }

            FormIngredients formIngredients = new FormIngredients(currRecipe);
            formIngredients.Text = textRecipeName.Text + " + add ingredients";
            formIngredients.ShowDialog();
            UpdateGUI();
        }

        /// <summary>
        /// Handles the click event of the "Begin Edit" button.
        /// </summary>
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;
                currRecipe = recipeManager.GetRecipeAt(index);

                textRecipeName.Text = currRecipe.Name;
                comboCategory.SelectedItem = currRecipe.Category;
                textInstructions.Text = currRecipe.Instructions;
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
        }

        /// <summary>
        /// Handles the click event of the "Finish Edit" button.
        /// </summary>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;

                currRecipe.Name = textRecipeName.Text;
                currRecipe.Category = (FoodCategory)comboCategory.SelectedItem;
                currRecipe.Instructions = textInstructions.Text;

                recipeManager.ChangeElement(index, currRecipe);

                UpdateGUI();
                ClearForm();
            }

        }

        /// <summary>
        /// Handles the click event of the "Delete" button.
        /// </summary>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;
                recipeManager.DeleteElement(index);
                UpdateGUI();
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        /// <summary>
        /// Handles the click event of the "Clear" button.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Updates the GUI with the recipes.
        /// </summary>
        private void UpdateGUI()
        {
            listRecipes.Items.Clear();

            foreach (string recipeSummary in recipeManager.RecipeListToString())
            {
                listRecipes.Items.Add(recipeSummary);
            }
        }

        /// <summary>
        /// Handles the double-click event of the recipe list.
        /// </summary>
        private void listRecipes_MouseDoubleClick(object sender, EventArgs e)
        {
            ViewSelectedRecipeDetails();
        }

        /// <summary>
        /// Displays the details of the selected recipe.
        /// </summary>
        private void ViewSelectedRecipeDetails()
        {
            int selectedIndex = listRecipes.SelectedIndex;
            if (selectedIndex != -1)
            {
                Recipe selectedRecipe = recipeManager.GetRecipeAt(selectedIndex);

                string ingredients = selectedRecipe.GetIngredientsAsString();
                string instructions = selectedRecipe.Instructions;

                MessageBox.Show($"INGREDIENTS:\n {ingredients}\n\n {instructions}", "Cooking Instructions:", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please select a recipe to view its details.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Clears the form fields.
        /// </summary>
        private void ClearForm()
        {
            textRecipeName.Clear();
            textInstructions.Clear();
            comboCategory.SelectedIndex = -1;
            listRecipes.ClearSelected();
        }


    }
}
