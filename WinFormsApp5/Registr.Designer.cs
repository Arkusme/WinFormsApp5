namespace WinFormsApp5
{
    partial class Registr
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
            label28 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label30 = new Label();
            NumberTextBox = new TextBox();
            strahTextBox = new TextBox();
            label31 = new Label();
            label32 = new Label();
            STStextBox5 = new TextBox();
            label1 = new Label();
            DriverNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(578, 9);
            label28.Name = "label28";
            label28.Size = new Size(105, 15);
            label28.TabIndex = 220;
            label28.Text = "Дата регситрации";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(526, 27);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(224, 23);
            dateTimePicker1.TabIndex = 219;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(325, 9);
            label30.Name = "label30";
            label30.Size = new Size(68, 15);
            label30.TabIndex = 217;
            label30.Text = "Гос. номер";
            // 
            // NumberTextBox
            // 
            NumberTextBox.Location = new Point(314, 27);
            NumberTextBox.Name = "NumberTextBox";
            NumberTextBox.Size = new Size(100, 23);
            NumberTextBox.TabIndex = 216;
            // 
            // strahTextBox
            // 
            strahTextBox.Location = new Point(187, 27);
            strahTextBox.Name = "strahTextBox";
            strahTextBox.Size = new Size(100, 23);
            strahTextBox.TabIndex = 215;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(168, 9);
            label31.Name = "label31";
            label31.Size = new Size(147, 15);
            label31.TabIndex = 214;
            label31.Text = "Страховое свидетельство";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(100, 9);
            label32.Name = "label32";
            label32.Size = new Size(29, 15);
            label32.TabIndex = 213;
            label32.Text = "СТС";
            // 
            // STStextBox5
            // 
            STStextBox5.Location = new Point(64, 27);
            STStextBox5.Name = "STStextBox5";
            STStextBox5.Size = new Size(99, 23);
            STStextBox5.TabIndex = 211;
            STStextBox5.Text = " ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(435, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 222;
            label1.Text = "Водитель";
            // 
            // DriverNameTextBox
            // 
            DriverNameTextBox.Location = new Point(420, 27);
            DriverNameTextBox.Name = "DriverNameTextBox";
            DriverNameTextBox.Size = new Size(100, 23);
            DriverNameTextBox.TabIndex = 221;
            // 
            // Registr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 65);
            Controls.Add(label1);
            Controls.Add(DriverNameTextBox);
            Controls.Add(label28);
            Controls.Add(dateTimePicker1);
            Controls.Add(label30);
            Controls.Add(NumberTextBox);
            Controls.Add(strahTextBox);
            Controls.Add(label31);
            Controls.Add(label32);
            Controls.Add(STStextBox5);
            Name = "Registr";
            Text = "Registr";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label28;
        private DateTimePicker dateTimePicker1;
        private Label label30;
        private TextBox NumberTextBox;
        private TextBox strahTextBox;
        private Label label31;
        private Label label32;
        private TextBox STStextBox5;
        private Label label1;
        private TextBox DriverNameTextBox;
    }
}