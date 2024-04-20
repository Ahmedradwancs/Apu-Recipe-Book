using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assignment4
{
    /// <summary>
    /// Represents the form for managing ingredients of a recipe.
    /// </summary>
    public partial class FormIngredients : Form
    {
        private Recipe currRecipe;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormIngredients"/> class.
        /// </summary>
        /// <param name="recipe">The recipe to manage ingredients for.</param>
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            currRecipe = recipe;
            UpdateIngredientList();
        }

        /// <summary>
        /// Gets the recipe being managed.
        /// </summary>
        /// <returns>The recipe being managed.</returns>
        public Recipe GetRecipe()
        {
            return currRecipe;
        }

        /// <summary>
        /// Handles the click event of the "Add" button.
        /// </summary>
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string ingredient = textUpdate.Text.Trim();

            if (!string.IsNullOrEmpty(ingredient))
            {
                if (currRecipe.AddIngredient(ingredient))
                {
                    UpdateIngredientList();
                    textUpdate.Clear();
                }
                else
                {
                    MessageBox.Show("Unable to add ingredient. Check if the list is full or duplicated.");
                }
            }
            else
            {
                MessageBox.Show("Please enter an ingredient.");
            }
        }

        /// <summary>
        /// Updates the list of ingredients.
        /// </summary>
        private void UpdateIngredientList()
        {
            listIngredients.Items.Clear();
            foreach (var ingredient in currRecipe.GetIngredients())
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    listIngredients.Items.Add(ingredient);
                }
            }
            numOfIng.Text = currRecipe.IngredientCount().ToString();
        }

        /// <summary>
        /// Handles the click event of the "Edit" button.
        /// </summary>
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            int index = listIngredients.SelectedIndex;
            if (index != -1)
            {
                string ingredient = currRecipe.GetIngredientAt(index);
                textUpdate.Text = ingredient;
                currRecipe.DeleteIngredientAt(index);
                UpdateIngredientList();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to edit.");
            }
        }

        /// <summary>
        /// Handles the click event of the "Delete" button.
        /// </summary>
        private void btnDel_Click_1(object sender, EventArgs e)
        {
            int index = listIngredients.SelectedIndex;
            if (index != -1)
            {
                currRecipe.DeleteIngredientAt(index);
                UpdateIngredientList();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        /// <summary>
        /// Handles the click event of the "Ok" button.
        /// </summary>
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            UpdateIngredientList();
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the "Cancel" button.
        /// </summary>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
