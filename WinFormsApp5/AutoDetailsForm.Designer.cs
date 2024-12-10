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
            label1 = new Label();
            DriverNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // Марка
            // 
            Марка.AutoSize = true;
            Марка.Location = new Point(120, 7);
            Марка.Name = "Марка";
            Марка.Size = new Size(43, 15);
            Марка.TabIndex = 52;
            Марка.Text = "Марка";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(241, 7);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 51;
            label14.Text = "Модель";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(344, 7);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 50;
            label13.Text = "Гос. номер";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(444, 7);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 49;
            label12.Text = "Год выпуска авто";
            // 
            // ModeltextBox
            // 
            ModeltextBox.Location = new Point(207, 25);
            ModeltextBox.Name = "ModeltextBox";
            ModeltextBox.Size = new Size(109, 23);
            ModeltextBox.TabIndex = 48;
            // 
            // PlatetextBox
            // 
            PlatetextBox.Location = new Point(322, 25);
            PlatetextBox.Name = "PlatetextBox";
            PlatetextBox.Size = new Size(109, 23);
            PlatetextBox.TabIndex = 47;
            // 
            // yeartextBox
            // 
            yeartextBox.Location = new Point(437, 25);
            yeartextBox.Name = "yeartextBox";
            yeartextBox.Size = new Size(109, 23);
            yeartextBox.TabIndex = 46;
            // 
            // STStextBox
            // 
            STStextBox.Location = new Point(552, 25);
            STStextBox.Name = "STStextBox";
            STStextBox.Size = new Size(101, 23);
            STStextBox.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(586, 7);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 44;
            label10.Text = "СТС";
            // 
            // MakeTextBox
            // 
            MakeTextBox.Location = new Point(92, 25);
            MakeTextBox.Name = "MakeTextBox";
            MakeTextBox.Size = new Size(109, 23);
            MakeTextBox.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 7);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 224;
            label1.Text = "Водитель";
            // 
            // DriverNameTextBox
            // 
            DriverNameTextBox.Location = new Point(659, 25);
            DriverNameTextBox.Name = "DriverNameTextBox";
            DriverNameTextBox.Size = new Size(100, 23);
            DriverNameTextBox.TabIndex = 223;
            // 
            // AutoDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 63);
            Controls.Add(label1);
            Controls.Add(DriverNameTextBox);
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
        private Label label1;
        private TextBox DriverNameTextBox;
    }
}