<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProperty.aspx.cs" Inherits="HubCo_living.AddProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
            <asp:Label ID="title" runat="server" Text="Add Property" Font-Bold="True" Font-Size="X-Large"></asp:Label>  
    </div>

    <form id="form1" runat="server">
       
        <div>
            <table>
                <tr>
                    <td><label>Address : </label></td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Postcode : </label></td>
                    <td><asp:TextBox ID="txtPostcode" runat="server" MaxLength="5" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>City : </label></td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td><label>State : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem Value="0">&lt;Select State&gt;</asp:ListItem>
                            <asp:ListItem>Johor</asp:ListItem>
                            <asp:ListItem>Kedah</asp:ListItem>
                            <asp:ListItem>Kelantan</asp:ListItem>
                            <asp:ListItem>Kuala Lumpur</asp:ListItem>
                            <asp:ListItem>Labuan</asp:ListItem>
                            <asp:ListItem>Melaka</asp:ListItem>
                            <asp:ListItem>Negeri Sembilan</asp:ListItem>
                            <asp:ListItem>Pahang</asp:ListItem>
                            <asp:ListItem>Penang</asp:ListItem>
                            <asp:ListItem>Perak</asp:ListItem>
                            <asp:ListItem>Perlis</asp:ListItem>
                            <asp:ListItem>Putrajaya</asp:ListItem>
                            <asp:ListItem>Sabah</asp:ListItem>
                            <asp:ListItem>Sarawak</asp:ListItem>
                            <asp:ListItem>Selangor</asp:ListItem>
                            <asp:ListItem>Terengganu</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                </tr>
                
                <tr>
                    <td><label>Room Type : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="246px">
                            <asp:ListItem>Apartel</asp:ListItem>
                            <asp:ListItem>Coliving</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Room Number : </label></td>
                    <td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Images : </label></td>
                    <td><asp:FileUpload ID="filUpPictures" runat="server" AllowMultiple="true"/>
        
                    </td>
                </tr>
                <tr>
                    <td><label>Room Status : </label></td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Available" GroupName="availability" Checked="true"/>
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Unavailable" GroupName="availability"/>
                    </td>
                </tr>
            </table>

        </div>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    </form>
</body>
</html>
