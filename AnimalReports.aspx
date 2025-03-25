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
                <asp:DropDownList ID="ddlVisits" runat="server" CssClass="form-select" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlVisits_SelectedIndexChanged"></asp:DropDownList>

                <label class="form-label mt-2">Write Report:</label>
                <asp:TextBox ID="txtReport" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"
                    placeholder="Write your report here..."></asp:TextBox>

                <asp:Button ID="btnSave" runat="server" Text="Save Report" CssClass="btn btn-primary mt-3"
                    OnClick="btnSave_Click" />
            </div>
        

        <h3 class="mt-4">Existing Reports</h3>
        <asp:GridView ID="gvReports" runat="server" CssClass="table table-bordered table-hover mt-2"
            AutoGenerateColumns="False" OnRowCommand="gvReports_RowCommand" DataKeyNames="VisitId"
            OnRowEditing="gvReports_RowEditing" OnRowUpdating="gvReports_RowUpdating"
            OnRowCancelingEdit="gvReports_RowCancelingEdit" AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField DataField="VisitId" HeaderText="Visit ID" ReadOnly="true" />

                <asp:BoundField DataField="Report" HeaderText="Report" ReadOnly="true" />
                <%--<asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" ReadOnly="true" />--%>
                
<%--                <asp:TemplateField HeaderText="Report">
                    <ItemTemplate>
                        <asp:Label ID="lblReportContent" runat="server" Text='<%# Eval("ReportContent") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditReport" runat="server" CssClass="form-control"
                            Text='<%# Eval("ReportContent") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit"
                            CssClass="btn btn-warning btn-sm">Edit</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteReport"
                            CommandArgument='<%# Eval("ReportID") %>' CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Are you sure you want to delete this report?');">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update"
                            CssClass="btn btn-success btn-sm">Update</asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel"
                            CssClass="btn btn-secondary btn-sm">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
            </form>
    </div>
</body>
</html>
