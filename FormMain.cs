namespace Assignment4
{
    public partial class FormMain : Form
    {
        private RecipeManager recipeManager;

        public FormMain()
        {
            InitializeComponent();
            recipeManager = new RecipeManager(200, 50); // Set max recipes and max ingredients per recipe
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Populate combo box with food categories
            foreach (FoodCategory category in Enum.GetValues(typeof(FoodCategory)))
            {
                comboCategory.Items.Add(category);
            }
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            // Add new recipe
            string name = textRecipeName.Text;
            FoodCategory category = (FoodCategory)comboCategory.SelectedItem;
            string description = textInstructions.Text;
            Recipe newRecipe = new Recipe(name, category, recipeManager.MaxIngredientsPerRecipe);
            newRecipe.Description = description;

            // Add ingredients to the new recipe (assuming they are added elsewhere)
            // Add ingredients logic here...

            recipeManager.AddRecipe(newRecipe);
            // Update list box with registered recipes
            // UpdateListBox();
        }

        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            // Start editing selected recipe
            // Implement logic here...
        }

        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            // Finish editing selected recipe
            // Implement logic here...
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Delete selected recipe
            // Implement logic here...
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear selection
            // Implement logic here...
        }

        // Add other event handlers as needed...
    }
}