<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormPet.aspx.cs" Inherits="AnimalCare_dbFirst.WebFormPet" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Pets</title>
    <style type="text/css">
        .auto-style1 { width: 100%; }
        .auto-style2 { text-align: center; }
        .myGrid td { white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width: 150px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style2">Manage Pets</h1>
            <asp:GridView ID="GridViewPets" runat="server" AutoGenerateColumns="False" CssClass="myGrid" DataKeyNames="PetId" OnRowEditing="GridViewPets_RowEditing" OnRowDeleting="GridViewPets_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="PetId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Species" HeaderText="Species" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="OwnerId" HeaderText="Owner ID" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <h2>Add a New Pet</h2>
            <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="txtSpecies" runat="server" Placeholder="Species"></asp:TextBox>
            <asp:TextBox ID="txtAge" runat="server" Placeholder="Age"></asp:TextBox>
            <asp:TextBox ID="txtOwnerId" runat="server" Placeholder="Owner ID"></asp:TextBox>
            <asp:Button ID="btnAddPet" runat="server" Text="Add Pet" OnClick="btnAddPet_Click" />

            <br /><br />
            <asp:Button ID="btnBack" runat="server" Text="Back to Receptionist Page" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
