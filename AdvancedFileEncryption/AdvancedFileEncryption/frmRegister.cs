using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedFileEncryption
{
    public partial class frmRegister : Form
    {
        Form1 frmLogin;
        public frmRegister(Form1 frm)
        {
            frmLogin = frm;
            InitializeComponent();
            frmLogin.Hide();

            for (int i = 512; i <= 1024; i += 64)
            {
                cbKeySize.Items.Add(i);
            }
            cbKeySize.SelectedIndex = 0;
        }

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "")
            {
                MessageBox.Show("Please enter an email!");
                txtEmail.Focus();
                return;
            }

            if(txtPass.Text == "")
            {
                MessageBox.Show("Please enter a passphrase!");
                txtPass.Focus();
                return;
            }

            if (txtPass.Text.Length < 6)
            {
                MessageBox.Show("Passphrase must be more than 6 characters!");
                txtPass.Focus();
                return;
            }

            if (txtPass.Text != txtRepPass.Text)
            {
                MessageBox.Show("Passphrases mismatch!");
                txtRepPass.Focus();
                return;
            }

            if (txtFullname.Text == "")
            {
                MessageBox.Show("Please enter your fullname!");
                txtFullname.Focus();
                return;
            }

            UserAccount acc = new UserAccount();
            if (acc.existedEmail(txtEmail.Text))
            {
                MessageBox.Show("This email already existed!");
                txtEmail.Focus();
                return;
            }
            string email = txtEmail.Text;
            string fullname = txtFullname.Text;
            string pass = txtPass.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string birthdate = txtDOB.Value.ToShortDateString();

            acc.Email = email;
            acc.Fullname = fullname;
            acc.Birthdate = birthdate;
            acc.Phone = phone;
            acc.Address = address;
            acc.Passphrase = pass;

            MessageBox.Show("Registered and generated key-pair successfully!");
            int keySize = Int32.Parse(cbKeySize.Text);

            RSACryptoServiceProvider generateAlg = new RSACryptoServiceProvider(keySize);

            RSAParameters publicKeyGen = generateAlg.ExportParameters(false);
            RSAParameters privateKeyGen = generateAlg.ExportParameters(true);
            /*
            MessageBox.Show("Public Key: " + BitConverter.ToString(publicKeyGen.Exponent)
                + "\nPrivate Key: " + BitConverter.ToString(privateKeyGen.D)
                + "\nN: " + BitConverter.ToString(privateKeyGen.Modulus)
                + "\nXML Public: " + generateAlg.ToXmlString(false));
            */
            acc.register(generateAlg.ToXmlString(false), generateAlg.ToXmlString(true));
            this.Close();
            frmLogin.Show();
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.Show();
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }
    }
}
