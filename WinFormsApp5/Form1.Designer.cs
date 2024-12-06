namespace WinFormsApp5
{
    partial class Form1
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
            driversDataGridView = new DataGridView();
            SurnameTextBox = new TextBox();
            searchdriver = new Button();
            violationsDataGridView = new DataGridView();
            AutoDataGridView = new DataGridView();
            PolicemanDataGridView = new DataGridView();
            SearchPolice = new Button();
            MakeTextBox = new TextBox();
            button3 = new Button();
            driverLicenseTextBox = new TextBox();
            driverDateOfBirthPicker = new DateTimePicker();
            Adddriver = new Button();
            Editdriver = new Button();
            Deletedriver = new Button();
            label1 = new Label();
            label2 = new Label();
            firstnametextbox = new TextBox();
            middlenametextbox = new TextBox();
            label3 = new Label();
            passportnumbertextbox = new TextBox();
            label4 = new Label();
            phonetextbox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            addresstextbox = new TextBox();
            label7 = new Label();
            certificateofregistrationtextbox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            STStextBox = new TextBox();
            label10 = new Label();
            yeartextBox = new TextBox();
            PlatetextBox = new TextBox();
            ModeltextBox = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            Марка = new Label();
            AddCar = new Button();
            EditCar = new Button();
            DeleteCar = new Button();
            Obnovedriv = new Button();
            ObnoveAuto = new Button();
            Addpolice = new Button();
            EditPolice = new Button();
            DeletePolice = new Button();
            ObnovePolice = new Button();
            label11 = new Label();
            label15 = new Label();
            positionTextBox = new TextBox();
            label16 = new Label();
            addrTextBox = new TextBox();
            labek = new Label();
            label18 = new Label();
            protophonTextBox = new TextBox();
            label = new Label();
            passportTextBox = new TextBox();
            lab = new Label();
            miNameTextBox = new TextBox();
            fiNameTextBox = new TextBox();
            label21 = new Label();
            label22 = new Label();
            DateOfBirthPicker = new DateTimePicker();
            rankTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            ObnoveViol = new Button();
            DelViol = new Button();
            button4 = new Button();
            button5 = new Button();
            SearchViol = new Button();
            label17 = new Label();
            Info = new TextBox();
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
            issuedProtocolsTextBox = new TextBox();
            label19 = new Label();
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PolicemanDataGridView).BeginInit();
            SuspendLayout();
            // 
            // driversDataGridView
            // 
            driversDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driversDataGridView.Location = new Point(535, 17);
            driversDataGridView.Name = "driversDataGridView";
            driversDataGridView.RowTemplate.Height = 25;
            driversDataGridView.Size = new Size(763, 115);
            driversDataGridView.TabIndex = 0;
            driversDataGridView.CellContentClick += driversDataGridView_CellContentClick;
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(12, 35);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(109, 23);
            SurnameTextBox.TabIndex = 1;
            SurnameTextBox.Text = " ";
            // 
            // searchdriver
            // 
            searchdriver.Location = new Point(516, 138);
            searchdriver.Name = "searchdriver";
            searchdriver.Size = new Size(122, 37);
            searchdriver.TabIndex = 3;
            searchdriver.Text = "Поиск водителей";
            searchdriver.UseVisualStyleBackColor = true;
            searchdriver.Click += button1_Click;
            // 
            // violationsDataGridView
            // 
            violationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            violationsDataGridView.Location = new Point(535, 499);
            violationsDataGridView.Name = "violationsDataGridView";
            violationsDataGridView.RowTemplate.Height = 25;
            violationsDataGridView.Size = new Size(763, 96);
            violationsDataGridView.TabIndex = 4;
            violationsDataGridView.CellContentClick += violationsDataGridView_CellContentClick;
            // 
            // AutoDataGridView
            // 
            AutoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AutoDataGridView.Location = new Point(535, 181);
            AutoDataGridView.Name = "AutoDataGridView";
            AutoDataGridView.RowTemplate.Height = 25;
            AutoDataGridView.Size = new Size(763, 104);
            AutoDataGridView.TabIndex = 5;
            AutoDataGridView.CellContentClick += AutoDataGridView_CellContentClick;
            // 
            // PolicemanDataGridView
            // 
            PolicemanDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PolicemanDataGridView.Location = new Point(535, 356);
            PolicemanDataGridView.Name = "PolicemanDataGridView";
            PolicemanDataGridView.RowTemplate.Height = 25;
            PolicemanDataGridView.Size = new Size(763, 90);
            PolicemanDataGridView.TabIndex = 6;
            PolicemanDataGridView.CellContentClick += PolicemanDataGridView_CellContentClick;
            // 
            // SearchPolice
            // 
            SearchPolice.Location = new Point(516, 452);
            SearchPolice.Name = "SearchPolice";
            SearchPolice.Size = new Size(122, 41);
            SearchPolice.TabIndex = 7;
            SearchPolice.Text = "Поиск сотрудников ГАИ";
            SearchPolice.UseVisualStyleBackColor = true;
            SearchPolice.Click += button2_Click;
            // 
            // MakeTextBox
            // 
            MakeTextBox.Location = new Point(12, 221);
            MakeTextBox.Name = "MakeTextBox";
            MakeTextBox.Size = new Size(109, 23);
            MakeTextBox.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(516, 291);
            button3.Name = "button3";
            button3.Size = new Size(122, 59);
            button3.TabIndex = 10;
            button3.Text = "Поиск транспортного средства";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // driverLicenseTextBox
            // 
            driverLicenseTextBox.Location = new Point(349, 79);
            driverLicenseTextBox.Name = "driverLicenseTextBox";
            driverLicenseTextBox.Size = new Size(109, 23);
            driverLicenseTextBox.TabIndex = 11;
            // 
            // driverDateOfBirthPicker
            // 
            driverDateOfBirthPicker.Location = new Point(127, 138);
            driverDateOfBirthPicker.Name = "driverDateOfBirthPicker";
            driverDateOfBirthPicker.Size = new Size(224, 23);
            driverDateOfBirthPicker.TabIndex = 12;
            // 
            // Adddriver
            // 
            Adddriver.Location = new Point(663, 145);
            Adddriver.Name = "Adddriver";
            Adddriver.Size = new Size(75, 23);
            Adddriver.TabIndex = 13;
            Adddriver.Text = "добавить";
            Adddriver.UseVisualStyleBackColor = true;
            Adddriver.Click += Adddriver_Click;
            // 
            // Editdriver
            // 
            Editdriver.Location = new Point(744, 145);
            Editdriver.Name = "Editdriver";
            Editdriver.Size = new Size(75, 23);
            Editdriver.TabIndex = 14;
            Editdriver.Text = "изменить";
            Editdriver.UseVisualStyleBackColor = true;
            Editdriver.Click += Editdriver_Click;
            // 
            // Deletedriver
            // 
            Deletedriver.Location = new Point(825, 145);
            Deletedriver.Name = "Deletedriver";
            Deletedriver.Size = new Size(75, 23);
            Deletedriver.TabIndex = 15;
            Deletedriver.Text = "удалить";
            Deletedriver.UseVisualStyleBackColor = true;
            Deletedriver.Click += Deletedriver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 17);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 16;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 17);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 17;
            label2.Text = "Имя";
            // 
            // firstnametextbox
            // 
            firstnametextbox.Location = new Point(127, 35);
            firstnametextbox.Name = "firstnametextbox";
            firstnametextbox.Size = new Size(100, 23);
            firstnametextbox.TabIndex = 18;
            // 
            // middlenametextbox
            // 
            middlenametextbox.Location = new Point(233, 35);
            middlenametextbox.Name = "middlenametextbox";
            middlenametextbox.Size = new Size(100, 23);
            middlenametextbox.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 17);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 20;
            label3.Text = "Отчество";
            // 
            // passportnumbertextbox
            // 
            passportnumbertextbox.Location = new Point(349, 35);
            passportnumbertextbox.Name = "passportnumbertextbox";
            passportnumbertextbox.Size = new Size(100, 23);
            passportnumbertextbox.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 17);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 22;
            label4.Text = "Паспорт";
            // 
            // phonetextbox
            // 
            phonetextbox.Location = new Point(12, 79);
            phonetextbox.Name = "phonetextbox";
            phonetextbox.Size = new Size(100, 23);
            phonetextbox.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 61);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 24;
            label5.Text = "Телефон";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(149, 61);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 25;
            label6.Text = "Адрес";
            // 
            // addresstextbox
            // 
            addresstextbox.Location = new Point(118, 79);
            addresstextbox.Name = "addresstextbox";
            addresstextbox.Size = new Size(100, 23);
            addresstextbox.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(264, 61);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 27;
            label7.Text = "СТС";
            // 
            // certificateofregistrationtextbox
            // 
            certificateofregistrationtextbox.Location = new Point(232, 79);
            certificateofregistrationtextbox.Name = "certificateofregistrationtextbox";
            certificateofregistrationtextbox.Size = new Size(101, 23);
            certificateofregistrationtextbox.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(332, 61);
            label8.Name = "label8";
            label8.Size = new Size(168, 15);
            label8.TabIndex = 29;
            label8.Text = "Водительское удостоверение";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(192, 120);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 30;
            label9.Text = "Дата рождения";
            // 
            // STStextBox
            // 
            STStextBox.Location = new Point(192, 267);
            STStextBox.Name = "STStextBox";
            STStextBox.Size = new Size(101, 23);
            STStextBox.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(226, 249);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 32;
            label10.Text = "СТС";
            // 
            // yeartextBox
            // 
            yeartextBox.Location = new Point(357, 221);
            yeartextBox.Name = "yeartextBox";
            yeartextBox.Size = new Size(109, 23);
            yeartextBox.TabIndex = 35;
            // 
            // PlatetextBox
            // 
            PlatetextBox.Location = new Point(242, 221);
            PlatetextBox.Name = "PlatetextBox";
            PlatetextBox.Size = new Size(109, 23);
            PlatetextBox.TabIndex = 36;
            // 
            // ModeltextBox
            // 
            ModeltextBox.Location = new Point(127, 221);
            ModeltextBox.Name = "ModeltextBox";
            ModeltextBox.Size = new Size(109, 23);
            ModeltextBox.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(364, 203);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 39;
            label12.Text = "Год выпуска авто";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(264, 203);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 40;
            label13.Text = "Гос. номер";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(161, 203);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 41;
            label14.Text = "Модель";
            // 
            // Марка
            // 
            Марка.AutoSize = true;
            Марка.Location = new Point(40, 203);
            Марка.Name = "Марка";
            Марка.Size = new Size(43, 15);
            Марка.TabIndex = 42;
            Марка.Text = "Марка";
            // 
            // AddCar
            // 
            AddCar.Location = new Point(663, 309);
            AddCar.Name = "AddCar";
            AddCar.Size = new Size(75, 23);
            AddCar.TabIndex = 43;
            AddCar.Text = "добавить";
            AddCar.UseVisualStyleBackColor = true;
            AddCar.Click += AddCar_Click;
            // 
            // EditCar
            // 
            EditCar.Location = new Point(744, 309);
            EditCar.Name = "EditCar";
            EditCar.Size = new Size(75, 23);
            EditCar.TabIndex = 44;
            EditCar.Text = "изменить";
            EditCar.UseVisualStyleBackColor = true;
            EditCar.Click += EditCar_Click;
            // 
            // DeleteCar
            // 
            DeleteCar.Location = new Point(825, 309);
            DeleteCar.Name = "DeleteCar";
            DeleteCar.Size = new Size(75, 23);
            DeleteCar.TabIndex = 45;
            DeleteCar.Text = "удалить";
            DeleteCar.UseVisualStyleBackColor = true;
            DeleteCar.Click += DeleteCar_Click;
            // 
            // Obnovedriv
            // 
            Obnovedriv.Location = new Point(906, 145);
            Obnovedriv.Name = "Obnovedriv";
            Obnovedriv.Size = new Size(75, 23);
            Obnovedriv.TabIndex = 46;
            Obnovedriv.Text = "Обновить";
            Obnovedriv.UseVisualStyleBackColor = true;
            Obnovedriv.Click += Obnovedriv_Click;
            // 
            // ObnoveAuto
            // 
            ObnoveAuto.Location = new Point(906, 309);
            ObnoveAuto.Name = "ObnoveAuto";
            ObnoveAuto.Size = new Size(75, 23);
            ObnoveAuto.TabIndex = 47;
            ObnoveAuto.Text = "Обновить";
            ObnoveAuto.UseVisualStyleBackColor = true;
            ObnoveAuto.Click += ObnoveAuto_Click;
            // 
            // Addpolice
            // 
            Addpolice.Location = new Point(663, 460);
            Addpolice.Name = "Addpolice";
            Addpolice.Size = new Size(75, 23);
            Addpolice.TabIndex = 48;
            Addpolice.Text = "добавить";
            Addpolice.UseVisualStyleBackColor = true;
            Addpolice.Click += Addpolice_Click;
            // 
            // EditPolice
            // 
            EditPolice.Location = new Point(744, 461);
            EditPolice.Name = "EditPolice";
            EditPolice.Size = new Size(75, 23);
            EditPolice.TabIndex = 49;
            EditPolice.Text = "изменить";
            EditPolice.UseVisualStyleBackColor = true;
            EditPolice.Click += EditPolice_Click;
            // 
            // DeletePolice
            // 
            DeletePolice.Location = new Point(825, 461);
            DeletePolice.Name = "DeletePolice";
            DeletePolice.Size = new Size(75, 23);
            DeletePolice.TabIndex = 50;
            DeletePolice.Text = "удалить";
            DeletePolice.UseVisualStyleBackColor = true;
            DeletePolice.Click += DeletePolice_Click;
            // 
            // ObnovePolice
            // 
            ObnovePolice.Location = new Point(906, 461);
            ObnovePolice.Name = "ObnovePolice";
            ObnovePolice.Size = new Size(75, 23);
            ObnovePolice.TabIndex = 51;
            ObnovePolice.Text = "Обновить";
            ObnovePolice.UseVisualStyleBackColor = true;
            ObnovePolice.Click += ObnovePolice_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(123, 441);
            label11.Name = "label11";
            label11.Size = new Size(90, 15);
            label11.TabIndex = 69;
            label11.Text = "Дата рождения";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(373, 396);
            label15.Name = "label15";
            label15.Size = new Size(46, 15);
            label15.TabIndex = 68;
            label15.Text = "Звание";
            // 
            // positionTextBox
            // 
            positionTextBox.Location = new Point(233, 414);
            positionTextBox.Name = "positionTextBox";
            positionTextBox.Size = new Size(101, 23);
            positionTextBox.TabIndex = 67;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(244, 396);
            label16.Name = "label16";
            label16.Size = new Size(69, 15);
            label16.TabIndex = 66;
            label16.Text = "Должность";
            // 
            // addrTextBox
            // 
            addrTextBox.Location = new Point(119, 414);
            addrTextBox.Name = "addrTextBox";
            addrTextBox.Size = new Size(100, 23);
            addrTextBox.TabIndex = 65;
            // 
            // labek
            // 
            labek.AutoSize = true;
            labek.Location = new Point(150, 396);
            labek.Name = "labek";
            labek.Size = new Size(40, 15);
            labek.TabIndex = 64;
            labek.Text = "Адрес";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(27, 396);
            label18.Name = "label18";
            label18.Size = new Size(55, 15);
            label18.TabIndex = 63;
            label18.Text = "Телефон";
            // 
            // protophonTextBox
            // 
            protophonTextBox.Location = new Point(13, 414);
            protophonTextBox.Name = "protophonTextBox";
            protophonTextBox.Size = new Size(100, 23);
            protophonTextBox.TabIndex = 62;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(365, 352);
            label.Name = "label";
            label.Size = new Size(54, 15);
            label.TabIndex = 61;
            label.Text = "Паспорт";
            // 
            // passportTextBox
            // 
            passportTextBox.Location = new Point(350, 370);
            passportTextBox.Name = "passportTextBox";
            passportTextBox.Size = new Size(100, 23);
            passportTextBox.TabIndex = 60;
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.Location = new Point(255, 352);
            lab.Name = "lab";
            lab.Size = new Size(58, 15);
            lab.TabIndex = 59;
            lab.Text = "Отчество";
            // 
            // miNameTextBox
            // 
            miNameTextBox.Location = new Point(234, 370);
            miNameTextBox.Name = "miNameTextBox";
            miNameTextBox.Size = new Size(100, 23);
            miNameTextBox.TabIndex = 58;
            // 
            // fiNameTextBox
            // 
            fiNameTextBox.Location = new Point(128, 370);
            fiNameTextBox.Name = "fiNameTextBox";
            fiNameTextBox.Size = new Size(100, 23);
            fiNameTextBox.TabIndex = 57;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(162, 352);
            label21.Name = "label21";
            label21.Size = new Size(31, 15);
            label21.TabIndex = 56;
            label21.Text = "Имя";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(27, 352);
            label22.Name = "label22";
            label22.Size = new Size(58, 15);
            label22.TabIndex = 55;
            label22.Text = "Фамилия";
            // 
            // DateOfBirthPicker
            // 
            DateOfBirthPicker.Location = new Point(58, 459);
            DateOfBirthPicker.Name = "DateOfBirthPicker";
            DateOfBirthPicker.Size = new Size(224, 23);
            DateOfBirthPicker.TabIndex = 54;
            // 
            // rankTextBox
            // 
            rankTextBox.Location = new Point(350, 414);
            rankTextBox.Name = "rankTextBox";
            rankTextBox.Size = new Size(109, 23);
            rankTextBox.TabIndex = 53;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(13, 370);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(109, 23);
            lastNameTextBox.TabIndex = 52;
            lastNameTextBox.Text = " ";
            // 
            // ObnoveViol
            // 
            ObnoveViol.Location = new Point(906, 610);
            ObnoveViol.Name = "ObnoveViol";
            ObnoveViol.Size = new Size(75, 23);
            ObnoveViol.TabIndex = 74;
            ObnoveViol.Text = "Обновить";
            ObnoveViol.UseVisualStyleBackColor = true;
            ObnoveViol.Click += ObnoveViol_Click;
            // 
            // DelViol
            // 
            DelViol.Location = new Point(825, 610);
            DelViol.Name = "DelViol";
            DelViol.Size = new Size(75, 23);
            DelViol.TabIndex = 73;
            DelViol.Text = "удалить";
            DelViol.UseVisualStyleBackColor = true;
            DelViol.Click += DelViol_Click;
            // 
            // button4
            // 
            button4.Location = new Point(744, 610);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 72;
            button4.Text = "изменить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(663, 610);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 71;
            button5.Text = "добавить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // SearchViol
            // 
            SearchViol.Location = new Point(516, 601);
            SearchViol.Name = "SearchViol";
            SearchViol.Size = new Size(122, 41);
            SearchViol.TabIndex = 70;
            SearchViol.Text = "Поиск нарушения";
            SearchViol.UseVisualStyleBackColor = true;
            SearchViol.Click += SearchViol_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(321, 539);
            label17.Name = "label17";
            label17.Size = new Size(98, 15);
            label17.TabIndex = 88;
            label17.Text = "Дата нарушения";
            // 
            // Info
            // 
            Info.Location = new Point(162, 557);
            Info.Name = "Info";
            Info.Size = new Size(100, 23);
            Info.TabIndex = 85;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(161, 539);
            label20.Name = "label20";
            label20.Size = new Size(107, 15);
            label20.TabIndex = 84;
            label20.Text = "Краткое описание";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(77, 539);
            label23.Name = "label23";
            label23.Size = new Size(45, 15);
            label23.TabIndex = 83;
            label23.Text = "Штраф";
            // 
            // Fine
            // 
            Fine.Location = new Point(56, 557);
            Fine.Name = "Fine";
            Fine.Size = new Size(100, 23);
            Fine.TabIndex = 82;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(288, 495);
            label24.Name = "label24";
            label24.Size = new Size(68, 15);
            label24.TabIndex = 81;
            label24.Text = "Гос. номер";
            // 
            // Licenseplate
            // 
            Licenseplate.Location = new Point(277, 513);
            Licenseplate.Name = "Licenseplate";
            Licenseplate.Size = new Size(100, 23);
            Licenseplate.TabIndex = 80;
            // 
            // Description
            // 
            Description.Location = new Point(171, 513);
            Description.Name = "Description";
            Description.Size = new Size(100, 23);
            Description.TabIndex = 79;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(183, 495);
            label25.Name = "label25";
            label25.Size = new Size(72, 15);
            label25.TabIndex = 78;
            label25.Text = "Нарушение";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(56, 495);
            label26.Name = "label26";
            label26.Size = new Size(107, 15);
            label26.TabIndex = 77;
            label26.Text = "Номер протокола";
            // 
            // VioldateTimePicker
            // 
            VioldateTimePicker.Location = new Point(268, 557);
            VioldateTimePicker.Name = "VioldateTimePicker";
            VioldateTimePicker.Size = new Size(224, 23);
            VioldateTimePicker.TabIndex = 76;
            // 
            // ProtocolNumber
            // 
            ProtocolNumber.Location = new Point(56, 513);
            ProtocolNumber.Name = "ProtocolNumber";
            ProtocolNumber.Size = new Size(109, 23);
            ProtocolNumber.TabIndex = 75;
            ProtocolNumber.Text = " ";
            // 
            // issuedProtocolsTextBox
            // 
            issuedProtocolsTextBox.Location = new Point(288, 460);
            issuedProtocolsTextBox.Name = "issuedProtocolsTextBox";
            issuedProtocolsTextBox.Size = new Size(162, 23);
            issuedProtocolsTextBox.TabIndex = 89;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(297, 442);
            label19.Name = "label19";
            label19.Size = new Size(143, 15);
            label19.TabIndex = 90;
            label19.Text = "Выписанные протоколы";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1310, 669);
            Controls.Add(label19);
            Controls.Add(issuedProtocolsTextBox);
            Controls.Add(label17);
            Controls.Add(Info);
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
            Controls.Add(ObnoveViol);
            Controls.Add(DelViol);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(SearchViol);
            Controls.Add(label11);
            Controls.Add(label15);
            Controls.Add(positionTextBox);
            Controls.Add(label16);
            Controls.Add(addrTextBox);
            Controls.Add(labek);
            Controls.Add(label18);
            Controls.Add(protophonTextBox);
            Controls.Add(label);
            Controls.Add(passportTextBox);
            Controls.Add(lab);
            Controls.Add(miNameTextBox);
            Controls.Add(fiNameTextBox);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(DateOfBirthPicker);
            Controls.Add(rankTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(ObnovePolice);
            Controls.Add(DeletePolice);
            Controls.Add(EditPolice);
            Controls.Add(Addpolice);
            Controls.Add(ObnoveAuto);
            Controls.Add(Obnovedriv);
            Controls.Add(DeleteCar);
            Controls.Add(EditCar);
            Controls.Add(AddCar);
            Controls.Add(Марка);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(ModeltextBox);
            Controls.Add(PlatetextBox);
            Controls.Add(yeartextBox);
            Controls.Add(STStextBox);
            Controls.Add(label10);
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
            Controls.Add(Deletedriver);
            Controls.Add(Editdriver);
            Controls.Add(Adddriver);
            Controls.Add(driverDateOfBirthPicker);
            Controls.Add(driverLicenseTextBox);
            Controls.Add(button3);
            Controls.Add(MakeTextBox);
            Controls.Add(SearchPolice);
            Controls.Add(PolicemanDataGridView);
            Controls.Add(AutoDataGridView);
            Controls.Add(violationsDataGridView);
            Controls.Add(searchdriver);
            Controls.Add(SurnameTextBox);
            Controls.Add(driversDataGridView);
            Name = "Form1";
            Text = "АИС ГАИ (Администратор)";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)driversDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)violationsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PolicemanDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView driversDataGridView;
        private TextBox SurnameTextBox;
        private Button searchdriver;
        private DataGridView violationsDataGridView;
        private DataGridView AutoDataGridView;
        private DataGridView PolicemanDataGridView;
        private Button SearchPolice;
        private TextBox MakeTextBox;
        private Button button3;
        private TextBox driverLicenseTextBox;
        private DateTimePicker driverDateOfBirthPicker;
        private Button Adddriver;
        private Button Editdriver;
        private Button Deletedriver;
        private Label label1;
        private Label label2;
        private TextBox firstnametextbox;
        private TextBox middlenametextbox;
        private Label label3;
        private TextBox passportnumbertextbox;
        private Label label4;
        private TextBox phonetextbox;
        private Label label5;
        private Label label6;
        private TextBox addresstextbox;
        private Label label7;
        private TextBox certificateofregistrationtextbox;
        private Label label8;
        private Label label9;
        private TextBox STStextBox;
        private Label label10;
        private TextBox yeartextBox;
        private TextBox PlatetextBox;
        private TextBox ModeltextBox;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label Марка;
        private Button AddCar;
        private Button EditCar;
        private Button DeleteCar;
        private Button Obnovedriv;
        private Button ObnoveAuto;
        private Button Addpolice;
        private Button EditPolice;
        private Button DeletePolice;
        private Button ObnovePolice;
        private Label label11;
        private Label label15;
        private TextBox positionTextBox;
        private Label label16;
        private TextBox addrTextBox;
        private Label labek;
        private Label label18;
        private TextBox protophonTextBox;
        private Label label;
        private TextBox passportTextBox;
        private Label lab;
        private TextBox miNameTextBox;
        private TextBox fiNameTextBox;
        private Label label21;
        private Label label22;
        private DateTimePicker DateOfBirthPicker;
        private TextBox rankTextBox;
        private TextBox lastNameTextBox;
        private Button ObnoveViol;
        private Button DelViol;
        private Button button4;
        private Button button5;
        private Button SearchViol;
        private Label label17;
        private TextBox Info;
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
        private TextBox issuedProtocolsTextBox;
        private Label label19;
    }
}