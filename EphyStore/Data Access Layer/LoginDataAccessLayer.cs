using EphyStore.Business_Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EphyStore.Data_Access_Layer
{
    class LoginDataAccessLayer
    {
        // Static string to connect to database
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool LoginCheck(LoginBusinessLogicLayer login)
        {
            // Create a boolean variable and set value to false
            bool isSuccess = false;

            //Connect to database
            SqlConnection con = new SqlConnection(myconnstr);

            try
            {
                //Sql query to check login
                string sql = "Select * from Users where username=@username and password=@password and user_type=@user_type";

                //Creating sql command to pass value
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@username", login.username);
                cmd.Parameters.AddWithValue("@password", login.password);
                cmd.Parameters.AddWithValue("@user_type", login.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                // Check the no of rows in datatable
                if(dt.Rows.Count > 0)
                {
                    //Login successful
                    isSuccess = true;
                }
                else
                {
                    //Logim failed
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
    }
}
