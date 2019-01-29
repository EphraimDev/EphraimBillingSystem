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
    class UserDataAccessLayer
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Select Data from Database
        public DataTable select()
        {
            //static method to connect to the database
            SqlConnection con = new SqlConnection(myconnstring);
            // To hold data from database
            DataTable dt = new DataTable();
            try
            {
                // Sql Query to get data from database
                string sql = "Select * from Users";
                // For executing command
                SqlCommand cmd = new SqlCommand(sql, con);
                // Getting data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // Open Database connection 
                con.Open();
                // Fill data in our datatable
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                // Throw message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close connection
                con.Close();
            }
            // Return value in datatable
            return dt;
        }
        #endregion

        #region Insert Data into Database
        public bool Insert(UserBusinessLogic user)
        {
            bool Issuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);

            try
            {
                string sql = "insert into Users(firstname,lastname,email,username,password,contact,address,gender,user_type,added_date,added_by) values(@firstname,@lastname,@email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@firstname", user.firstname);
                cmd.Parameters.AddWithValue("@lastname", user.lastname);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@contact", user.contact);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@user_type", user.user_type);
                cmd.Parameters.AddWithValue("@added_date", user.added_date);
                cmd.Parameters.AddWithValue("@added_by", user.added_by);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                // If the query is executed successfully then the value of rows will be greater than 0 else less than 0
                if (rows > 0)
                {
                    //Query successful
                    Issuccess = true;
                }
                else
                {
                    //Query failed
                    Issuccess = false;
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

            return Issuccess;
        }
        #endregion

        #region Update data in Database
        public bool Update(UserBusinessLogic user)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);

            try
            {
                string sql = "update Users set firstname=@firstname, lastname=@lastname, email=@email, username=@username, password=@password, contact=@contact, address=@address, gender=@gender, user_type=@user_type, added_date=@added_date, added_by=@added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@firstname", user.firstname);
                cmd.Parameters.AddWithValue("@lastname", user.lastname);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@contact", user.contact);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@gender", user.gender);
                cmd.Parameters.AddWithValue("@user_type", user.user_type);
                cmd.Parameters.AddWithValue("@added_date", user.added_date);
                cmd.Parameters.AddWithValue("@added_by", user.added_by);
                cmd.Parameters.AddWithValue("@id", user.id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query successful
                    isSuccess = true;
                }
                else
                {
                    // Query failed
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
        #endregion

        #region Delete data from Database
        public bool Delete(UserBusinessLogic user)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);

            try
            {
                string sql = "delete from Users where id=@id";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", user.id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query successful
                    isSuccess = true;
                }
                else
                {
                    //Query failed
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
        #endregion
    }
}
