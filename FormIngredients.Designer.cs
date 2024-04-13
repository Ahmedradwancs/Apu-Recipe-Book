
namespace Assignment4
{
    partial class FormIngredients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelNumber = new Label();
            numberOutput = new Label();
            groupBox1 = new GroupBox();
            textIngredients = new TextBox();
            textUpdate = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(24, 24);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(159, 20);
            labelNumber.TabIndex = 0;
            labelNumber.Text = "Number of ingredients";
            // 
            // numberOutput
            // 
            numberOutput.AutoSize = true;
            numberOutput.Location = new Point(500, 24);
            numberOutput.Name = "numberOutput";
            numberOutput.Size = new Size(60, 20);
            numberOutput.TabIndex = 1;
            numberOutput.Text = "number";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textIngredients);
            groupBox1.Controls.Add(textUpdate);
            groupBox1.Location = new Point(32, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(521, 392);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingredient";
            // 
            // textIngredients
            // 
            textIngredients.Location = new Point(21, 100);
            textIngredients.Multiline = true;
            textIngredients.Name = "textIngredients";
            textIngredients.Size = new Size(403, 281);
            textIngredients.TabIndex = 1;
            // 
            // textUpdate
            // 
            textUpdate.Location = new Point(21, 39);
            textUpdate.Multiline = true;
            textUpdate.Name = "textUpdate";
            textUpdate.Size = new Size(403, 38);
            textUpdate.TabIndex = 0;
            // 
            // FormIngredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 506);
            Controls.Add(groupBox1);
            Controls.Add(numberOutput);
            Controls.Add(labelNumber);
            Name = "FormIngredients";
            Text = "Add ingredients";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNumber;
        private Label numberOutput;
        private GroupBox groupBox1;
        private TextBox textIngredients;
        private TextBox textUpdate;
        private EventHandler FormIngredients_Load;
    }
}