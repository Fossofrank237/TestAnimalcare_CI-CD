<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormRec.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormRec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receptionist Page</title>
    <style type="text/css">
        .auto-style1 { width: 100%; }
        .auto-style2 { text-align: center; }
        .auto-style3 { text-align: center; height: 30px; }
        .auto-style9 { width: 373px; }
        .auto-style13 { height: 67px; }
        .auto-style14 { height: 67px; width: 453px; }
        .auto-style15 { width: 198px; }
        .myGrid td { white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width: 150px; }
        .auto-style16 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="5" class="auto-style16">
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" class="auto-style16">
                        <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="LogOut" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h1 class="auto-style2">ANIMAL CARE VETERINARY</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="5">
                        <h2>RECEPTIONIST PAGE</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style9">
                        <asp:GridView ID="GridViewAppointments" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="myGrid">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style14">
                    <asp:Button ID="btnNewAppointment" runat="server" Text="Manage Visits" OnClick="btnNewAppointment_Click" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="btnManageOwners" runat="server" Text="Manage Owners" OnClick="btnManageOwners_Click" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="btnPetRecords" runat="server" Text="Pet Records" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="btnManagePets" runat="server" Text="Manage Pets" OnClick="btnManagePets_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
