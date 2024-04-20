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

        private Recipe currentRecipe;


        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
            UpdateIngredientList();
        }

        public Recipe GetRecipe()
        {
            return currentRecipe;
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string ingredient = textUpdate.Text.Trim();

            if (!string.IsNullOrEmpty(ingredient))
            {
                if (currentRecipe.AddIngredient(ingredient))
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


        private void UpdateIngredientList()
        {
            listIngredients.Items.Clear();
            foreach (var ingredient in currentRecipe.GetIngredients())
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    listIngredients.Items.Add(ingredient);
                }
            }
            numOfIng.Text = currentRecipe.IngredientCount().ToString();
        }

>
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            int index = listIngredients.SelectedIndex;
            if (index != -1)
            {
                string ingredient = currentRecipe.GetIngredientAt(index);
                textUpdate.Text = ingredient;
                currentRecipe.DeleteIngredientAt(index);
                UpdateIngredientList();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to edit.");
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            int index = listIngredients.SelectedIndex;
            if (index != -1)
            {
                currentRecipe.DeleteIngredientAt(index);
                UpdateIngredientList();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }



        private void btnOk_Click_1(object sender, EventArgs e)
        {

            UpdateIngredientList();
            this.Close();

        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}