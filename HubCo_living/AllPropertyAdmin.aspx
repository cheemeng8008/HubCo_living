<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllPropertyAdmin.aspx.cs" Inherits="HubCo_living.EditProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Properties</h2>
            
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div style="border:1px solid #ff0000 ; display:inline-block ; width:70%">
                        <table>
                            <tr>
                                <td colspan="2">

                                    <asp:ImageButton ID="propImage" runat="server" ImageUrl='<%# GetImage(Eval("imageContent"))  %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("roomID") %>'/>
                                    
                                </td>
                                <td>
                                    <label>Address : </label>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("address").ToString() + ", " + Eval("postcode").ToString() + " " + Eval("city").ToString() + ", " + Eval("state").ToString()%>' />
                                   
                                    <br />
                                    <label>Unit No. : </label>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("unitNumber") %>' />

                                    <br />
                                    <label>Type    : </label>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("roomType") %>' />

                                    <br />
                                    <label>Status : </label>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status") %>' />

                                </td>
                            </tr>
                        </table>

                    </div>
                    <br />
                </ItemTemplate>
                
            </asp:Repeater>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />

        </div>
    </form>
</body>
</html>
