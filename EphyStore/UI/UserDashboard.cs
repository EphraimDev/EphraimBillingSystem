﻿using EphyStore.UI;
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
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void UserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }
    }
}
