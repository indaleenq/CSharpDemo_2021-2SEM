using PointsBusinessLogic;
using System;
using System.Windows.Forms;

namespace PointsFacultyView
{
    public partial class frmFacultyView : Form
    {
        User facultyUser;
        PointsWebService.PointsServiceSoapClient _pointsWebService = new PointsWebService.PointsServiceSoapClient();
        public frmFacultyView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            facultyUser = new User("ipquinsayas@pup.edu.ph", textBox1.Text.Trim());
            //if (facultyUser.Login())
            if (_pointsWebService.Login(facultyUser.UserId, facultyUser.EmailAddress))
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("You don't have access, sorry.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (PointsService.IfStudentExists(textBox2.Text.Trim()))
            if (_pointsWebService.IfStudentExists(textBox2.Text.Trim()))
            {
                MessageBox.Show("Student Exists.");
            }
            else
            {
                MessageBox.Show("Sorry. Student doesn't exist.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = _pointsWebService.AddPoints(facultyUser.UserRole.ToString(),
                textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text.Trim()));

            if (result)
            {
                MessageBox.Show("successfully added.");
            }
            else
            {
                MessageBox.Show("Failed to give points.");
            }
        }
    }
}
