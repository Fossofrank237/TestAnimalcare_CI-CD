<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAdmin.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormAdmin" %>

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
            width: 924px;
        }
        .filterTxtBoxStyle {
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Admin Panel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="X-Large" Text="Options" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Button ID="BtnManageEmployee" runat="server" Text="Manage Employee" style="margin-right: 10px"/>
                        <asp:Button ID="BtnDispoVt" runat="server" Text="Consult Veterinarian Schedule" style="margin-left: 10px"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="X-Large" Text="Visit History" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="7">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Text="Filter"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:Button ID="BtnApplyFilter" runat="server" OnClick="BtnApplyFilter_Click" Text="Apply Filter" />
                                </td>
                            </tr>
                            <tr>
                                <td>Date</td>
                                <td>Pet Name</td>
                                <td>Owner First Name</td>
                                <td>Owner Last Name</td>
                                <td>Owner Phone Number</td>
                                <td>Employee First Name</td>
                                <td>Employee Last Name</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Calendar ID="CalendarFilterDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarFilterDate_SelectionChanged" Width="350px">
                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#999999" />
                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                        <TodayDayStyle BackColor="#CCCCCC" />
                                    </asp:Calendar>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterPetName" runat="server" OnTextChanged="TxtBoxFilterPetName_TextChanged"></asp:TextBox>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterOwnerFN" runat="server"></asp:TextBox>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterOwnerLN" runat="server"></asp:TextBox>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterOwnerPN" runat="server"></asp:TextBox>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterEmployeeFN" runat="server"></asp:TextBox>
                                </td>
                                <td class="filterTxtBoxStyle">
                                    <asp:TextBox ID="TxtBoxFilterEmployeeLN" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridViewHistory" runat="server" HorizontalAlign="Center">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
