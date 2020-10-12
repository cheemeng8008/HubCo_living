using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
            String postcode = txtPostcode.Text;
            String city = txtCity.Text;
            String state = ddlState.SelectedValue;

            //Make sure all fields filled up
            if (unitType.Length == 0 || address.Length == 0 || unitNo.Length == 0 || postcode.Length ==0 || city.Length==0 || state.Length==0)
            {
                Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
            }
            else
            {

                // Verify post code length and type
                if (postcode.Length < 5)
                {
                    Response.Write("<script language=javascript>alert('Invalid postal code.')</script>");

                }
                else
                {
                    //Check if postal code is only numbers
                    if (IsDigit(postcode))
                    {
                        try
                        {
                            int postnumber = int.Parse(postcode);
                            
                            //Check whether postal code within range
                            if(postnumber<1000 || postnumber > 87033)
                            {
                                Response.Write("<script language=javascript>alert('This post code does not exist.')</script>");
                            }
                            else
                            {

                                //Check whether city is in alphabets only
                                if (IsLetter(city))
                                {

                                    String fullAddress = address + ", " + postcode + ' ' + city + ' ' + state + ", Malaysia";

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
                                                SqlCommand cmd = new SqlCommand("insert into Rooms values (@roomType, @address, @unitNumber, @availability) ", con);
                                                con.Open();
                                                cmd.Parameters.AddWithValue("@roomType", unitType);
                                                cmd.Parameters.AddWithValue("@address", (address + ", " + postcode + ' ' + city + ' ' + state + ", Malaysia"));
                                                cmd.Parameters.AddWithValue("@unitNumber", unitNo);
                                                if (RadioButton1.Checked)
                                                    cmd.Parameters.AddWithValue("@availability", RadioButton1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@availability", RadioButton2.Text);
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
                                else
                                {
                                    Response.Write("<script language=javascript>alert('Input for city have to be in alphabets only.')</script>");
                                }

                            }
                        }
                        catch(Exception ex)
                        {
                            Response.Write("<script language=javascript>alert('Oops something went wrong.')</script>");
                        }
                        
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Post code can only contain numbers.')</script>");
                    }
                }





                
            }
        }

        private bool verifyFileNumber()
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

        private bool verifyFileType()
        {
            bool filetype = true;

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

        private bool IsDigit(string str)
        {
            foreach(char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private bool IsLetter(string str)
        {
            Regex r = new Regex("^[a-z A-Z]+$");

            if (r.IsMatch(str))
                return true;
  
            else
                return false;
        }

    }
}


