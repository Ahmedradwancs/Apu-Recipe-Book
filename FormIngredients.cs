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
    public partial class FormIngredients : Form
    {
        private string[] ingredients;
        private int noOfIng;
        private const int MaxIngredients = 50;
        private Recipe currRecipe;

        private int selectedIngredientIndex = -1;

        private static FormIngredients formIngredientsInstance;


        // Modify the constructor to check if an instance already exists
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();

            // If an instance already exists, just bring it to the front and return
            if (formIngredientsInstance != null && !formIngredientsInstance.IsDisposed)
            {
                formIngredientsInstance.BringToFront();
                return;
            }
            this.currRecipe = recipe;
            ingredients = new string[MaxIngredients];
            LoadIngredientsFromRecipe();
            UpdateNumberOfIngredientsLabel();

            // Assign the current instance to the static variable
            formIngredientsInstance = this;
        }
        private void LoadIngredientsFromRecipe()
        {

                // Iterate through each ingredient and add it to the list box
                for (int i = 0; i < currRecipe.IngredientCount(); i++)
                {
                    string ingredient = currRecipe.GetIngredient(i);
                    if (ingredient != null)
                    {
                        ingredients[noOfIng++] = ingredient;
                        listIngredients.Items.Add(ingredient);
                    }
                }
    
            
        }




        /*
        private void btnClear_Click(object sender, EventArgs e)
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            noOfIng = 0;
            UpdateRecipe();
            UpdateNumberOfIngredientsLabel();
        }
        */





        private void UpdateNumberOfIngredientsLabel()
        {
            numOfIng.Text = noOfIng.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the selected index when an item is selected
            if (listIngredients.SelectedIndex >= 0)
            {
                selectedIngredientIndex = listIngredients.SelectedIndex;
            }
            else
            {
                selectedIngredientIndex = -1; // Reset the selected index if nothing is selected
            }

        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string newIngredient = textUpdate.Text.Trim(); // Trim whitespace
            if (!string.IsNullOrWhiteSpace(newIngredient))
            {
                if (noOfIng < MaxIngredients)
                {
                    // Ensure that ingredients array is initialized
                    if (ingredients == null)
                    {
                        ingredients = new string[MaxIngredients];
                    }

                    // Check for duplicates
                    if (!listIngredients.Items.Contains(newIngredient))
                    {
                        // Add the ingredient to the array
                        ingredients[noOfIng] = newIngredient;
                        noOfIng++; // Increment the count of ingredients
                        listIngredients.Items.Add(newIngredient);
                        textUpdate.Clear();
                        UpdateRecipe();
                        UpdateNumberOfIngredientsLabel();
                    }
                    else
                    {
                        MessageBox.Show("Ingredient already exists.");
                    }
                }
                else
                {
                    MessageBox.Show("Maximum number of ingredients reached.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a correct edit to the ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (selectedIngredientIndex >= 0)
            {
                string editedIngredient = textUpdate.Text.Trim(); // Trim whitespace
                if (!string.IsNullOrWhiteSpace(editedIngredient))
                {
                    // Check for duplicates
                    if (!listIngredients.Items.Contains(editedIngredient) || editedIngredient.Equals(listIngredients.SelectedItem.ToString()))
                    {
                        ingredients[selectedIngredientIndex] = editedIngredient;
                        listIngredients.Items[selectedIngredientIndex] = editedIngredient; // Update list item
                        textUpdate.Clear();
                        UpdateRecipe();
                        UpdateNumberOfIngredientsLabel();
                    }
                    else
                    {
                        MessageBox.Show("Ingredient already exists.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a non-empty ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an ingredient to edit.");
            }
        }





        private void btnDel_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = listIngredients.SelectedIndex;
            if (selectedIndex >= 0)
            {
                // Remove the selected ingredient from the list
                listIngredients.Items.RemoveAt(selectedIndex);
                // Shift all elements after the removed item one step to the left
                for (int i = selectedIndex; i < noOfIng - 1; i++)
                {
                    ingredients[i] = ingredients[i + 1];
                }
                noOfIng--; // Decrease the ingredient count
                ingredients[noOfIng] = null; // Clear the last element
                UpdateRecipe();
                UpdateNumberOfIngredientsLabel();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to remove.");
            }
        }


        private void btnOk_Click_1(object sender, EventArgs e)
        {
            // Update the recipe with the current ingredients
            UpdateRecipe();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateRecipe()
        {
            if (currRecipe != null)
            {
                for (int i = 0; i < noOfIng; i++)
                {
                    string ingredient = ingredients[i];
                    if (!string.IsNullOrWhiteSpace(ingredient))
                    {
                        currRecipe.AddIngredient(ingredient);
                    }
                }
            }
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // Cancel and discard changes
            DialogResult = DialogResult.Cancel;
            formIngredientsInstance = null;
            Close();
        }

        private void labelNumber_Click(object sender, EventArgs e)
        {

        }
    }
}