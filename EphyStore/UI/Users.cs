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
                clear();
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

        private void clear()
        {
            textBoxUserID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            textBoxPassword.Text = "";
            comboBoxGender.Text = "";
            comboBoxUserType.Text = "";
            textBoxUsername.Text = "";
        }

        private void dataGridViewUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get index of particular row
            int rowIndex = e.RowIndex;
            textBoxUserID.Text = dataGridViewUsers.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewUsers.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewUsers.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridViewUsers.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxContact.Text = dataGridViewUsers.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxAddress.Text = dataGridViewUsers.Rows[rowIndex].Cells[7].Value.ToString();
            textBoxUsername.Text = dataGridViewUsers.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxPassword.Text = dataGridViewUsers.Rows[rowIndex].Cells[5].Value.ToString();
            comboBoxGender.Text = dataGridViewUsers.Rows[rowIndex].Cells[8].Value.ToString();
            comboBoxUserType.Text = dataGridViewUsers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get the values from User UI
            user.id = Convert.ToInt32(textBoxUserID.Text);
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

            // Updating data into database
            bool success = userDAL.Update(user);
            // If data is updated successfully then the value will be true else false
            if (success == true)
            {
                // Data updated successfully
                MessageBox.Show("User updated successfully");
                clear();
            }
            else
            {
                // Failed to update
                MessageBox.Show("Failed to update user");
            }
            // Refreshing Data grid view
            DataTable dt = userDAL.select();
            dataGridViewUsers.DataSource = dt;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Getting User ID from form
            user.id = Convert.ToInt32(textBoxUserID.Text);

            bool success = userDAL.Delete(user);
            // If data is deleted then the value of success will be true else false
            if (success == true)
            {
                // User successfully deleted
                MessageBox.Show("User was successfully deleted");
            }
            else
            {
                // User failed to delete
                MessageBox.Show("Failed to delete");
            }
            // Refreshing data grid view
            DataTable dt = userDAL.select();
            dataGridViewUsers.DataSource = dt;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Get keyword from search box
            string keyword = textBoxSearch.Text;

            // Check if keyword has value
            if(keyword != null)
            {
                // Show user based on keyword
                DataTable dt = userDAL.search(keyword);
                dataGridViewUsers.DataSource = dt;
            }
            else
            {
                // Show all users from database
                DataTable dt = userDAL.select();
                dataGridViewUsers.DataSource = dt;
            }
        }
        
    }
}
