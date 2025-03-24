<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormOwners.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormOwners" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Owners</title>
    <style>
        .header { text-align: center; font-size: x-large; font-weight: bold; }
        .center { text-align: center; }
        .btn:hover { background-color: #284775; }
        .input { margin: 5px; }
        .auto-style1 {
            text-align: center;
            height: 157px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">ANIMAL CARE - OWNER MANAGEMENT</div>

        <div class="auto-style1">
            <asp:Label runat="server" Text="First Name:" />
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="input" />

            <asp:Label runat="server" Text="Last Name:" />
            <asp:TextBox ID="txtLastName" runat="server" CssClass="input" /><br />

            <asp:Label runat="server" Text="Phone:" />
            <asp:TextBox ID="txtPhone" runat="server" CssClass="input" />

            <asp:Label runat="server" Text="Email:" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" />

            <asp:Label runat="server" Text="Address:" />
            <asp:TextBox ID="txtAddress" runat="server" CssClass="input" Width="200px" /><br />

            <asp:Button ID="btnAddOwner" runat="server" Text="Add Owner" CssClass="btn" OnClick="btnAddOwner_Click" Height="39px" Width="144px" />
        </div>

        <div style="margin-top:20px" class="center">
            <asp:GridView ID="GridViewOwners" runat="server" AutoGenerateColumns="False" 
                          OnRowEditing="GridViewOwners_RowEditing"
                          OnRowUpdating="GridViewOwners_RowUpdating"
                          OnRowCancelingEdit="GridViewOwners_RowCancelingEdit"
                          OnRowDeleting="GridViewOwners_RowDeleting"
                          DataKeyNames="OwnerId" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OwnerId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
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
        </div>
    </form>
</body>
</html>
