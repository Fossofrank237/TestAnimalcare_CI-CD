using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class Report : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVisits();
                LoadReports();
            }
        }

        protected void LoadVisits()
        {
            var visits = entities.Visits
                 .Select(v => new { v.VisitId, v.DateStart, v.Report })
                 .ToList();

            ddlVisits.DataSource = visits;
            ddlVisits.DataTextField = "DateStart";
            ddlVisits.DataValueField = "VisitId";
            ddlVisits.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 selectedVisit = Convert.ToInt32(this.ddlVisits.SelectedValue);
            var visit = entities.Visits
                        .FirstOrDefault(v => v.VisitId == selectedVisit);
            visit.Report = this.txtReport.Text;
            entities.SaveChanges();  
        }

        protected void LoadReports()
        {
            var visits = entities.Visits
                .Select(v => new { v.VisitId, v.Report })
                .ToList();
            gvReports.DataSource = visits;
            gvReports.DataBind();
        }

        protected void gvReports_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReports.EditIndex = e.NewEditIndex;
            LoadReports();
        }

        protected void gvReports_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int reportID = Convert.ToInt32(gvReports.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvReports.Rows[e.RowIndex];
            TextBox txtEditReport = (TextBox)row.FindControl("txtEditReport");

            var report = entities.Report.Find(reportID);
            if (report != null)
            {
               
                entities.SaveChanges();
            }

            gvReports.EditIndex = -1;
            LoadReports();
        }

        protected void gvReports_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReports.EditIndex = -1;
            LoadReports();
        }

        protected void gvReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteReport")
            {
                int reportID = Convert.ToInt32(e.CommandArgument);
                var report = entities.Report.Find(reportID);
                if (report != null)
                {
                    entities.Report.Remove(report);
                    entities.SaveChanges();
                    LoadReports();
                }
            }
        }

        protected void ddlVisits_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
