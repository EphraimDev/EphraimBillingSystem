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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        UserBusinessLogic user = new UserBusinessLogic();
        UserDataAccessLayer userDAL = new UserDataAccessLayer();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Getting data from UI
            user.firstname = textBoxFirstName.Text;
            user.lastname = textBoxLastName.Text;
            user.email = textBoxEmail.Text;
            user.username = textBoxUsername.Text;
            user.password = textBoxPassword.Text;
            user.contact = textBoxContact.Text;
            user.address = textBoxAddress.Text;
            user.gender = comboBoxGender.Text;
            user.user_type = comboBoxUserType.Text;
            user.added_date = DateTime.Now;
            user.added_by = 1;

            // Insert data into database
            bool success = userDAL.Insert(user);
            //If data is successfully inserted then the value of success will be true else it will be force
            if (success == true)
            {
                //Data successfully inserted
                MessageBox.Show("User successfully created");
            }
            else
            {
                //Data failed to insert
                MessageBox.Show("Failed to add new user");
            }
            // Refreshing Data Grid View
            DataTable dt = userDAL.select();
            dataGridViewUsers.DataSource = dt;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            DataTable dt = userDAL.select();
            dataGridViewUsers.DataSource = dt;
        }
    }
}
