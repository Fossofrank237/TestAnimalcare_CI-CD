<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormGesPets2.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormGesPets2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Animal Care Veterinary</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2"><strong>ANIMAL CARE VETERINARY</strong></td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style3" colspan="2">
                    <asp:Button ID="btnTodayVisits" runat="server" Text="Today Visitss"
      CssClass="btn" OnClick="btnTodayVisits_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnViewActivePets" runat="server" Text="Active Pets" OnClick="btnViewActivePets_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnShowTotalPets" runat="server" Text="Show Total Pets" OnClick="btnShowTotalPets_Click" />
                </td>
            </tr>

            <tr><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style4" colspan="2">
                    Name:
                    <asp:TextBox ID="txtPetName" runat="server" Width="132px" />
                    &nbsp;&nbsp;&nbsp; Species:
                    <asp:TextBox ID="txtSpecies" runat="server" Width="108px" />
                    &nbsp;&nbsp;&nbsp; Age:
                    <asp:TextBox ID="txtAge" runat="server" Width="62px" />
                    &nbsp;&nbsp;&nbsp; Owner:
                    <asp:DropDownList ID="ddlOwner" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr><td colspan="2" class="auto-style3"><asp:Button ID="btnAddPet" runat="server" Text="Add Pet" Height="40px" Width="139px" OnClick="btnAddPet_Click" /></td></tr>

            <tr><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td colspan="2" style="padding-left:20px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PetId"
                        CellPadding="4" ForeColor="#333333" GridLines="None"
                        OnRowEditing="GridView1_RowEditing"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowUpdating="GridView1_RowUpdating"
                        OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="PetId" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Species" HeaderText="Species" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="OwnerName" HeaderText="Owner" />
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
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
                    <!-- GridView pour les visites d’aujourd’hui -->
<asp:GridView ID="GridViewTodayVisits" runat="server" AutoGenerateColumns="False"
    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False"
    CssClass="grid-view">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="VisitId" HeaderText="Visit ID" ReadOnly="true" />
        <asp:BoundField DataField="PetName" HeaderText="Pet" />
        <asp:BoundField DataField="DateStart" HeaderText="Start Time" />
        <asp:BoundField DataField="DateEnd" HeaderText="End Time" />
        <asp:BoundField DataField="Veterinary" HeaderText="Veterinary" />
    </Columns>
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
        <p class="auto-style3">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return to Panel" />
                </p>
    </form>
</body>
</html>
