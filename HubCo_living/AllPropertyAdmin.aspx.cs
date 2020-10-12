using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class EditProperty : System.Web.UI.Page
    {

        private SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepeaterData();
            }

        }

        private void RepeaterData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select * from ( select a.*, b.imageContent, ROW_NUMBER() over(partition by a.roomID order by a.roomID) as rownum from Rooms a, PropertyImages b where a.roomID=b.roomID) as c where c.rownum=1;", con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                Label2.Text = ex.ToString();
                Response.Write("<script language=javascript>alert('An error occured when loading room data.')</script>");
            }
        }

        protected void Image_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ImageClick")
            {
                Application["roomID"] = e.CommandArgument.ToString();
                Response.Redirect("EditProperty.aspx");
            }
        }
        protected string GetImage(object img)
        {
            return "data:image/jpg;base64, " + Convert.ToBase64String((byte[])img);
        }
    }
}