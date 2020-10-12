using System;
using System.Data.SqlClient;

namespace HubCo_living
{
    public partial class EditProperty1 : System.Web.UI.Page
    {
        private String roomID = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                roomID = Application["roomID"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('Please select a property!')</script>");
                Response.Redirect("AllPropertyAdmin.aspx");
            }



            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Rooms where roomID = @roomID ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@roomID", roomID);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {

                    txtAddress.Text = reader["address"].ToString();
                    txtCity.Text = reader["city"].ToString();
                    txtPostcode.Text = reader["postcode"].ToString();
                    txtNumber.Text = reader["unitNumber"].ToString();
                    ddlState.SelectedValue = reader["state"].ToString();
                    ddlType.SelectedValue = reader["roomType"].ToString();
                    if (reader["status"].ToString() == "Available")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Property does not exist!')</script>");
                Response.Redirect("AllPropertyAdmin.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}