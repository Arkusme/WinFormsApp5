namespace WinFormsApp5
{
    partial class AutoDetailsForm
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
            Марка = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            ModeltextBox = new TextBox();
            PlatetextBox = new TextBox();
            yeartextBox = new TextBox();
            STStextBox = new TextBox();
            label10 = new Label();
            MakeTextBox = new TextBox();
            SuspendLayout();
            // 
            // Марка
            // 
            Марка.AutoSize = true;
            Марка.Location = new Point(188, 7);
            Марка.Name = "Марка";
            Марка.Size = new Size(43, 15);
            Марка.TabIndex = 52;
            Марка.Text = "Марка";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(309, 7);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 51;
            label14.Text = "Модель";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(412, 7);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 50;
            label13.Text = "Гос. номер";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(512, 7);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 49;
            label12.Text = "Год выпуска авто";
            // 
            // ModeltextBox
            // 
            ModeltextBox.Location = new Point(275, 25);
            ModeltextBox.Name = "ModeltextBox";
            ModeltextBox.Size = new Size(109, 23);
            ModeltextBox.TabIndex = 48;
            // 
            // PlatetextBox
            // 
            PlatetextBox.Location = new Point(390, 25);
            PlatetextBox.Name = "PlatetextBox";
            PlatetextBox.Size = new Size(109, 23);
            PlatetextBox.TabIndex = 47;
            // 
            // yeartextBox
            // 
            yeartextBox.Location = new Point(505, 25);
            yeartextBox.Name = "yeartextBox";
            yeartextBox.Size = new Size(109, 23);
            yeartextBox.TabIndex = 46;
            // 
            // STStextBox
            // 
            STStextBox.Location = new Point(340, 71);
            STStextBox.Name = "STStextBox";
            STStextBox.Size = new Size(101, 23);
            STStextBox.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(374, 53);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 44;
            label10.Text = "СТС";
            // 
            // MakeTextBox
            // 
            MakeTextBox.Location = new Point(160, 25);
            MakeTextBox.Name = "MakeTextBox";
            MakeTextBox.Size = new Size(109, 23);
            MakeTextBox.TabIndex = 43;
            // 
            // AutoDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 123);
            Controls.Add(Марка);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(ModeltextBox);
            Controls.Add(PlatetextBox);
            Controls.Add(yeartextBox);
            Controls.Add(STStextBox);
            Controls.Add(label10);
            Controls.Add(MakeTextBox);
            Name = "AutoDetailsForm";
            Text = "AutoDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Марка;
        private Label label14;
        private Label label13;
        private Label label12;
        private TextBox ModeltextBox;
        private TextBox PlatetextBox;
        private TextBox yeartextBox;
        private TextBox STStextBox;
        private Label label10;
        private TextBox MakeTextBox;
    }
}