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
        private Recipe currRecipe;

        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            currRecipe = recipe;
            numberOutput.Text = currRecipe.Ingredients.Length.ToString();
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            textIngredients.Clear();
            foreach (string ingredient in currRecipe.Ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    textIngredients.AppendText(ingredient + Environment.NewLine);
                }
            }
        }

        private void BtnIngAdd_Click(object sender, EventArgs e)
        {
            // Add ingredient to the current recipe
            string newIngredient = textUpdate.Text;
            if (!string.IsNullOrWhiteSpace(newIngredient))
            {
                try
                {
                    currRecipe.AddIngredient(newIngredient);
                    DisplayIngredients();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter an ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngEdit_Click(object sender, EventArgs e)
        {
            // Edit selected ingredient
            // Implement logic here...
        }

        private void BtnIngDel_Click(object sender, EventArgs e)
        {
            // Delete selected ingredient
            // Implement logic here...
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Confirm and save changes
            // Implement logic here...
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Cancel and discard changes
            // Implement logic here...
        }

    }
}
