<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            height: 32px;
            text-align: center;
        }
        .auto-style4 {
            text-align: right;
            width: 302px;
        }
        .auto-style5 {
            text-align: right;
            height: 23px;
            width: 302px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 302px;
        }
        .auto-style9 {
            width: 376px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Manage Employee"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="X-Large" Text="Options" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Button ID="BtnAdd" runat="server" Text="ADD" OnClick="BtnAdd_Click" />
                        <asp:Button ID="BtnShow" runat="server" Text="SHOW" OnClick="BtnSearch_Click" />
                        <asp:Button ID="BtnEdit" runat="server" Text="Modify" OnClick="BtnEdit_Click" />
                        <asp:Button ID="BtnRemove" runat="server" Text="Remove" OnClick="BtnRemove_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="3">
                        <asp:Button ID="BtnApply" runat="server" Enabled="False" OnClick="BtnApply_Click" Text="Apply" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label4" runat="server" Text="Id :"></asp:Label>
                    </td>
                    <td class="auto-style6" colspan="2">
                        <asp:TextBox ID="TxtBoxId" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label5" runat="server" Text="First Name :"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxFn" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label6" runat="server" Text="Last Name : "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxLn" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label7" runat="server" Text="Role : "></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DropDownRole" runat="server" Enabled="False">
                            <asp:ListItem Selected="True" Value="VT">Veterinarian</asp:ListItem>
                            <asp:ListItem Value="AD">Administrator</asp:ListItem>
                            <asp:ListItem Value="RE">Receptionist</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:GridView ID="GridViewEmployee" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label8" runat="server" Text="Speciality : "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxSpec" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label9" runat="server" Text="Phone Number :"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxPhone" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label10" runat="server" Text="Email :"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxEmail" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label11" runat="server" Text="Password :"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtBoxPassword" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="LabelMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="HiddenFieldOption" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Button ID="BtnReturn" runat="server" OnClick="BtnReturn_Click" Text="Return to Admin Panel" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
