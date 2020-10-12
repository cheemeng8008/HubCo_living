using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class AddProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String unitType = ddlType.SelectedValue;
            String address = txtAddress.Text;
            String unitNo = txtNumber.Text;
            if(unitType.Length == 0 || address.Length == 0 || unitNo.Length == 0 || filUpPictures.HasFile == false)
            {
                Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
            }
            foreach (HttpPostedFile postedFile in filUpPictures.PostedFiles)
            {
                String fileName = Path.GetFileName(postedFile.FileName);
                String type = postedFile.ContentType;

                using(Stream stream = postedFile.InputStream)
                {
                    using(BinaryReader br = new BinaryReader(stream))
                    {
                        byte[] bytes = br.ReadBytes((Int32)stream.Length);

                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");
                        SqlCommand cmd = new SqlCommand("insert into Rooms values (@roomType, @address, @unitNumber, 'Available') ", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@roomType", txtType.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@unitNumber", txtNumber.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

       

                    }
                }
            }
        }

        private void validateFiles()
        {
            int fileCount = filUpPictures.PostedFiles.Count;

            if (fileCount == 4)
            {

            }
            else
            {

            }
        }
    }
}


