using System;
using System.Data.SqlClient;

namespace HubCo_living
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String email = txtEmail.Text;
            String password = txtPassword.Text;

            if (email.Length == 0 || password.Length == 0)
            {
                Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
            }

            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select password from Customers where email = @email ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader["password"].ToString() == password.ToString())
                        {
                            Response.Write("<script language=javascript>alert('Login Success.')</script>");
                        }
                        else
                        {
                            Label1.Text = reader["password"].ToString();
                            Response.Write("<script language=javascript>alert('Password Invalid.')</script>");
                        }
                    }

                }
                else
                {
                    Response.Write("<script language=javascript>alert('User not exist.')</script>");
                }
                con.Close();
            }

        }


    }
}