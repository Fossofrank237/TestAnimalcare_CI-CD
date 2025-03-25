<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalDetails.aspx.cs" Inherits="AnimalCare_dbFirst.AnimalDetails" %>

<!DOCTYPE html>
<html>
<head>
    <title>Animal Details</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body class="bg-light">
    <div class="container mt-4">
        <h2 class="text-center text-info">Animal Details</h2>

        <h3 class="mt-3">Active Pet Treatments</h3>
        <div class="card shadow p-3">
           <form runat="server">
            <asp:GridView ID="gvTreatments" runat="server" CssClass="table table-bordered table-hover">
                <Columns>
                    <asp:BoundField DataField="PetId" HeaderText="PetId" />
                    <asp:BoundField DataField="PetName" HeaderText="Pet Name" />
                    <asp:BoundField DataField="Description" HeaderText="Treatment" />
                    <asp:BoundField DataField="Medicine" HeaderText="Medicine" />
                    <asp:BoundField DataField="Dose" HeaderText="Dose" />
                </Columns>
            </asp:GridView>
            </form>
        </div>
    </div>
</body>
</html>