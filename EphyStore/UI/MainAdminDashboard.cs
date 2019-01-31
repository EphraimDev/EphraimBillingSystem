using EphyStore.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EphyStore
{
    public partial class MainAdminDashboard : Form
    {
        public MainAdminDashboard()
        {
            InitializeComponent();
        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
        }

        private void MainAdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void MainAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }
    }
}
