using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormVet : System.Web.UI.Page
    {
        //Création du contexte pour la DataBase
        AnimalCareEntities AnimalCareEntities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Récupérations des données de session
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            string employeeRole = Session["EmployeeRole"].ToString();
            string employeeName = Session["EmployeeName"].ToString();

            this.lblUserName.Text = "Welcome, " + employeeName;

            //Récupérations des rendez-vous selon l'id
            var visits = AnimalCareEntities.vw_VisitsForToday
                .Where(v => v.EmployeeId == employeeId)
                .ToList();

            GridView1.DataSource = visits;
            GridView1.DataBind();

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormVetSchedule.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //Effacecr les données de session
            Session.Clear();
            Session.Abandon();

            Response.Redirect("WebFormLogin.aspx");
        }
    }
}