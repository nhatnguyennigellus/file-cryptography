namespace AdvancedFileEncryption
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBirthdate = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.txtCfmPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdatePass = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRepPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnExecEncr = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbBlockEncr = new System.Windows.Forms.ComboBox();
            this.cbPaddingEncr = new System.Windows.Forms.ComboBox();
            this.cbModeEncr = new System.Windows.Forms.ComboBox();
            this.cbKeySizeEncr = new System.Windows.Forms.ComboBox();
            this.cbAlgorithmEncr = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKeyGen = new System.Windows.Forms.Button();
            this.chkShowKey = new System.Windows.Forms.CheckBox();
            this.lbKeySizeEncr = new System.Windows.Forms.Label();
            this.lbIVSizeEncr = new System.Windows.Forms.Label();
            this.txtKeyEncr = new System.Windows.Forms.TextBox();
            this.txtIVEncr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutputEncr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChooseFileEncr = new System.Windows.Forms.Button();
            this.txtInputEncr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keypairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importKeyInfoDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtOutputDecr = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnChooseFileDecr = new System.Windows.Forms.Button();
            this.txtInputDecr = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExecDecrypt = new System.Windows.Forms.Button();
            this.txtPassDecr = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBirthdate);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.txtFullname);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Account";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBirthdate
            // 
            this.txtBirthdate.Location = new System.Drawing.Point(153, 172);
            this.txtBirthdate.Name = "txtBirthdate";
            this.txtBirthdate.Size = new System.Drawing.Size(200, 20);
            this.txtBirthdate.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(153, 131);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(160, 20);
            this.txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(153, 87);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(160, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(153, 43);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(129, 20);
            this.txtFullname.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnUpdateProfile);
            this.panel1.Controls.Add(this.txtCfmPass);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(6, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 84);
            this.panel1.TabIndex = 1;
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(252, 44);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateProfile.TabIndex = 1;
            this.btnUpdateProfile.Text = "Update";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // txtCfmPass
            // 
            this.txtCfmPass.Location = new System.Drawing.Point(242, 14);
            this.txtCfmPass.Name = "txtCfmPass";
            this.txtCfmPass.PasswordChar = '*';
            this.txtCfmPass.Size = new System.Drawing.Size(156, 20);
            this.txtCfmPass.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Enter passphrase to edit profile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Birthdate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fullname";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnUpdatePass);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtRepPass);
            this.tabPage2.Controls.Add(this.txtNewPass);
            this.tabPage2.Controls.Add(this.txtOldPass);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Change Passphrase";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.Location = new System.Drawing.Point(189, 194);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePass.TabIndex = 3;
            this.btnUpdatePass.Text = "Update";
            this.btnUpdatePass.UseVisualStyleBackColor = true;
            this.btnUpdatePass.Click += new System.EventHandler(this.btnUpdatePass_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Repeat Passphrase";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "New Passphrase";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Old Passphrase";
            // 
            // txtRepPass
            // 
            this.txtRepPass.Location = new System.Drawing.Point(213, 118);
            this.txtRepPass.Name = "txtRepPass";
            this.txtRepPass.PasswordChar = '*';
            this.txtRepPass.Size = new System.Drawing.Size(142, 20);
            this.txtRepPass.TabIndex = 2;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(213, 81);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(142, 20);
            this.txtNewPass.TabIndex = 1;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(213, 45);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(142, 20);
            this.txtOldPass.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.btnExecEncr);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(534, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Encryption";
            // 
            // btnExecEncr
            // 
            this.btnExecEncr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecEncr.Location = new System.Drawing.Point(195, 363);
            this.btnExecEncr.Name = "btnExecEncr";
            this.btnExecEncr.Size = new System.Drawing.Size(147, 23);
            this.btnExecEncr.TabIndex = 6;
            this.btnExecEncr.Text = "Encrypt!";
            this.btnExecEncr.UseVisualStyleBackColor = true;
            this.btnExecEncr.Click += new System.EventHandler(this.btnExecEncr_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbBlockEncr);
            this.groupBox3.Controls.Add(this.cbPaddingEncr);
            this.groupBox3.Controls.Add(this.cbModeEncr);
            this.groupBox3.Controls.Add(this.cbKeySizeEncr);
            this.groupBox3.Controls.Add(this.cbAlgorithmEncr);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(6, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 114);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algorithm and figures";
            // 
            // cbBlockEncr
            // 
            this.cbBlockEncr.FormattingEnabled = true;
            this.cbBlockEncr.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.cbBlockEncr.Location = new System.Drawing.Point(356, 76);
            this.cbBlockEncr.Name = "cbBlockEncr";
            this.cbBlockEncr.Size = new System.Drawing.Size(121, 21);
            this.cbBlockEncr.TabIndex = 1;
            this.cbBlockEncr.SelectedIndexChanged += new System.EventHandler(this.cbBlockEncr_SelectedIndexChanged);
            // 
            // cbPaddingEncr
            // 
            this.cbPaddingEncr.FormattingEnabled = true;
            this.cbPaddingEncr.Items.AddRange(new object[] {
            "PKCS7",
            "ANSIX923",
            "ISO10126",
            "Zeros"});
            this.cbPaddingEncr.Location = new System.Drawing.Point(356, 50);
            this.cbPaddingEncr.Name = "cbPaddingEncr";
            this.cbPaddingEncr.Size = new System.Drawing.Size(121, 21);
            this.cbPaddingEncr.TabIndex = 1;
            // 
            // cbModeEncr
            // 
            this.cbModeEncr.FormattingEnabled = true;
            this.cbModeEncr.Items.AddRange(new object[] {
            "CBC",
            "CFB",
            "ECB",
            "OFB",
            "CTS"});
            this.cbModeEncr.Location = new System.Drawing.Point(356, 23);
            this.cbModeEncr.Name = "cbModeEncr";
            this.cbModeEncr.Size = new System.Drawing.Size(121, 21);
            this.cbModeEncr.TabIndex = 1;
            this.cbModeEncr.SelectedIndexChanged += new System.EventHandler(this.cbModeEncr_SelectedIndexChanged);
            // 
            // cbKeySizeEncr
            // 
            this.cbKeySizeEncr.FormattingEnabled = true;
            this.cbKeySizeEncr.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.cbKeySizeEncr.Location = new System.Drawing.Point(108, 50);
            this.cbKeySizeEncr.Name = "cbKeySizeEncr";
            this.cbKeySizeEncr.Size = new System.Drawing.Size(121, 21);
            this.cbKeySizeEncr.TabIndex = 1;
            this.cbKeySizeEncr.SelectedIndexChanged += new System.EventHandler(this.cbKeySizeEncr_SelectedIndexChanged);
            // 
            // cbAlgorithmEncr
            // 
            this.cbAlgorithmEncr.FormattingEnabled = true;
            this.cbAlgorithmEncr.Items.AddRange(new object[] {
            "Rijndael",
            "AES",
            "DES",
            "TripleDES",
            "RC2"});
            this.cbAlgorithmEncr.Location = new System.Drawing.Point(108, 23);
            this.cbAlgorithmEncr.Name = "cbAlgorithmEncr";
            this.cbAlgorithmEncr.Size = new System.Drawing.Size(121, 21);
            this.cbAlgorithmEncr.TabIndex = 1;
            this.cbAlgorithmEncr.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithmEncr_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(257, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Block size";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(257, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Padding";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(257, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Mode of operation";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Key size";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Algorithm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKeyGen);
            this.groupBox2.Controls.Add(this.chkShowKey);
            this.groupBox2.Controls.Add(this.lbKeySizeEncr);
            this.groupBox2.Controls.Add(this.lbIVSizeEncr);
            this.groupBox2.Controls.Add(this.txtKeyEncr);
            this.groupBox2.Controls.Add(this.txtIVEncr);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(6, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Secret Key";
            // 
            // btnKeyGen
            // 
            this.btnKeyGen.Location = new System.Drawing.Point(378, 58);
            this.btnKeyGen.Name = "btnKeyGen";
            this.btnKeyGen.Size = new System.Drawing.Size(99, 23);
            this.btnKeyGen.TabIndex = 4;
            this.btnKeyGen.Text = "Generate ";
            this.btnKeyGen.UseVisualStyleBackColor = true;
            this.btnKeyGen.Click += new System.EventHandler(this.btnKeyGen_Click);
            // 
            // chkShowKey
            // 
            this.chkShowKey.AutoSize = true;
            this.chkShowKey.Checked = true;
            this.chkShowKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowKey.Location = new System.Drawing.Point(108, 94);
            this.chkShowKey.Name = "chkShowKey";
            this.chkShowKey.Size = new System.Drawing.Size(80, 17);
            this.chkShowKey.TabIndex = 3;
            this.chkShowKey.Text = "Show Key?";
            this.chkShowKey.UseVisualStyleBackColor = true;
            this.chkShowKey.CheckedChanged += new System.EventHandler(this.chkShowKey_CheckedChanged);
            // 
            // lbKeySizeEncr
            // 
            this.lbKeySizeEncr.AutoSize = true;
            this.lbKeySizeEncr.Location = new System.Drawing.Point(275, 63);
            this.lbKeySizeEncr.Name = "lbKeySizeEncr";
            this.lbKeySizeEncr.Size = new System.Drawing.Size(46, 13);
            this.lbKeySizeEncr.TabIndex = 2;
            this.lbKeySizeEncr.Text = "Length: ";
            // 
            // lbIVSizeEncr
            // 
            this.lbIVSizeEncr.AutoSize = true;
            this.lbIVSizeEncr.Location = new System.Drawing.Point(275, 32);
            this.lbIVSizeEncr.Name = "lbIVSizeEncr";
            this.lbIVSizeEncr.Size = new System.Drawing.Size(46, 13);
            this.lbIVSizeEncr.TabIndex = 2;
            this.lbIVSizeEncr.Text = "Length: ";
            // 
            // txtKeyEncr
            // 
            this.txtKeyEncr.Location = new System.Drawing.Point(109, 60);
            this.txtKeyEncr.Name = "txtKeyEncr";
            this.txtKeyEncr.ReadOnly = true;
            this.txtKeyEncr.Size = new System.Drawing.Size(160, 20);
            this.txtKeyEncr.TabIndex = 1;
            this.txtKeyEncr.TextChanged += new System.EventHandler(this.txtKeyEncr_TextChanged);
            // 
            // txtIVEncr
            // 
            this.txtIVEncr.Location = new System.Drawing.Point(109, 29);
            this.txtIVEncr.Name = "txtIVEncr";
            this.txtIVEncr.ReadOnly = true;
            this.txtIVEncr.Size = new System.Drawing.Size(160, 20);
            this.txtIVEncr.TabIndex = 1;
            this.txtIVEncr.TextChanged += new System.EventHandler(this.txtIVEncr_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Secret key Ks";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "IV Vector";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutputEncr);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnChooseFileEncr);
            this.groupBox1.Controls.Add(this.txtInputEncr);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // txtOutputEncr
            // 
            this.txtOutputEncr.Location = new System.Drawing.Point(127, 59);
            this.txtOutputEncr.Name = "txtOutputEncr";
            this.txtOutputEncr.ReadOnly = true;
            this.txtOutputEncr.Size = new System.Drawing.Size(326, 20);
            this.txtOutputEncr.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Output file";
            // 
            // btnChooseFileEncr
            // 
            this.btnChooseFileEncr.Location = new System.Drawing.Point(33, 22);
            this.btnChooseFileEncr.Name = "btnChooseFileEncr";
            this.btnChooseFileEncr.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFileEncr.TabIndex = 0;
            this.btnChooseFileEncr.Text = "Choose file";
            this.btnChooseFileEncr.UseVisualStyleBackColor = true;
            this.btnChooseFileEncr.Click += new System.EventHandler(this.btnChooseFileEncr_Click);
            // 
            // txtInputEncr
            // 
            this.txtInputEncr.Location = new System.Drawing.Point(127, 24);
            this.txtInputEncr.Name = "txtInputEncr";
            this.txtInputEncr.ReadOnly = true;
            this.txtInputEncr.Size = new System.Drawing.Size(292, 20);
            this.txtInputEncr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.keypairToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // keypairToolStripMenuItem
            // 
            this.keypairToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.keypairToolStripMenuItem.Name = "keypairToolStripMenuItem";
            this.keypairToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.keypairToolStripMenuItem.Text = "Key-pair";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // importKeyInfoDialog1
            // 
            this.importKeyInfoDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(534, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Decryption";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtOutputDecr);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.btnChooseFileDecr);
            this.groupBox6.Controls.Add(this.txtInputDecr);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(520, 100);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "File";
            // 
            // txtOutputDecr
            // 
            this.txtOutputDecr.Location = new System.Drawing.Point(127, 59);
            this.txtOutputDecr.Name = "txtOutputDecr";
            this.txtOutputDecr.ReadOnly = true;
            this.txtOutputDecr.Size = new System.Drawing.Size(326, 20);
            this.txtOutputDecr.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(53, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "Output file";
            // 
            // btnChooseFileDecr
            // 
            this.btnChooseFileDecr.Location = new System.Drawing.Point(33, 22);
            this.btnChooseFileDecr.Name = "btnChooseFileDecr";
            this.btnChooseFileDecr.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFileDecr.TabIndex = 0;
            this.btnChooseFileDecr.Text = "Choose file";
            this.btnChooseFileDecr.UseVisualStyleBackColor = true;
            this.btnChooseFileDecr.Click += new System.EventHandler(this.btnChooseFileDecr_Click);
            // 
            // txtInputDecr
            // 
            this.txtInputDecr.Location = new System.Drawing.Point(127, 24);
            this.txtInputDecr.Name = "txtInputDecr";
            this.txtInputDecr.ReadOnly = true;
            this.txtInputDecr.Size = new System.Drawing.Size(292, 20);
            this.txtInputDecr.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btnExecDecrypt);
            this.panel3.Controls.Add(this.txtPassDecr);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Location = new System.Drawing.Point(6, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 84);
            this.panel3.TabIndex = 8;
            // 
            // btnExecDecrypt
            // 
            this.btnExecDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecDecrypt.Location = new System.Drawing.Point(365, 27);
            this.btnExecDecrypt.Name = "btnExecDecrypt";
            this.btnExecDecrypt.Size = new System.Drawing.Size(121, 23);
            this.btnExecDecrypt.TabIndex = 1;
            this.btnExecDecrypt.Text = "Decrypt!";
            this.btnExecDecrypt.UseVisualStyleBackColor = true;
            this.btnExecDecrypt.Click += new System.EventHandler(this.btnExecDecrypt_Click);
            // 
            // txtPassDecr
            // 
            this.txtPassDecr.Location = new System.Drawing.Point(175, 29);
            this.txtPassDecr.Name = "txtPassDecr";
            this.txtPassDecr.PasswordChar = '*';
            this.txtPassDecr.Size = new System.Drawing.Size(156, 20);
            this.txtPassDecr.TabIndex = 0;
            this.txtPassDecr.Text = "nigel4492";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(30, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Enter passphrase to decrypt";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.TextBox txtCfmPass;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRepPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Button btnUpdatePass;
        private System.Windows.Forms.DateTimePicker txtBirthdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keypairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog importKeyInfoDialog1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtInputEncr;
        private System.Windows.Forms.Button btnChooseFileEncr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOutputEncr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExecEncr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKeyEncr;
        private System.Windows.Forms.TextBox txtIVEncr;
        private System.Windows.Forms.Label lbKeySizeEncr;
        private System.Windows.Forms.Label lbIVSizeEncr;
        private System.Windows.Forms.CheckBox chkShowKey;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbBlockEncr;
        private System.Windows.Forms.ComboBox cbPaddingEncr;
        private System.Windows.Forms.ComboBox cbModeEncr;
        private System.Windows.Forms.ComboBox cbKeySizeEncr;
        private System.Windows.Forms.ComboBox cbAlgorithmEncr;
        private System.Windows.Forms.Button btnKeyGen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtOutputDecr;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnChooseFileDecr;
        private System.Windows.Forms.TextBox txtInputDecr;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExecDecrypt;
        private System.Windows.Forms.TextBox txtPassDecr;
        private System.Windows.Forms.Label label20;
    }
}