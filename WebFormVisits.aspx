<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormVisits.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormVisits" %>

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
        .auto-style4 {
            width: 351px;
        }
        .auto-style5 {
            text-align: center;
            font-size: x-large;
            text-decoration: underline;
            height: 31px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 351px;
            height: 23px;
        }
        .auto-style9 {
            height: 23px;
            text-align: center;
        }
        .auto-style10 {
            width: 336px;
        }
        .auto-style11 {
            width: 300px;
        }
        .auto-style12 {
            text-align: center;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="4">
                        <h1>MANAGE VISITS</h1>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5" colspan="4">Options</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="4">
                        <asp:Button ID="btnNewAppointment" runat="server" Text="New Visit" style="margin-right: 10px" OnClick="btnNewAppointment_Click"/>
                        <asp:Button ID="btnModifyAppointment" runat="server" Text="Modify Visit" style="margin-left: 10px;margin-right: 10px" OnClick="btnModifyAppointment_Click"/>
                        <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Visit" style="margin-left: 10px;" OnClick="btnDeleteAppointment_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                </tr>
                </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label1" runat="server" Text="Owner Phone Number"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="Label2" runat="server" Text="Pet Name"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="Label6" runat="server" Text="Employee First Name"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="Label7" runat="server" Text="Employee Last Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Date Start"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:TextBox ID="txtBoxOwnerPhone" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtBoxPetName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtBoxEmployeeFirstName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtBoxEmployeeLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxDateStart" runat="server" AutoPostBack="true" OnTextChanged="txtBoxDateStart_TextChanged1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:Panel ID="PanelCalendar" runat="server" Visible="False">
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="5">
                    <h3>Filter</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="5">
                        <asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="5">
                    <asp:Button ID="btnResetFilter" runat="server" OnClick="btnResetFilter_Click" Text="Reset" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="5">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td>
                    <h2 class="auto-style2">VISITS</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewAppointments" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            </tr>
            <tr>
                <td>
                    <h2 class="auto-style2">VETERINARY&#39;S AVAILABILITY</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewAvailability" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return to Panel" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
