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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserAccount acc = new UserAccount();
            if (acc.isAuthenticated(txtEmail.Text, txtPass.Text))
            {   
                frmMain main = new frmMain(acc.getAccountByEmail(txtEmail.Text), this);
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or passphrase!");
            }
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister(this);
            frm.Show();
        }
    }
}
