<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnimalReports.aspx.cs" Inherits="AnimalCare_dbFirst.Report" %>

<!DOCTYPE html>
<html>
<head>
    <title>Reports</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body class="bg-light">
    <div class="container mt-4">
            <h2 class="text-center text-primary">Veterinary Reports</h2>
        <form runat="server"> 
        <div class="card p-3 shadow">
            <label for="ddlVisits" class="form-label">Select Visit:</label>
            
            <asp:DropDownList ID="ddlVisits" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlVisits_SelectedIndexChanged"></asp:DropDownList>
            <label class="form-label mt-2">Write Report:</label>
            <asp:TextBox ID="txtReport" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Write your report here..."></asp:TextBox>

            <asp:Button ID="btnSave" runat="server" Text="Save Report" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />
        </div>

        <h3 class="mt-4">Existing Reports</h3>
        <asp:GridView ID="gvReports" runat="server" CssClass="table table-bordered table-hover mt-2">
            <Columns>
                <asp:BoundField DataField="VisitId" HeaderText="Visit ID" />
                <asp:BoundField DataField="ReportContent" HeaderText="Report" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Date" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="Actions" />
            </Columns>
        </asp:GridView>
         </form>
    </div>
</body>
</html>