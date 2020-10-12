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
                    <td><asp:TextBox ID="txtAddress" runat="server" Height="228px" TextMode="MultiLine" Width="389px"></asp:TextBox></td>
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
            </table>

        </div>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    </form>
</body>
</html>
