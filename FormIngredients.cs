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

        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            this.currRecipe = recipe;
            ingredients = new string[MaxIngredients];
            LoadIngredientsFromRecipe();
            UpdateNumberOfIngredientsLabel();
        }

        private void LoadIngredientsFromRecipe()
        {
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string newIngredient = textUpdate.Text;
            if (!string.IsNullOrWhiteSpace(newIngredient))
            {
                if (noOfIng < MaxIngredients)
                {
                    ingredients[noOfIng++] = newIngredient;
                    listIngredients.Items.Add(newIngredient);
                    textUpdate.Clear();
                    UpdateRecipe();
                    UpdateNumberOfIngredientsLabel();
                }
                else
                {
                    MessageBox.Show("Maximum number of ingredients reached.");
                }
            }
            else
            {
                MessageBox.Show("Please enter an ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int selectedIndex = listIngredients.SelectedIndex;
            if (selectedIndex >= 0)
            {
                // Shift all elements after the removed item one step to the left
                for (int i = selectedIndex; i < noOfIng - 1; i++)
                {
                    ingredients[i] = ingredients[i + 1];
                }
                noOfIng--; // Decrease the ingredient count
                ingredients[noOfIng] = null; // Clear the last element

                listIngredients.Items.RemoveAt(selectedIndex);
                textUpdate.Clear();
                UpdateRecipe();
                UpdateNumberOfIngredientsLabel();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to remove.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = listIngredients.SelectedIndex;
            if (selectedIndex >= 0)
            {
                textUpdate.Text = listIngredients.SelectedItem.ToString();
                ingredients[selectedIndex] = null; // Clear the ingredient being edited
                listIngredients.Items.RemoveAt(selectedIndex);
                UpdateRecipe();
                UpdateNumberOfIngredientsLabel();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to edit.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            noOfIng = 0;
            listIngredients.Items.Clear();
            UpdateRecipe();
            UpdateNumberOfIngredientsLabel();
        }

        private void UpdateRecipe()
        {
            if (currRecipe != null)
            {
                currRecipe.ClearIngredients();
                for (int i = 0; i < noOfIng; i++)
                {
                    currRecipe.AddIngredient(ingredients[i]);
                }
            }
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Cancel and discard changes
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateNumberOfIngredientsLabel()
        {
            numOfIng.Text = noOfIng.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}