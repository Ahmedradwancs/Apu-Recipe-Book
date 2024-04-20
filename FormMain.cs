namespace Assignment4
{
    public partial class FormMain : Form
    {
        const int MaxNumOfElements = 200;
        const int MaxNumOfIngredients = 50;

        private RecipeManager recipeManager = new RecipeManager(MaxNumOfElements);
        private Recipe currentRecipe = new Recipe(MaxNumOfIngredients);



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

      
        private void btnAddRec_Click(object sender, EventArgs e)
        {
            if (currentRecipe.IngredientCount() == 0)
            {
                MessageBox.Show("Please add ingredients to the recipe.");
                return;
            }

            currentRecipe.Name = textRecipeName.Text;
            currentRecipe.Category = (FoodCategory)comboCategory.SelectedItem;
            currentRecipe.Description = textInstructions.Text;


            bool addedSuccessfully = recipeManager.Add(currentRecipe);

            if (addedSuccessfully)
            {
                UpdateGUI();
                currentRecipe = new Recipe(MaxNumOfIngredients);

            }
            else
            {
                MessageBox.Show("Failed to add recipe. The recipe book may be full.");
            }
        }

        private void btnAddIng_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textRecipeName.Text) || comboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a name and select a category for the recipe.");
                return;
            }

            FormIngredients formIngredients = new FormIngredients(currentRecipe);

            formIngredients.Text = textRecipeName.Text + " + add ingredients";

            formIngredients.ShowDialog();

            UpdateGUI();


        }


        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;
                currentRecipe = recipeManager.GetRecipeAt(index);

                textRecipeName.Text = currentRecipe.Name;
                comboCategory.SelectedItem = currentRecipe.Category;
                textInstructions.Text = currentRecipe.Description;
            }
        }

 
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;

                currentRecipe.Name = textRecipeName.Text;
                currentRecipe.Category = (FoodCategory)comboCategory.SelectedItem;
                currentRecipe.Description = textInstructions.Text;

                recipeManager.ChangeElement(index, currentRecipe);

                UpdateGUI();
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listRecipes.SelectedItem != null)
            {
                int index = listRecipes.SelectedIndex;
                recipeManager.DeleteElement(index);
                UpdateGUI();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



        private void UpdateGUI()
        {
            listRecipes.Items.Clear();
           
            foreach (string recipeSummary in recipeManager.RecipeListToString())
            {
                listRecipes.Items.Add(recipeSummary);
            }
        }


        private void listRecipes_MouseDoubleClick(object sender, EventArgs e)
        {
            ViewSelectedRecipeDetails();

        }


        private void ViewSelectedRecipeDetails()
        {
            int selectedIndex = listRecipes.SelectedIndex;
            if (selectedIndex != -1)
            {
                Recipe selectedRecipe = recipeManager.GetRecipeAt(selectedIndex);

                string ingredients = selectedRecipe.GetIngredientsAsString();
                string description = selectedRecipe.Description;


                MessageBox.Show($"INGREDIENTS:\n {ingredients}\n\n {description}", "Cooking Instructions", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please select a recipe to view its details.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ClearForm()
        {
            textRecipeName.Clear();
            textInstructions.Clear();
            comboCategory.SelectedIndex = -1;
            listRecipes.ClearSelected();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }
    }
}