<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormVet.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormVet" %>

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
            text-align: center;
            height: 30px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style9 {
            width: 373px;
        }
        .auto-style10 {
            height: 23px;
            width: 373px;
        }
        .auto-style13 {
            height: 30px;
        }
        .auto-style14 {
            height: 30px;
            width: 453px;
        }
        .auto-style15 {
            width: 198px;
        }
        .auto-style16 {
            height: 23px;
            width: 198px;
        }

        .myGrid td {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            max-width: 150px;
        }
        .auto-style17 {
            width: 335px;
        }
        .auto-style18 {
            height: 23px;
            width: 335px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h1 class="auto-style2">ANIMAL CARE VETERINARY</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="5">
                        <h2>VETERINARY&#39;S PAGE</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="myGrid">
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
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style18"></td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style18"></td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style14">
                    <asp:Button ID="btnAvailability" runat="server" Text="Availabity" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="btnPetFile" runat="server" Text="Pet's File" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="Button2" runat="server" Text="Full Schedule" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
