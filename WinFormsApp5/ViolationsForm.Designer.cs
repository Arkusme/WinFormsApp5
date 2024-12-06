namespace WinFormsApp5
{
    partial class ViolationsForm
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
            label17 = new Label();
            label20 = new Label();
            label23 = new Label();
            Fine = new TextBox();
            label24 = new Label();
            Licenseplate = new TextBox();
            Description = new TextBox();
            label25 = new Label();
            label26 = new Label();
            VioldateTimePicker = new DateTimePicker();
            ProtocolNumber = new TextBox();
            label1 = new Label();
            DriverNameTextBox = new TextBox();
            InfolistBox = new ListBox();
            SuspendLayout();
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(617, 10);
            label17.Name = "label17";
            label17.Size = new Size(98, 15);
            label17.TabIndex = 100;
            label17.Text = "Дата нарушения";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(345, 72);
            label20.Name = "label20";
            label20.Size = new Size(107, 15);
            label20.TabIndex = 98;
            label20.Text = "Краткое описание";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(386, 10);
            label23.Name = "label23";
            label23.Size = new Size(45, 15);
            label23.TabIndex = 97;
            label23.Text = "Штраф";
            // 
            // Fine
            // 
            Fine.Location = new Point(352, 28);
            Fine.Name = "Fine";
            Fine.Size = new Size(100, 23);
            Fine.TabIndex = 96;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(250, 10);
            label24.Name = "label24";
            label24.Size = new Size(68, 15);
            label24.TabIndex = 95;
            label24.Text = "Гос. номер";
            // 
            // Licenseplate
            // 
            Licenseplate.Location = new Point(239, 28);
            Licenseplate.Name = "Licenseplate";
            Licenseplate.Size = new Size(100, 23);
            Licenseplate.TabIndex = 94;
            // 
            // Description
            // 
            Description.Location = new Point(133, 28);
            Description.Name = "Description";
            Description.Size = new Size(100, 23);
            Description.TabIndex = 93;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(145, 10);
            label25.Name = "label25";
            label25.Size = new Size(72, 15);
            label25.TabIndex = 92;
            label25.Text = "Нарушение";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(18, 10);
            label26.Name = "label26";
            label26.Size = new Size(107, 15);
            label26.TabIndex = 91;
            label26.Text = "Номер протокола";
            // 
            // VioldateTimePicker
            // 
            VioldateTimePicker.Location = new Point(564, 28);
            VioldateTimePicker.Name = "VioldateTimePicker";
            VioldateTimePicker.Size = new Size(224, 23);
            VioldateTimePicker.TabIndex = 90;
            // 
            // ProtocolNumber
            // 
            ProtocolNumber.Location = new Point(18, 28);
            ProtocolNumber.Name = "ProtocolNumber";
            ProtocolNumber.Size = new Size(109, 23);
            ProtocolNumber.TabIndex = 89;
            ProtocolNumber.Text = " ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, 13);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 102;
            label1.Text = "Водитель";
            // 
            // DriverNameTextBox
            // 
            DriverNameTextBox.Location = new Point(457, 31);
            DriverNameTextBox.Name = "DriverNameTextBox";
            DriverNameTextBox.Size = new Size(100, 23);
            DriverNameTextBox.TabIndex = 101;
            // 
            // InfolistBox
            // 
            InfolistBox.FormattingEnabled = true;
            InfolistBox.HorizontalScrollbar = true;
            InfolistBox.ItemHeight = 15;
            InfolistBox.Location = new Point(271, 90);
            InfolistBox.Name = "InfolistBox";
            InfolistBox.Size = new Size(259, 94);
            InfolistBox.TabIndex = 103;
            // 
            // ViolationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 201);
            Controls.Add(InfolistBox);
            Controls.Add(label1);
            Controls.Add(DriverNameTextBox);
            Controls.Add(label17);
            Controls.Add(label20);
            Controls.Add(label23);
            Controls.Add(Fine);
            Controls.Add(label24);
            Controls.Add(Licenseplate);
            Controls.Add(Description);
            Controls.Add(label25);
            Controls.Add(label26);
            Controls.Add(VioldateTimePicker);
            Controls.Add(ProtocolNumber);
            Name = "ViolationsForm";
            Text = "ViolationsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label17;
        private Label label20;
        private Label label23;
        private TextBox Fine;
        private Label label24;
        private TextBox Licenseplate;
        private TextBox Description;
        private Label label25;
        private Label label26;
        private DateTimePicker VioldateTimePicker;
        private TextBox ProtocolNumber;
        private Label label1;
        private TextBox DriverNameTextBox;
        private ListBox InfolistBox;
    }
}