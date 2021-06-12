using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppTemplate
{
    public partial class DICTForm : Form
    {
        public DICTForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if studentnumber and password is matched then display success
            var defaultStudNumber = "2011-00066-BN-0";
            var defaultPassword = "admin";

            var userInputStudNumber = txtStudentNumber.Text;
            var userInputPassword = txtPassword.Text;

            var msgBoxResult = MessageBox.Show("do you want to login?", this.Text, MessageBoxButtons.YesNo);

            if ((msgBoxResult == DialogResult.Yes) &&
                (userInputStudNumber == defaultStudNumber &&
                userInputPassword == defaultPassword))
            {
                MessageBox.Show("Success!", this.Text);
                var mainForm = new frmMain();
                mainForm.Show();
                txtPassword.Text = "";
                txtStudentNumber.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed!", this.Text);
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void DICTForm_Load(object sender, EventArgs e)
        {

        }

        private void DICTForm_Shown(object sender, EventArgs e)
        {

        }
    }
}
