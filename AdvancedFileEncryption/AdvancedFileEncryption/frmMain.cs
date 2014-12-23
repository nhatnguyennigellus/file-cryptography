using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedFileEncryption
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        UserAccount acc = new UserAccount();
        Form1 frmLogin;
        MyCryptography crypto = new MyCryptography();
        DigitalSignature digiSign = new DigitalSignature();

        public frmMain(UserAccount account, Form1 frm)
        {
            this.acc = account;
            InitializeComponent();
            fillFields();
            frmLogin = frm;
            frmLogin.Hide();

            saveFileDialog1.Filter = "All file | *.*";

            cbAlgorithmEncr.SelectedIndex = 0;
            cbModeEncr.SelectedIndex = 0;
            cbPaddingEncr.SelectedIndex = 0;
            addEmailListToCb();
        }

        private void addEmailListToCb()
        {
            foreach (string email in acc.getEmailList())
            {
                cbEmailList.Items.Add(email);
            }
            cbEmailList.SelectedIndex = 0;
        }

        private void fillFields()
        {
            label1.Text = acc.Fullname;

            txtFullname.Text = acc.Fullname;
            txtPhone.Text = acc.Phone;
            txtAddress.Text = acc.Address;
            txtBirthdate.Value = DateTime.Parse(acc.Birthdate);
        }

        void addItemsToComboBox(ComboBox cb, KeySizes[] ks)
        {
            cb.Items.Clear();
            foreach (KeySizes k in ks)
            {
                int tmp = k.MinSize;
                cb.Items.Add(tmp);
                if (k.SkipSize == 0) continue;
                tmp += k.SkipSize;
                while (tmp <= k.MaxSize)
                {
                    cb.Items.Add(tmp);
                    tmp += k.SkipSize;
                }
            }
            cb.SelectedIndex = 0;
        }

        byte[] getASCIIBytes(String inputString)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding ascii = Encoding.ASCII;

            byte[] unicodeBytes = unicode.GetBytes(inputString);
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                MessageBox.Show("Please enter your fullname!");
                txtFullname.Focus();
                return;
            }

            if (acc.isAuthenticated(acc.Email, txtCfmPass.Text))
            {
                UserAccount updateAcc = new UserAccount();
                updateAcc.Email = acc.Email;
                updateAcc.Fullname = txtFullname.Text;
                updateAcc.Address = txtAddress.Text;
                updateAcc.Phone = txtPhone.Text;
                updateAcc.Birthdate = txtBirthdate.Value.ToShortDateString();

                if (updateAcc.editProfile())
                {
                    acc = updateAcc;
                    MessageBox.Show("Successfully!");
                    fillFields();
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
            else
            {
                MessageBox.Show("Invalid passphrase! Update failed!", "Edit Profile",
                    MessageBoxButtons.OK , MessageBoxIcon.Error);
                txtCfmPass.Focus();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin.Show();
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "")
            {
                MessageBox.Show("Please enter your current passphrase!", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
                return;
            }

            if (txtOldPass.Text.Length < 6)
            {
                MessageBox.Show("Passphrase must be more than 6 characters!", "Edit Passphrase",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
                return;
            }

            if (txtNewPass.Text == "")
            {
                MessageBox.Show("Please enter your new passphrase!", "Edit Passphrase",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (txtNewPass.Text.Length < 6)
            {
                MessageBox.Show("Passphrase must be more than 6 characters!", "Edit Passphrase",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (txtRepPass.Text != txtNewPass.Text)
            {
                MessageBox.Show("Passphrases mismatch!", "Edit Passphrase",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (acc.isAuthenticated(acc.Email, txtOldPass.Text))
            {
                if (acc.changePassphrase(txtNewPass.Text, txtOldPass.Text))
                {
                    if(chkEnbGenPass.Checked)
                        acc.sendNewPassphraseViaEmail(txtNewPass.Text);
                    MessageBox.Show("Passphrase changed and sent successfully!", 
                        "Edit Profile",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Wrong passphrase!", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mes = "Đồ án Mã hóa thông tin và ứng dụng";
            mes += "\nNguyễn Minh Nhật - 1012278";
            mes += "\nTrần Trọng Nhân - 1012273";
            mes += "\nDecember 2014";

            MessageBox.Show(mes, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmVerify = new Form1(acc.Email);
            frmVerify.passControl = new Form1.PassControl(acc.exportKeyInfo);
            frmVerify.Show();
            
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importKeyInfoDialog1.Title = "Import key info";

            DialogResult dlgRes = importKeyInfoDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                if (acc.import(importKeyInfoDialog1.FileName))
                {
                    MessageBox.Show("Imported successfully!");
                    addEmailListToCb();
                }
                else
                {
                    MessageBox.Show("Import failed");
                }
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkZip_CheckedChanged(object sender, EventArgs e)
        {
            String inputPath = txtInputEncr.Text;
            String ext = Path.GetExtension(inputPath);
            if (!chkZip.Checked)
            {
                
                txtOutputEncr.Text = inputPath.Substring(0, inputPath.Length - ext.Length)
                        + "_encrypted" + ext + ".encrypted";
            }
            else
            {
                txtOutputEncr.Text = inputPath.Substring(0, inputPath.Length - ext.Length)
                    + "_encrypted" + ext + ".zip.encrypted";
            }
        }

        private void btnChooseFileEncr_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose file to encrypt";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                chkZip.Enabled = true;
                String inputPath = openFileDialog1.FileName;
                txtInputEncr.Text = inputPath;
                String ext = Path.GetExtension(inputPath);
                if (!chkZip.Checked) { 
                    txtOutputEncr.Text = inputPath.Substring(0, inputPath.Length - ext.Length) 
                        + "_encrypted" + ext + ".encrypted";
                }
                else
                {
                    txtOutputEncr.Text = inputPath.Substring(0, inputPath.Length - ext.Length)
                        + "_encrypted" + ext + ".zip.encrypted";
                }
            }
        }

        private void chkShowKey_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowKey.Checked)
            {
                txtKeyEncr.UseSystemPasswordChar = false;
            }
            else
            {
                txtKeyEncr.UseSystemPasswordChar = true;
            }
        }

        private void txtKeyEncr_TextChanged(object sender, EventArgs e)
        {
            lbKeySizeEncr.Text = "Length: " + txtKeyEncr.Text.Length;
        }

        private void cbModeEncr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string modeSelected = cbModeEncr.Text;
            if (modeSelected == "OFB" || modeSelected == "CTS")
            {
                MessageBox.Show("Mode" + modeSelected + " not yet supported!", 
                    "Mode of operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbModeEncr.SelectedIndex = 0;
            }
        }

        private void txtIVEncr_TextChanged(object sender, EventArgs e)
        {
            lbIVSizeEncr.Text = "Length: " + txtIVEncr.Text.Length;
        }

        private void cbAlgorithmEncr_SelectedIndexChanged(object sender, EventArgs e)
        {
            crypto.encryptAlg = crypto.encryptAlgs[cbAlgorithmEncr.SelectedIndex];
            addItemsToComboBox(cbBlockEncr, crypto.encryptAlg.LegalBlockSizes);
            addItemsToComboBox(cbKeySizeEncr, crypto.encryptAlg.LegalKeySizes);

           // txtKeyEncr.Text
            if (txtInputEncr.Text.Length > 0)
            {
                txtOutputEncr.Text = outputDecryptedName(txtInputEncr.Text);
            }
        }

        String outputDecryptedName(String inputFullPath)
        {
            String extension = Path.GetExtension(inputFullPath);
            return inputFullPath.Substring(0, inputFullPath.Length - extension.Length) 
                + "_encrypted" + extension + ".encrypted";
        }
        private void cbKeySizeEncr_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateKey();
            if (cbModeEncr.Text != "ECB")
            {
                generateIV();
            }
        }

        private void cbBlockEncr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModeEncr.Text != "ECB")
            {
                generateIV();
            }
        }

        private void btnKeyGen_Click(object sender, EventArgs e)
        {
            generateKey();
            if (cbModeEncr.Text != "ECB")
            { 
                generateIV(); 
            }
        }

        private void generateIV()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwvxyz0123456789";
            Random random = new Random();
            string iv = new string(
               Enumerable.Repeat(chars, int.Parse(cbBlockEncr.Text) / 8)
               .Select(s => s[random.Next(s.Length)])
               .ToArray());
            txtIVEncr.Text = iv;
        }
        private void generateKey()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwvxyz0123456789";
            Random random = new Random();
            string key = new string(
                Enumerable.Repeat(chars, int.Parse(cbKeySizeEncr.Text) / 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
           
            txtKeyEncr.Text = key;
            
        }


        
        private void btnExecEncr_Click(object sender, EventArgs e)
        {
            CipherMode mode = (CipherMode)Enum.Parse(typeof(CipherMode), cbModeEncr.Text);
            PaddingMode padding = (PaddingMode)Enum.Parse(typeof(PaddingMode), cbPaddingEncr.Text);
            int blockSize = int.Parse(cbBlockEncr.Text);
            int keySize = int.Parse(cbKeySizeEncr.Text);
            byte[] key = getASCIIBytes(txtKeyEncr.Text);
            
            string IV = txtIVEncr.Text;
            byte[] iv = null;
            if (mode != CipherMode.ECB)
            {
                iv = getASCIIBytes(IV);            
            }
            string inputFile = txtInputEncr.Text;
            if (!File.Exists(inputFile))
            {
                MessageBox.Show("Invalid file path or file does not exist!", "File encryption",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (chkZip.Checked)
            {
                crypto.ZipFileBeforeEncr(txtInputEncr.Text, txtInputEncr.Text + ".zip");
                inputFile = txtInputEncr.Text + ".zip";
            }
            byte[] plainData = File.ReadAllBytes(inputFile);
            byte[] encryptedByte = crypto.Encrypt(cbEmailList.Text, plainData, 
                key, iv, mode, padding, blockSize, keySize);
            if (encryptedByte == null)
            {
                MessageBox.Show("Encryption failed!", "File encryption",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.WriteAllBytes(txtOutputEncr.Text, encryptedByte);
                MessageBox.Show("File encrypted successfully!", "File encryption",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (acc.sendFileViaEmail(cbEmailList.Text, txtOutputEncr.Text))
                {
                    MessageBox.Show("File sent successfully!", "File encryption",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to send file!", "File encryption",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Encryption Error: " + err);
                throw;
            }
        }

        private void btnChooseFileDecr_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose file to decrypt";
            openFileDialog1.Filter = "Encrypted file (*.encrypted) | *.encrypted";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                String inputPath = openFileDialog1.FileName;
                txtInputDecr.Text = inputPath;
                String ext = Path.GetExtension(inputPath);
                txtOutputDecr.Text = inputPath.Substring(0, inputPath.Length - ext.Length);
                txtOutputDecr.Text = txtOutputDecr.Text.Replace("encrypted", "decrypted");
                if (txtOutputDecr.Text.Contains(".zip"))
                {
                    txtOutputDecr.Text = txtOutputDecr.Text.Replace(".zip", "");
                }
            }
        }

        private void btnExecDecrypt_Click(object sender, EventArgs e)
        {
            string inputFile = txtInputDecr.Text;
            if (!File.Exists(inputFile))
            {
                MessageBox.Show("Invalid file path or file does not exist!");
                return;

            }

            if (!acc.isAuthenticated(acc.Email, txtPassDecr.Text))
            {
                MessageBox.Show("Wrong passphrase!");
                txtPassDecr.Focus();
                return;
            }

            byte[] decryptData = crypto.Decrypt
                (txtInputDecr.Text, txtPassDecr.Text, acc.Email);
            if (decryptData == null)
            {
                MessageBox.Show("Decryption failed!");
                return;
            }
            try
            {
                if (txtInputDecr.Text.Contains(".zip") 
                    && txtInputDecr.Text.Contains("encrypted"))
                {
                    File.WriteAllBytes(txtOutputDecr.Text + ".zip", decryptData);
                    FileInfo info = new FileInfo(txtOutputDecr.Text + ".zip");
                    using (FileStream zipFile = info.OpenRead())
                    {
                        using (FileStream unzipFileStream = File.Create(txtOutputDecr.Text))
                        {
                            using (GZipStream unzipStream = new GZipStream(zipFile, CompressionMode.Decompress))
                            {
                                unzipStream.CopyTo(unzipFileStream);
                            }
                        }
                    }
                }
                else
                {
                    File.WriteAllBytes(txtOutputDecr.Text, decryptData);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurs while decrypting: " + error);
            }
            MessageBox.Show("Decrypted successfully!");
        }

        private void btnChooseFileSign_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose file to sign";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                string inputPath = openFileDialog1.FileName;
                txtInputSign.Text = inputPath;
                txtOutputSign.Text = inputPath + ".sig";
            }
        }

        private void btnExecSign_Click(object sender, EventArgs e)
        {
            if (txtInputSign.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to sign", "Sign to file",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!acc.isAuthenticated(acc.Email, txtPassSign.Text))
            {
                MessageBox.Show("Invalid Passphrase", "Sign to file",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassSign.Focus();
                return;
            }
            BackgroundWorker signWorker = new BackgroundWorker();
            signWorker.DoWork += new DoWorkEventHandler(digiSign.WorkerSign);
            signWorker.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(digiSign.WorkerSignComplete);
            object[] parameters =
                new object[] { txtInputSign.Text, txtOutputSign.Text,
                acc.Email, txtPassSign.Text};
            signWorker.RunWorkerAsync(parameters);
        }

        private void btnExecVerify_Click(object sender, EventArgs e)
        {
            if (txtInputVerify.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to sign", "Verify signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSignVerify.Text.Length == 0)
            {
                MessageBox.Show("Please select a signature file", "Verify signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BackgroundWorker verifyWorker = new BackgroundWorker();
            verifyWorker.DoWork += 
                new DoWorkEventHandler(digiSign.WorkerVerify);
            verifyWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(digiSign.WorkerVerifyComplete);
            object[] parameters = new object[] { txtInputVerify.Text, txtSignVerify.Text, acc.Email };
            verifyWorker.RunWorkerAsync(parameters);
        }

        private void btnInputSignVerify_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose file to verify signature";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                string inputPath = openFileDialog1.FileName;
                txtSignVerify.Text = inputPath;
                
            }
        }

        private void btnInputVerify_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose signature file";
            DialogResult dlgRes = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Signature File (*.sig) | *.sig";
            if (dlgRes == DialogResult.OK)
            {
                string inputPath = openFileDialog1.FileName;
                txtInputVerify.Text = inputPath;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cbPaddingEncr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenNewPass_Click(object sender, EventArgs e)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwvxyz0123456789";
            Random random = new Random();
            string pass = new string(
                Enumerable.Repeat(chars, 12)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            txtNewPass.Text = pass;
            txtRepPass.Text = pass;
        }

        private void chkEnbGenPass_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEnbGenPass.Checked)
            {
                txtNewPass.ReadOnly = false;
                txtRepPass.ReadOnly = false;
                btnGenNewPass.Enabled = false;
            }
            else
            {
                txtNewPass.ReadOnly = true;
                txtRepPass.ReadOnly = true;
                btnGenNewPass.Enabled = true;
            }
        }


    }
}
