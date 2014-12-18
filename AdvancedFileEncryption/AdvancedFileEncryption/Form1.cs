using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public delegate bool PassControl(string result, string email, string passphrase, string saveTo);

        public PassControl passControl;
        public Form1(string email)
        {
            InitializeComponent();
            btnToRegister.Text = "Cancel";
            txtEmail.Text = email;
            txtPass.Text = "";
            btnLogin.Text = "Export";
            exportKeyInfoDialog1.Filter = "XML Files (*.xml) | *.xml";
        }

        string saveTo = "";
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            UserAccount acc = new UserAccount();
            if (acc.isAuthenticated(txtEmail.Text, txtPass.Text))
            {
                if (btnLogin.Text == "Login")
                {
                    frmMain main = new frmMain(acc.getAccountByEmail(txtEmail.Text), this);
                    main.Show();
                }

                else if (btnLogin.Text == "Export")
                {
                    exportKeyInfoDialog1.Title = "Export keys info";
                    exportKeyInfoDialog1.FileName = txtEmail.Text.Substring(0,
                        txtEmail.Text.IndexOf('@')) + ".xml";
                    DialogResult dlgRes = exportKeyInfoDialog1.ShowDialog();
                    saveTo = exportKeyInfoDialog1.FileName;
                    if (dlgRes == DialogResult.OK)
                    {
                        if (passControl("OK", txtEmail.Text, txtPass.Text, saveTo))
                        {
                            MessageBox.Show("Exported successfully!",
                            "Export keys info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid email or passphrase!");
            } 
            
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            if (btnToRegister.Text == "Register")
            {
                frmRegister frm = new frmRegister(this);
                frm.Show(); 
            }
            else
            {
                passControl("Cancel", txtEmail.Text, txtPass.Text, saveTo);
                this.Close();
            }
        }
    }
}
