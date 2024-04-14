namespace Assignment4
{
    public partial class FormMain : Form
    {
        private RecipeManager recipeManager;
        private Recipe currRecipe;
        const int MaxNumOfIngredients = 50;
        const int MaxNumOfRecipes = 200;

        public FormMain()
        {
            InitializeComponent();

            foreach (var category in Enum.GetValues(typeof(FoodCategory)))
            {
                comboCategory.Items.Add(category);
            }

            comboCategory.SelectedIndex = 0;
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList; // Making ComboBox read-only

            recipeManager = new RecipeManager(MaxNumOfRecipes);

            UpdateGUI();

            //btnAddIng.Click += new EventHandler(btnAddIng_Click);

        }

        private void UpdateGUI()
        {
            // Clear the list box
            listRecipes.Items.Clear();

            //clear input fields
            textRecipeName.Clear();
            textInstructions.Clear();
            comboCategory.SelectedIndex = 0;
            /*
            // This code adds a default item to the list box, you might not need it
            string defaultItem = "Name".PadRight(30) + "Category".PadRight(25) + "Number of Ingredients";
            listRecipes.Items.Add(defaultItem);
            */
            // Loop through the recipes and add them to the list box
            int numOfRecipes = recipeManager.NumOfRecipes();
            for (int i = 0; i < numOfRecipes; i++)
            {
                Recipe recipe = recipeManager.GetRecipeAt(i);
                if (recipe != null)
                {
                    // Format the recipe information as a string
                    string recipeInfo = recipe.Name.PadRight(35) + recipe.Category.ToString().PadRight(25) + recipe.IngredientCount().ToString();

                    // Add the formatted string to the list box
                    listRecipes.Items.Add(recipeInfo);
                }
            }
        }




        private void btnAddRec_Click(object sender, EventArgs e)
        {
            string recipeName = textRecipeName.Text;
            string recipeDescription = textInstructions.Text;

            // Check if name and description are provided
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(recipeDescription))
            {
                MessageBox.Show("Description cannot be empty.");
                return;
            }

            // Check if ingredients are provided
            if (currRecipe == null || currRecipe.IngredientCount() == 0)
            {
                MessageBox.Show("Please add ingredients to the recipe.");
                return;
            }

            // Create a new recipe instance
            currRecipe = new Recipe(MaxNumOfIngredients);
            currRecipe.Name = recipeName;
            currRecipe.Description = recipeDescription;
            currRecipe.Category = (FoodCategory)comboCategory.SelectedItem;

            // Attempt to add the recipe to the recipe manager
            bool wasAdded = recipeManager.Add(currRecipe);

            // Check if the recipe was added successfully
            if (wasAdded)
            {
                Console.WriteLine("Recipe added successfully.");
                MessageBox.Show("Recipe added successfully.");

                UpdateListBox();
            }
            else
            {
                Console.WriteLine("Unable to add recipe. Maximum capacity reached.");
                MessageBox.Show("Unable to add recipe. Maximum capacity reached.");
            }
            UpdateGUI();
        }



        private void btnAddIng_Click(object sender, EventArgs e)
        {
            // Check if there is a selected recipe in the list box
            if (listRecipes.SelectedIndices.Count == 0 && string.IsNullOrWhiteSpace(textRecipeName.Text))
            {
                MessageBox.Show("Please select a recipe or create a new one first.");
                return;
            }

            // If a recipe is selected from the list
            if (listRecipes.SelectedIndices.Count > 0)
            {
                // Get the index of the selected recipe
                int selectedIndex = listRecipes.SelectedIndex;

                // Get the selected recipe
                currRecipe = recipeManager.GetRecipeAt(selectedIndex);
            }
            // If a new recipe is being created
            else if (!string.IsNullOrWhiteSpace(textRecipeName.Text))
            {
                // Create a new recipe instance
                currRecipe = new Recipe(MaxNumOfIngredients);

                // Set the name of the new recipe
                currRecipe.Name = textRecipeName.Text;

                // Optionally, you can set other properties of the new recipe here
            }

            // Create a new instance of FormIngredients with the current recipe
            FormIngredients formIngredients = new FormIngredients(currRecipe);

            // Show the FormIngredients form
            DialogResult result = formIngredients.ShowDialog();

            // Handle the result if needed
            if (result == DialogResult.OK)
            {
                // Optionally, you can update the list box here
                UpdateListBox();
            }
        }





        private void UpdateListBox()
        {
            listRecipes.Items.Clear();
            int numOfRecipes = recipeManager.NumOfRecipes();

            for (int i = 0; i < numOfRecipes; i++)
            {
                Recipe recipe = recipeManager.GetRecipeAt(i);
                if (recipe != null)
                {
                    // Format the recipe information as a string
                    string[] recipeInfo = { recipe.Name, recipe.Category.ToString(), recipe.IngredientCount().ToString() };

                    // Add the recipe information to the list box
                    listRecipes.Items.Add(new ListViewItem(recipeInfo));
                }
            }

        }




        private void listRecipes_DoubleClick(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItems.Count > 0)
            {
                Recipe selectedRecipe = (Recipe)listRecipes.SelectedItems[0];

                // Construct the details string
                string ingredients = string.Join(", ", selectedRecipe.GetIngredients());
                string details = $"Name: {selectedRecipe.Name}\n" +
                                 $"Category: {selectedRecipe.Category}\n" +
                                 $"Ingredients: {ingredients}\n" +
                                 $"Description: {selectedRecipe.Description}\n";

                // Show the details in a message box
                MessageBox.Show(details, "Cooking Instructions", MessageBoxButtons.OK);
            }
        }

        private void listRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnEditBegin_Click_1(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItems.Count > 0)
            {
                // Get the index of the selected recipe in the list view
                int selectedIndex = listRecipes.SelectedIndex;

                // Ensure the selected index is valid
                if (selectedIndex >= 0 && selectedIndex < recipeManager.NumOfRecipes())
                {
                    // Get the selected recipe using its index
                    Recipe selectedRecipe = recipeManager.GetRecipeAt(selectedIndex);

                    // Enable editing of name, instructions, and category
                    textRecipeName.Enabled = true;
                    textInstructions.Enabled = true;
                    comboCategory.Enabled = true;

                    // Set the current recipe to the selected recipe
                    currRecipe = selectedRecipe;

                    // Populate the text fields with the selected recipe's information
                    textRecipeName.Text = currRecipe.Name;
                    textInstructions.Text = currRecipe.Description;
                    comboCategory.SelectedItem = currRecipe.Category;
                }
                else
                {
                    MessageBox.Show("Invalid selection.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
        }

        private void btnEditFinish_Click_1(object sender, EventArgs e)
        {
            if (currRecipe != null)
            {
                // Disable editing of name, instructions, and category
                textRecipeName.Enabled = false;
                textInstructions.Enabled = false;
                comboCategory.Enabled = false;

                string editedName = textRecipeName.Text;
                string editedDescription = textInstructions.Text;
                FoodCategory editedCategory = (FoodCategory)comboCategory.SelectedItem;

                if (string.IsNullOrWhiteSpace(editedName) || string.IsNullOrWhiteSpace(editedDescription))
                {
                    MessageBox.Show("Name and Description cannot be empty.");
                    return;
                }

                currRecipe.Name = editedName;
                currRecipe.Description = editedDescription;
                currRecipe.Category = editedCategory;

                // Find the index of the current recipe in the recipe list
                int selectedIndex = -1;
                for (int i = 0; i < recipeManager.NumOfRecipes(); i++)
                {
                    if (recipeManager.GetRecipeAt(i) == currRecipe)
                    {
                        selectedIndex = i;
                        break;
                    }
                }

                if (selectedIndex != -1)
                {
                    if (recipeManager.EditRecipe(selectedIndex, currRecipe))
                    {
                        UpdateListBox();
                        MessageBox.Show("Recipe updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error in updating the recipe.");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Recipe not found in the list.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
            UpdateGUI();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItems.Count > 0)
            {
                // Get the index of the selected recipe in the list view
                int selectedIndex = listRecipes.SelectedIndex;

                // Ensure the selected index is valid
                if (selectedIndex >= 0 && selectedIndex < recipeManager.NumOfRecipes())
                {
                    if (recipeManager.RemoveRecipeAt(selectedIndex))
                    {
                        UpdateListBox();
                        MessageBox.Show("Recipe deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error in deleting recipe.");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Recipe not found in the list.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
            UpdateGUI();
        }



        private void btnClear_Click_1(object sender, EventArgs e)
        {
            listRecipes.ClearSelected();
            //currRecipe = null;
            textRecipeName.Clear();
            textInstructions.Clear();
            comboCategory.SelectedIndex = 0;
            UpdateGUI();
        }



        // Add other event handlers as needed...
    }
}