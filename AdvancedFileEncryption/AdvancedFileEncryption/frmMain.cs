using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public frmMain(UserAccount account, Form1 frm)
        {
            this.acc = account;
            InitializeComponent();
            fillFields();
            frmLogin = frm;
            frmLogin.Hide();
        }

        private void fillFields()
        {
            label1.Text = acc.Fullname;

            txtFullname.Text = acc.Fullname;
            txtPhone.Text = acc.Phone;
            txtAddress.Text = acc.Address;
            txtBirthdate.Value = DateTime.Parse(acc.Birthdate);
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
                MessageBox.Show("Invalid passphrase! Action failed!");
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
                MessageBox.Show("Please enter your current passphrase!");
                txtOldPass.Focus();
                return;
            }

            if (txtOldPass.Text.Length < 6)
            {
                MessageBox.Show("Passphrase must be more than 6 characters!");
                txtOldPass.Focus();
                return;
            }

            if (txtNewPass.Text == "")
            {
                MessageBox.Show("Please enter a new passphrase!");
                txtNewPass.Focus();
                return;
            }

            if (txtNewPass.Text.Length < 6)
            {
                MessageBox.Show("Passphrase must be more than 6 characters!");
                txtNewPass.Focus();
                return;
            }

            if (txtNewPass.Text != txtRepPass.Text)
            {
                MessageBox.Show("Passphrases mismatch!");
                txtRepPass.Focus();
                return;
            }

            if (acc.isAuthenticated(acc.Email, txtOldPass.Text))
            {
                if (acc.changePassphrase(txtNewPass.Text))
                {
                    MessageBox.Show("Passphrase changed successfully!");
                }

            }
            else
            {
                MessageBox.Show("Wrong password!");
            }
        }
    }
}
