<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalActiveTreatment.aspx.cs" Inherits="AnimalCare_dbFirst.AnimalDetails" %>

<!DOCTYPE html>
<html>
<head>
    <title>Animal Details</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body class="bg-light">
    <div class="container mt-4">
        <h2 class="text-center text-success">Animal Treatments</h2> 

        <h4 class="mt-3">Active Pet Treatments</h4> 
        
        <form runat="server">
             <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
 <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvTreatments" runat="server" CssClass="table table-bordered table-hover mt-2"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PetId" HeaderText="Pet ID" />
                    <asp:BoundField DataField="PetName" HeaderText="Pet Name" />
                    <asp:BoundField DataField="Treatment" HeaderText="Treatment" />
                    <asp:BoundField DataField="Medicine" HeaderText="Medicine" />
                    <asp:BoundField DataField="Dose" HeaderText="Dose" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
   

</body>
</html>
