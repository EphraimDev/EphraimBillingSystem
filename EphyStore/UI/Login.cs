using EphyStore.Business_Logic;
using EphyStore.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EphyStore.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        LoginBusinessLogicLayer login = new LoginBusinessLogicLayer();
        LoginDataAccessLayer loginDAL = new LoginDataAccessLayer();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Close Login form
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login.username = textBoxUserName.Text.Trim();
            login.password = textBoxPassword.Text.Trim();
            login.user_type = comboBoxUserType.Text.Trim();

            //Checking the login credentials
            bool success = loginDAL.LoginCheck(login);
            if (success == true)
            {
                //Login successful
                MessageBox.Show("Login Successful");
                //Open respective forms based on user type
                switch (login.user_type)
                {
                    case "Admin":
                        {
                            //Display admin dashboard
                            MainAdminDashboard admin = new MainAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            //Display user dashboard
                            UserDashboard user = new UserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Display error message
                            MessageBox.Show("Invalid user type");
                        }
                        break;
                }
            }
            else
            {
                //Login failed
                MessageBox.Show("Login failed. Try again");
            }
        }
    }
}
