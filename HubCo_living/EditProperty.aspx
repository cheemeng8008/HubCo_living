<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProperty.aspx.cs" Inherits="HubCo_living.EditProperty1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Property</h2>

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
                    <td><label>Room Status : </label></td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Available" GroupName="availability" Checked="true"/>
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Unavailable" GroupName="availability"/>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnCancel" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" Text="Back" />
&nbsp;
            <asp:Button ID="btnConfirm" runat="server" Text="Update" OnClick="btnConfirm_Click" />
        </div>
    </form>
</body>
</html>
