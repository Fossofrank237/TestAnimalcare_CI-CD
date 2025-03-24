using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AnimalCare_dbFirst
{
    public partial class Report : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();
        protected void Page_Init(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Init is called");
            System.Diagnostics.Debug.WriteLine("triggerPAGEINIT");
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadVisits();
                //LoadReports();
            }
        }

        protected void LoadVisits()
        {
           var visits = entities.Visits
                .Select(v => new { v.VisitId, v.DateStart })
                .ToList();
            this.ddlVisits.DataSource = visits;
            this.ddlVisits.DataTextField = "DateStart";
            this.ddlVisits.DataValueField = "VisitId";
            this.ddlVisits.DataBind();
        }


        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    int visitId = Convert.ToInt32(ddlVisits.SelectedValue);
        //    Report newReport = new Report
        //    {
        //        VisitId = visitId,
        //        ReportContent = txtReport.Text,
        //        CreatedDate = DateTime.Now
        //    };

        //    entities.Reports.Add(newReport);
        //    entities.SaveChanges();
        //    txtReport.Text = ""; // Clear text box
        //    LoadReports();
        //}

        //protected void LoadReports()
        //{
        //    gvReports.DataSource = entities.Report
        //        .Select(r => new { r.VisitId, r.ReportContent, r.CreatedDate })
        //        .ToList();
        //    gvReports.DataBind();
        //}

        protected void ddlVisits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}