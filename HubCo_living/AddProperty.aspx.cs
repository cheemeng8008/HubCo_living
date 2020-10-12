using System;
using System.Data.SqlClient;
using System.Web;

// Havent do add the pictures

namespace HubCo_living
{
    public partial class AddProperty : System.Web.UI.Page
    {
        private int fileCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            fileCount = 0;
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String unitType = ddlType.SelectedValue;
            String address = txtAddress.Text;
            String unitNo = txtNumber.Text;

            //Make sure all fields filled up
            if (unitType.Length == 0 || address.Length == 0 || unitNo.Length == 0)
            {
                Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
            }
            else
            {
                //Verify at least 4 pictures uploaded
                if (verifyFileNumber() == false)
                {
                    Response.Write("<script language=javascript>alert('At least 4 photos of the property have to be uploaded.')</script>");
                }
                else
                {
                    //Verify File Types
                    if (verifyFileType() == false)
                    {
                        Response.Write("<script language=javascript>alert('Have to be .jpeg, .jpg, .png files.')</script>");

                    }
                    else
                    {
                        try
                        {
                            //foreach (HttpPostedFile postedFile in filUpPictures.PostedFiles)
                            //{
                            //    String fileName = Path.GetFileName(postedFile.FileName);
                            //    String type = postedFile.ContentType;

                            //    using (Stream stream = postedFile.InputStream)
                            //    {
                            //        using (BinaryReader br = new BinaryReader(stream))
                            //        {
                            //            byte[] bytes = br.ReadBytes((Int32)stream.Length);

                            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True;");
                            SqlCommand cmd = new SqlCommand("insert into Rooms values (@roomType, @address, @unitNumber, 'Available') ", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@roomType", unitType);
                            cmd.Parameters.AddWithValue("@address", address);
                            cmd.Parameters.AddWithValue("@unitNumber", unitNo);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script language=javascript>alert('Room Successfully Added.')</script>");

                            //        }
                            //    }
                            //}

                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script language=javascript>alert('An error occured.')</script>");
                        }
                    }

                }
            }
        }

        private Boolean verifyFileNumber()
        {
            fileCount = filUpPictures.PostedFiles.Count;

            if (fileCount < 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean verifyFileType()
        {
            Boolean filetype = true;

            foreach (HttpPostedFile postedFile in filUpPictures.PostedFiles)
            {
                String type = postedFile.ContentType;

                if (type != "image/jpeg" && type != "image/jpg" && type != "image/png")
                {
                    filetype = false;
                    break;
                }
            }

            return filetype;
        }
    }
}


