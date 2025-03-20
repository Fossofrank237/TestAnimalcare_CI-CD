<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormVetSchedule.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormVetSchedule" %>

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
            height: 49px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Veterinarians Schedules "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Button ID="BtnPast" runat="server" Text="Past Schedule" style="margin-right:10px;" OnClick="BtnPast_Click"/>
                        <asp:Button ID="BtnNextWeek" runat="server" Text="Next 7 day Schedule" style="margin-right: 10px;margin-left: 10px;" OnClick="BtnNextWeek_Click"/>
                        <asp:Button ID="BtnViewAll" runat="server" Text="View All" style="margin-right: 10px;margin-left: 10px;" OnClick="BtnViewAll_Click"/>
                        <asp:Button ID="BtnToday" runat="server" Text="Today Schedule" style="margin-left: 10px;margin-right: 10px;" OnClick="BtnToday_Click"/>
                        <asp:Button ID="BtnFutur" runat="server" Text="Future Schedule" style="margin-left:10px;" OnClick="BtnFutur_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridViewVetSchedule" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            </table>
        </div>
    </form>
</body>
</html>
