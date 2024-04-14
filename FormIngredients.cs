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
        private List<string> ingredients = new List<string>();
        private Recipe currRecipe;

        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            this.currRecipe = recipe;
            DisplayIngredients();
        }

        public List<string> Ingredients
        {
            get { return ingredients; }
        }
        private void DisplayIngredients()
        {
            textIngredients.Clear();
            foreach (string ingredient in ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    textIngredients.AppendText(ingredient + Environment.NewLine);
                }
            }
        }

        private void BtnIngAdd_Click(object sender, EventArgs e)
        {
            string newIngredient = textUpdate.Text;
            if (!string.IsNullOrWhiteSpace(newIngredient))
            {
                ingredients.Add(newIngredient);
                DisplayIngredients();
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
            //currRecipe.SetIngredients(Ingredients.ToArray());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Cancel and discard changes
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

