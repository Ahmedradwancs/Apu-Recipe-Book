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

            btnAddIng.Click += new EventHandler(btnAddIng_Click);

            // Additional setup code here...
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            string recipeName = textRecipeName.Text;
            string recipeDescription = listRecipes.Text;

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

            currRecipe = new Recipe(MaxNumOfIngredients);
            currRecipe.Name = textRecipeName.Text;
            currRecipe.Description = textInstructions.Text;
            currRecipe.Category = (FoodCategory)comboCategory.SelectedItem;

            FormIngredients formIngredients = new FormIngredients(currRecipe);
            DialogResult result = formIngredients.ShowDialog();

            if (result == DialogResult.OK)
            {
                bool wasAdded = recipeManager.Add(currRecipe);

                if (wasAdded)
                {
                    // UpdateListBox(); // Uncomment or implement the UpdateListBox() method
                    MessageBox.Show("Recipe added successfully.");
                }
                else
                {
                    MessageBox.Show("Unable to add recipe. Maximum capacity reached.");
                }
            }
            else
            {
                MessageBox.Show("Adding new recipe was cancelled.");
            }
        }

        private void btnAddIng_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select a recipe first.");
                return;
            }

            if (currRecipe == null)
            {
                MessageBox.Show("Please select or create a recipe first.");
                return;
            }

            FormIngredients formIngredients = new FormIngredients(currRecipe);

            DialogResult result = formIngredients.ShowDialog();

            if (result == DialogResult.OK)
            {
                recipeManager.EditRecipe(listRecipes.SelectedIndex, currRecipe);
                UpdateListBox();
            }
        }

        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItems.Count > 0)
            {
                int selectedIndex = listRecipes.SelectedIndex;

                currRecipe = recipeManager.GetRecipeAt(selectedIndex);

                if (currRecipe != null)
                {
                    textRecipeName.Text = currRecipe.Name;
                    textInstructions.Text = currRecipe.Description;
                    comboCategory.SelectedItem = currRecipe.Category;

                    FormIngredients formIngredients = new FormIngredients(currRecipe);
                    DialogResult result = formIngredients.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Update the recipe in the recipeManager
                        if (recipeManager.EditRecipe(selectedIndex, currRecipe))
                        {
                            UpdateListBox(); // Assuming you have a method to update the list box
                        }
                        else
                        {
                            MessageBox.Show("Error in editing recipe.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
        }


        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            if (currRecipe != null)
            {
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

                // Update the recipe in the recipeManager
                int selectedIndex = listRecipes.SelectedIndices.Count > 0 ? listRecipes.SelectedIndices[0] : -1;
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
                    MessageBox.Show("Please select a recipe to edit.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to edit.");
            }
        }

        /*  private void btnEditRecipe_Click(object sender, EventArgs e)
          {
              if (listRecipes.SelectedItems.Count > 0)
              {
                  int selectedIndex = listRecipes.SelectedIndex;

                  currRecipe = recipeManager.GetRecipeAt(selectedIndex);

                  if (currRecipe != null)
                  {
                      textRecipeName.Text = currRecipe.Name;
                      comboCategory.SelectedItem = currRecipe.Category;
                      textInstructions.Text = currRecipe.Description;

                      FormIngredients formIngredients = new FormIngredients(currRecipe);
                      DialogResult result = formIngredients.ShowDialog();

                      if (result == DialogResult.OK)
                      {
                          // Update the recipe in the recipeManager
                          if (recipeManager.EditRecipe(selectedIndex, currRecipe))
                          {
                              UpdateListBox(); 
                          }
                          else
                          {
                              MessageBox.Show("Error in editing recipe.");
                          }
                      }
                  }
              }
              else
              {
                  MessageBox.Show("Please select a recipe to edit.");
              }
          }

          */

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItems.Count > 0)
            {
                int selectedIndex = listRecipes.SelectedIndex;

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
                MessageBox.Show("Please select a recipe to delete.");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            listRecipes.ClearSelected();
            currRecipe = null;
            textRecipeName.Clear();
            textInstructions.Clear();
            comboCategory.SelectedIndex = 0;
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
                    ListViewItem item = new ListViewItem(recipe.Name); // Recipe Name
                    item.SubItems.Add(recipe.Category.ToString()); // Recipe Category

                    // Ingredient Count - Using IngredientCount method from Recipe class
                    item.SubItems.Add(recipe.IngredientCount().ToString());

                    listRecipes.Items.Add(item);
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


        // Add other event handlers as needed...
    }
}