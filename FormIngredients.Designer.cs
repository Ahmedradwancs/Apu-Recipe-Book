
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
            numOfIng = new Label();
            groupBox1 = new GroupBox();
            listIngredients = new ListBox();
            btnDel = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            textUpdate = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
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
            // numOfIng
            // 
            numOfIng.AutoSize = true;
            numOfIng.Location = new Point(500, 24);
            numOfIng.Name = "numOfIng";
            numOfIng.Size = new Size(60, 20);
            numOfIng.TabIndex = 1;
            numOfIng.Text = "number";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listIngredients);
            groupBox1.Controls.Add(btnDel);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(textUpdate);
            groupBox1.Location = new Point(32, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(521, 392);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingredient";
            // 
            // listIngredients
            // 
            listIngredients.FormattingEnabled = true;
            listIngredients.Location = new Point(21, 94);
            listIngredients.Name = "listIngredients";
            listIngredients.Size = new Size(403, 264);
            listIngredients.TabIndex = 5;
            // 
            // btnDel
            // 
            btnDel.BackColor = SystemColors.ScrollBar;
            btnDel.Location = new Point(430, 148);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(77, 39);
            btnDel.TabIndex = 4;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click_1;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ScrollBar;
            btnEdit.Location = new Point(430, 94);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(77, 39);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ScrollBar;
            btnAdd.Location = new Point(430, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(77, 39);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // textUpdate
            // 
            textUpdate.Location = new Point(21, 39);
            textUpdate.Multiline = true;
            textUpdate.Name = "textUpdate";
            textUpdate.Size = new Size(403, 38);
            textUpdate.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.BackColor = SystemColors.ScrollBar;
            btnOk.Location = new Point(76, 456);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(139, 38);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ScrollBar;
            btnCancel.Location = new Point(267, 456);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(139, 38);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // FormIngredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 506);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(groupBox1);
            Controls.Add(numOfIng);
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
        private Label numOfIng;
        private GroupBox groupBox1;
        private TextBox textUpdate;
        private EventHandler FormIngredients_Load;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private ListBox listIngredients;
        private Button btnOk;
        private Button btnCancel;
    }
}