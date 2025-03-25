<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalsRecords.aspx.cs" Inherits="AnimalCare_dbFirst.AnimalsRecords" %>

<!DOCTYPE html>
<html>
<head>
    <title>Animal Records</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body class="bg-light">
    <div class="container mt-4">
        <h2 class="text-center text-success">Animal Records</h2>

        <div class="card shadow p-3">
            <asp:GridView ID="gvAnimals" runat="server" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField DataField="PetId" HeaderText="Pet ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Species" HeaderText="Species" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="OwnerName" HeaderText="Owner" />
                    <asp:BoundField DataField="OwnerPhone" HeaderText="Phone" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</body>
</html>