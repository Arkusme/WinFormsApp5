namespace WinFormsApp5
{
    partial class User
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
            ObnoveAuto = new Button();
            Obnovedriv = new Button();
            button3 = new Button();
            AutoDataGridView = new DataGridView();
            searchdriver = new Button();
            driversDataGridView = new DataGridView();
            tabPage1 = new TabPage();
            label29 = new Label();
            FIOVODtextBox = new TextBox();
            label27 = new Label();
            FIOGAItextBox = new TextBox();
            label17 = new Label();
            Info = new TextBox();
            Fine = new TextBox();
            Licenseplate = new TextBox();
            Description = new TextBox();
            ProtocolNumber = new TextBox();
            label20 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            VioldateTimePicker = new DateTimePicker();
            ObnoveViol = new Button();
            SearchViol = new Button();
            violationsDataGridView = new DataGridView();
            tabControl1 = new TabControl();
            label9 = new Label();
            label8 = new Label();
            certificateofregistrationtextbox = new TextBox();
            label7 = new Label();
            addresstextbox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            phonetextbox = new TextBox();
            label4 = new Label();
            passportnumbertextbox = new TextBox();
            label3 = new Label();
            middlenametextbox = new TextBox();
            firstnametextbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            driverDateOfBirthPicker = new DateTimePicker();
            driverLicenseTextBox = new TextBox();
            SurnameTextBox = new TextBox();
            label19 = new Label();
            label33 = new Label();
            StrahovkaTextBox = new TextBox();
            OwnerTextBox = new TextBox();
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
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            label36 = new Label();
            statuscomboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).BeginInit();
            tabControl1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ObnoveAuto
            // 
            ObnoveAuto.Location = new Point(914, 323);
            ObnoveAuto.Name = "ObnoveAuto";
            ObnoveAuto.Size = new Size(75, 23);
            ObnoveAuto.TabIndex = 285;
            ObnoveAuto.Text = "Обновить";
            ObnoveAuto.UseVisualStyleBackColor = true;
            ObnoveAuto.Click += ObnoveAuto_Click;
            // 
            // Obnovedriv
            // 
            Obnovedriv.Location = new Point(914, 159);
            Obnovedriv.Name = "Obnovedriv";
            Obnovedriv.Size = new Size(75, 23);
            Obnovedriv.TabIndex = 284;
            Obnovedriv.Text = "Обновить";
            Obnovedriv.UseVisualStyleBackColor = true;
            Obnovedriv.Click += Obnovedriv_Click;
            // 
            // button3
            // 
            button3.Location = new Point(786, 305);
            button3.Name = "button3";
            button3.Size = new Size(122, 59);
            button3.TabIndex = 251;
            button3.Text = "Поиск транспортного средства";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // AutoDataGridView
            // 
            AutoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AutoDataGridView.Location = new Point(543, 195);
            AutoDataGridView.Name = "AutoDataGridView";
            AutoDataGridView.RowTemplate.Height = 25;
            AutoDataGridView.Size = new Size(763, 104);
            AutoDataGridView.TabIndex = 247;
            // 
            // searchdriver
            // 
            searchdriver.Location = new Point(786, 152);
            searchdriver.Name = "searchdriver";
            searchdriver.Size = new Size(122, 37);
            searchdriver.TabIndex = 246;
            searchdriver.Text = "Поиск водителей";
            searchdriver.UseVisualStyleBackColor = true;
            searchdriver.Click += searchdriver_Click;
            // 
            // driversDataGridView
            // 
            driversDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driversDataGridView.Location = new Point(543, 31);
            driversDataGridView.Name = "driversDataGridView";
            driversDataGridView.RowTemplate.Height = 25;
            driversDataGridView.Size = new Size(763, 115);
            driversDataGridView.TabIndex = 244;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label36);
            tabPage1.Controls.Add(statuscomboBox);
            tabPage1.Controls.Add(label29);
            tabPage1.Controls.Add(FIOVODtextBox);
            tabPage1.Controls.Add(label27);
            tabPage1.Controls.Add(FIOGAItextBox);
            tabPage1.Controls.Add(label17);
            tabPage1.Controls.Add(Info);
            tabPage1.Controls.Add(Fine);
            tabPage1.Controls.Add(Licenseplate);
            tabPage1.Controls.Add(Description);
            tabPage1.Controls.Add(ProtocolNumber);
            tabPage1.Controls.Add(label20);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(label24);
            tabPage1.Controls.Add(label25);
            tabPage1.Controls.Add(label26);
            tabPage1.Controls.Add(VioldateTimePicker);
            tabPage1.Controls.Add(ObnoveViol);
            tabPage1.Controls.Add(SearchViol);
            tabPage1.Controls.Add(violationsDataGridView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1304, 198);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Правонарушения";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(289, 121);
            label29.Name = "label29";
            label29.Size = new Size(87, 15);
            label29.TabIndex = 264;
            label29.Text = "ФИО водителя";
            // 
            // FIOVODtextBox
            // 
            FIOVODtextBox.Location = new Point(276, 139);
            FIOVODtextBox.Name = "FIOVODtextBox";
            FIOVODtextBox.ReadOnly = true;
            FIOVODtextBox.Size = new Size(109, 23);
            FIOVODtextBox.TabIndex = 263;
            FIOVODtextBox.Text = " ";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(75, 121);
            label27.Name = "label27";
            label27.Size = new Size(126, 15);
            label27.TabIndex = 262;
            label27.Text = "ФИО сотрудника ГАИ";
            // 
            // FIOGAItextBox
            // 
            FIOGAItextBox.Location = new Point(62, 139);
            FIOGAItextBox.Name = "FIOGAItextBox";
            FIOGAItextBox.ReadOnly = true;
            FIOGAItextBox.Size = new Size(158, 23);
            FIOGAItextBox.TabIndex = 261;
            FIOGAItextBox.Text = " ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(329, 68);
            label17.Name = "label17";
            label17.Size = new Size(98, 15);
            label17.TabIndex = 260;
            label17.Text = "Дата нарушения";
            // 
            // Info
            // 
            Info.Location = new Point(170, 86);
            Info.Name = "Info";
            Info.Size = new Size(100, 23);
            Info.TabIndex = 259;
            // 
            // Fine
            // 
            Fine.Location = new Point(64, 86);
            Fine.Name = "Fine";
            Fine.Size = new Size(100, 23);
            Fine.TabIndex = 256;
            // 
            // Licenseplate
            // 
            Licenseplate.Location = new Point(285, 42);
            Licenseplate.Name = "Licenseplate";
            Licenseplate.Size = new Size(100, 23);
            Licenseplate.TabIndex = 254;
            // 
            // Description
            // 
            Description.Location = new Point(179, 42);
            Description.Name = "Description";
            Description.Size = new Size(100, 23);
            Description.TabIndex = 253;
            // 
            // ProtocolNumber
            // 
            ProtocolNumber.Location = new Point(64, 42);
            ProtocolNumber.Name = "ProtocolNumber";
            ProtocolNumber.Size = new Size(109, 23);
            ProtocolNumber.TabIndex = 249;
            ProtocolNumber.Text = " ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(169, 68);
            label20.Name = "label20";
            label20.Size = new Size(107, 15);
            label20.TabIndex = 258;
            label20.Text = "Краткое описание";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(85, 68);
            label23.Name = "label23";
            label23.Size = new Size(45, 15);
            label23.TabIndex = 257;
            label23.Text = "Штраф";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(296, 24);
            label24.Name = "label24";
            label24.Size = new Size(68, 15);
            label24.TabIndex = 255;
            label24.Text = "Гос. номер";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(191, 24);
            label25.Name = "label25";
            label25.Size = new Size(72, 15);
            label25.TabIndex = 252;
            label25.Text = "Нарушение";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(64, 24);
            label26.Name = "label26";
            label26.Size = new Size(107, 15);
            label26.TabIndex = 251;
            label26.Text = "Номер протокола";
            // 
            // VioldateTimePicker
            // 
            VioldateTimePicker.Location = new Point(276, 86);
            VioldateTimePicker.Name = "VioldateTimePicker";
            VioldateTimePicker.Size = new Size(224, 23);
            VioldateTimePicker.TabIndex = 250;
            // 
            // ObnoveViol
            // 
            ObnoveViol.Location = new Point(885, 146);
            ObnoveViol.Name = "ObnoveViol";
            ObnoveViol.Size = new Size(75, 23);
            ObnoveViol.TabIndex = 178;
            ObnoveViol.Text = "Обновить";
            ObnoveViol.UseVisualStyleBackColor = true;
            ObnoveViol.Click += ObnoveViol_Click;
            // 
            // SearchViol
            // 
            SearchViol.Location = new Point(757, 137);
            SearchViol.Name = "SearchViol";
            SearchViol.Size = new Size(122, 41);
            SearchViol.TabIndex = 174;
            SearchViol.Text = "Поиск нарушения";
            SearchViol.UseVisualStyleBackColor = true;
            SearchViol.Click += SearchViol_Click;
            // 
            // violationsDataGridView
            // 
            violationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            violationsDataGridView.Location = new Point(514, 31);
            violationsDataGridView.Name = "violationsDataGridView";
            violationsDataGridView.RowTemplate.Height = 25;
            violationsDataGridView.Size = new Size(763, 96);
            violationsDataGridView.TabIndex = 173;
            violationsDataGridView.CellContentClick += violationsDataGridView_CellContentClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(6, 370);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1312, 226);
            tabControl1.TabIndex = 243;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(212, 131);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 303;
            label9.Text = "Дата рождения";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(352, 72);
            label8.Name = "label8";
            label8.Size = new Size(168, 15);
            label8.TabIndex = 302;
            label8.Text = "Водительское удостоверение";
            // 
            // certificateofregistrationtextbox
            // 
            certificateofregistrationtextbox.Location = new Point(252, 90);
            certificateofregistrationtextbox.Name = "certificateofregistrationtextbox";
            certificateofregistrationtextbox.Size = new Size(101, 23);
            certificateofregistrationtextbox.TabIndex = 301;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(284, 72);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 300;
            label7.Text = "СТС";
            // 
            // addresstextbox
            // 
            addresstextbox.Location = new Point(138, 90);
            addresstextbox.Name = "addresstextbox";
            addresstextbox.Size = new Size(100, 23);
            addresstextbox.TabIndex = 299;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(169, 72);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 298;
            label6.Text = "Адрес";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 72);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 297;
            label5.Text = "Телефон";
            // 
            // phonetextbox
            // 
            phonetextbox.Location = new Point(32, 90);
            phonetextbox.Name = "phonetextbox";
            phonetextbox.Size = new Size(100, 23);
            phonetextbox.TabIndex = 296;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(384, 28);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 295;
            label4.Text = "Паспорт";
            // 
            // passportnumbertextbox
            // 
            passportnumbertextbox.Location = new Point(369, 46);
            passportnumbertextbox.Name = "passportnumbertextbox";
            passportnumbertextbox.Size = new Size(100, 23);
            passportnumbertextbox.TabIndex = 294;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 28);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 293;
            label3.Text = "Отчество";
            // 
            // middlenametextbox
            // 
            middlenametextbox.Location = new Point(253, 46);
            middlenametextbox.Name = "middlenametextbox";
            middlenametextbox.Size = new Size(100, 23);
            middlenametextbox.TabIndex = 292;
            // 
            // firstnametextbox
            // 
            firstnametextbox.Location = new Point(147, 46);
            firstnametextbox.Name = "firstnametextbox";
            firstnametextbox.Size = new Size(100, 23);
            firstnametextbox.TabIndex = 291;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 28);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 290;
            label2.Text = "Имя";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 28);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 289;
            label1.Text = "Фамилия";
            // 
            // driverDateOfBirthPicker
            // 
            driverDateOfBirthPicker.Location = new Point(147, 149);
            driverDateOfBirthPicker.Name = "driverDateOfBirthPicker";
            driverDateOfBirthPicker.Size = new Size(224, 23);
            driverDateOfBirthPicker.TabIndex = 288;
            // 
            // driverLicenseTextBox
            // 
            driverLicenseTextBox.Location = new Point(369, 90);
            driverLicenseTextBox.Name = "driverLicenseTextBox";
            driverLicenseTextBox.Size = new Size(109, 23);
            driverLicenseTextBox.TabIndex = 287;
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(32, 46);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(109, 23);
            SurnameTextBox.TabIndex = 286;
            SurnameTextBox.Text = " ";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(421, 241);
            label19.Name = "label19";
            label19.Size = new Size(34, 15);
            label19.TabIndex = 317;
            label19.Text = "ФИО";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(219, 244);
            label33.Name = "label33";
            label33.Size = new Size(147, 15);
            label33.TabIndex = 315;
            label33.Text = "Страховое свидетельство";
            // 
            // StrahovkaTextBox
            // 
            StrahovkaTextBox.Location = new Point(240, 259);
            StrahovkaTextBox.Name = "StrahovkaTextBox";
            StrahovkaTextBox.Size = new Size(107, 23);
            StrahovkaTextBox.TabIndex = 314;
            // 
            // OwnerTextBox
            // 
            OwnerTextBox.Location = new Point(383, 259);
            OwnerTextBox.Name = "OwnerTextBox";
            OwnerTextBox.ReadOnly = true;
            OwnerTextBox.Size = new Size(109, 23);
            OwnerTextBox.TabIndex = 316;
            OwnerTextBox.Text = " ";
            // 
            // Марка
            // 
            Марка.AutoSize = true;
            Марка.Location = new Point(74, 200);
            Марка.Name = "Марка";
            Марка.Size = new Size(43, 15);
            Марка.TabIndex = 313;
            Марка.Text = "Марка";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(195, 200);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 312;
            label14.Text = "Модель";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(298, 200);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 311;
            label13.Text = "Гос. номер";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(398, 200);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 310;
            label12.Text = "Год выпуска авто";
            // 
            // ModeltextBox
            // 
            ModeltextBox.Location = new Point(161, 218);
            ModeltextBox.Name = "ModeltextBox";
            ModeltextBox.Size = new Size(109, 23);
            ModeltextBox.TabIndex = 309;
            // 
            // PlatetextBox
            // 
            PlatetextBox.Location = new Point(276, 218);
            PlatetextBox.Name = "PlatetextBox";
            PlatetextBox.Size = new Size(109, 23);
            PlatetextBox.TabIndex = 308;
            // 
            // yeartextBox
            // 
            yeartextBox.Location = new Point(391, 218);
            yeartextBox.Name = "yeartextBox";
            yeartextBox.Size = new Size(109, 23);
            yeartextBox.TabIndex = 307;
            // 
            // STStextBox
            // 
            STStextBox.Location = new Point(126, 259);
            STStextBox.Name = "STStextBox";
            STStextBox.Size = new Size(101, 23);
            STStextBox.TabIndex = 306;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(160, 241);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 305;
            label10.Text = "СТС";
            // 
            // MakeTextBox
            // 
            MakeTextBox.Location = new Point(46, 218);
            MakeTextBox.Name = "MakeTextBox";
            MakeTextBox.Size = new Size(109, 23);
            MakeTextBox.TabIndex = 304;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1409, 24);
            menuStrip1.TabIndex = 318;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { очиститьToolStripMenuItem, выходToolStripMenuItem });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(53, 20);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(126, 22);
            очиститьToolStripMenuItem.Text = "Очистить";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(126, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(395, 24);
            label36.Name = "label36";
            label36.Size = new Size(90, 15);
            label36.TabIndex = 266;
            label36.Text = "Статус штрафа";
            // 
            // statuscomboBox
            // 
            statuscomboBox.FormattingEnabled = true;
            statuscomboBox.Location = new Point(391, 42);
            statuscomboBox.Name = "statuscomboBox";
            statuscomboBox.Size = new Size(109, 23);
            statuscomboBox.TabIndex = 265;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1409, 575);
            Controls.Add(label19);
            Controls.Add(label33);
            Controls.Add(StrahovkaTextBox);
            Controls.Add(OwnerTextBox);
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
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(certificateofregistrationtextbox);
            Controls.Add(label7);
            Controls.Add(addresstextbox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(phonetextbox);
            Controls.Add(label4);
            Controls.Add(passportnumbertextbox);
            Controls.Add(label3);
            Controls.Add(middlenametextbox);
            Controls.Add(firstnametextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(driverDateOfBirthPicker);
            Controls.Add(driverLicenseTextBox);
            Controls.Add(SurnameTextBox);
            Controls.Add(ObnoveAuto);
            Controls.Add(Obnovedriv);
            Controls.Add(button3);
            Controls.Add(AutoDataGridView);
            Controls.Add(searchdriver);
            Controls.Add(driversDataGridView);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "User";
            Text = "User";
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).EndInit();
            tabControl1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ObnoveAuto;
        private Button Obnovedriv;
        private Button button3;
        private DataGridView AutoDataGridView;
        private Button searchdriver;
        private DataGridView driversDataGridView;
        private TabPage tabPage1;
        private Button ObnoveViol;
        private Button SearchViol;
        private DataGridView violationsDataGridView;
        private TabControl tabControl1;
        private Label label9;
        private Label label8;
        private TextBox certificateofregistrationtextbox;
        private Label label7;
        private TextBox addresstextbox;
        private Label label6;
        private Label label5;
        private TextBox phonetextbox;
        private Label label4;
        private TextBox passportnumbertextbox;
        private Label label3;
        private TextBox middlenametextbox;
        private TextBox firstnametextbox;
        private Label label2;
        private Label label1;
        private DateTimePicker driverDateOfBirthPicker;
        private TextBox driverLicenseTextBox;
        private TextBox SurnameTextBox;
        private Label label19;
        private Label label33;
        private TextBox StrahovkaTextBox;
        private TextBox OwnerTextBox;
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
        private Label label29;
        private TextBox FIOVODtextBox;
        private Label label27;
        private TextBox FIOGAItextBox;
        private Label label17;
        private TextBox Info;
        private TextBox Fine;
        private TextBox Licenseplate;
        private TextBox Description;
        private TextBox ProtocolNumber;
        private Label label20;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private DateTimePicker VioldateTimePicker;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Label label36;
        private ComboBox statuscomboBox;
    }
}