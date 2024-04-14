namespace Assignment4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnAddRec = new Button();
            textInstructions = new TextBox();
            btnAddIng = new Button();
            comboCategory = new ComboBox();
            label2 = new Label();
            textRecipeName = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnEditBegin = new Button();
            btnEditFInish = new Button();
            btnDel = new Button();
            btnClear = new Button();
            textEnd = new Label();
            listRecipes = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddRec);
            groupBox1.Controls.Add(textInstructions);
            groupBox1.Controls.Add(btnAddIng);
            groupBox1.Controls.Add(comboCategory);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textRecipeName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(11, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(482, 431);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add new recipe";
            // 
            // btnAddRec
            // 
            btnAddRec.BackColor = SystemColors.ScrollBar;
            btnAddRec.Location = new Point(15, 375);
            btnAddRec.Name = "btnAddRec";
            btnAddRec.Size = new Size(450, 46);
            btnAddRec.TabIndex = 6;
            btnAddRec.Text = "Add recipe";
            btnAddRec.UseVisualStyleBackColor = false;
            btnAddRec.Click += btnAddRec_Click;
            // 
            // textInstructions
            // 
            textInstructions.Location = new Point(13, 122);
            textInstructions.Multiline = true;
            textInstructions.Name = "textInstructions";
            textInstructions.Size = new Size(452, 235);
            textInstructions.TabIndex = 5;
            // 
            // btnAddIng
            // 
            btnAddIng.BackColor = SystemColors.Menu;
            btnAddIng.Location = new Point(290, 77);
            btnAddIng.Name = "btnAddIng";
            btnAddIng.Size = new Size(175, 28);
            btnAddIng.TabIndex = 4;
            btnAddIng.Text = "Add Ingredients";
            btnAddIng.UseVisualStyleBackColor = false;
            btnAddIng.Click += btnAddIng_Click;
            // 
            // comboCategory
            // 
            comboCategory.BackColor = SystemColors.Menu;
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(116, 77);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(152, 28);
            comboCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 80);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 2;
            label2.Text = "Category";
            // 
            // textRecipeName
            // 
            textRecipeName.Location = new Point(154, 31);
            textRecipeName.Name = "textRecipeName";
            textRecipeName.Size = new Size(311, 27);
            textRecipeName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 38);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Name of recipe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(510, 28);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(671, 28);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Category";
            // 
            // label5
            // 
            label5.Location = new Point(784, 28);
            label5.Name = "label5";
            label5.Size = new Size(143, 35);
            label5.TabIndex = 4;
            label5.Text = "No. of Ingredients";
            // 
            // btnEditBegin
            // 
            btnEditBegin.BackColor = SystemColors.ScrollBar;
            btnEditBegin.Location = new Point(509, 375);
            btnEditBegin.Name = "btnEditBegin";
            btnEditBegin.Size = new Size(99, 29);
            btnEditBegin.TabIndex = 5;
            btnEditBegin.Text = "Edit-Begin";
            btnEditBegin.UseVisualStyleBackColor = false;
            btnEditBegin.Click += btnEditBegin_Click_1;
            // 
            // btnEditFInish
            // 
            btnEditFInish.BackColor = SystemColors.ScrollBar;
            btnEditFInish.Location = new Point(615, 375);
            btnEditFInish.Name = "btnEditFInish";
            btnEditFInish.Size = new Size(107, 29);
            btnEditFInish.TabIndex = 6;
            btnEditFInish.Text = "Edit-Finish";
            btnEditFInish.UseVisualStyleBackColor = false;
            btnEditFInish.Click += btnEditFinish_Click_1;
            // 
            // btnDel
            // 
            btnDel.BackColor = SystemColors.ScrollBar;
            btnDel.Location = new Point(729, 375);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(97, 29);
            btnDel.TabIndex = 7;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ScrollBar;
            btnClear.Location = new Point(831, 375);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear Selection";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // textEnd
            // 
            textEnd.Location = new Point(499, 407);
            textEnd.Name = "textEnd";
            textEnd.Size = new Size(447, 34);
            textEnd.TabIndex = 9;
            // 
            // listRecipes
            // 
            listRecipes.FormattingEnabled = true;
            listRecipes.Location = new Point(510, 67);
            listRecipes.Name = "listRecipes";
            listRecipes.Size = new Size(436, 304);
            listRecipes.TabIndex = 11;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 450);
            Controls.Add(listRecipes);
            Controls.Add(textEnd);
            Controls.Add(btnClear);
            Controls.Add(btnDel);
            Controls.Add(btnEditFInish);
            Controls.Add(btnEditBegin);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Name = "FormMain";
            Text = "Apu Recipe book";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private TextBox textRecipeName;
        private Label label1;
        private Button btnAddRec;
        private TextBox textInstructions;
        private Button btnAddIng;
        private ComboBox comboCategory;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnEditBegin;
        private Button btnEditFInish;
        private Button btnDel;
        private Button btnClear;
        private Label textEnd;
        private ListBox listRecipes;
    }
}
