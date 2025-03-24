using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            //Récupérations des disponibilitées selon l'id
            var availability = AnimalCareEntities.vw_VeterinaryAvailabilityForWeek
                .Where(v => v.EmployeeId == employeeId)
                .ToList();

            GridView2.DataSource = availability;
            GridView2.DataBind();
            
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

        protected void btnAvailability_Click(object sender, EventArgs e)
        {
            PanelAvailability.Visible = true;
            Panel1.Visible = true;
        }

        protected void txtBoxDate_TextChanged(object sender, EventArgs e)
        {

            if (ViewState["DateStartChanged"] == null)
            {

                this.PanelCalendar.Visible = true;


                ViewState["DateStartChanged"] = true;
            }
            else
            {
                this.PanelCalendar.Visible = false;
            }

        }

        protected void btnNewAvailability_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBoxDate.Text) ||
                string.IsNullOrEmpty(txtBoxTimeStart.Text) ||
                string.IsNullOrEmpty(txtBoxTimeEnd.Text))
            {
                this.lblMessage.Text = "Error: All fields are required.";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            ////Récupérations des donnés
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            DateTime date = DateTime.Parse(txtBoxDate.Text);
            TimeSpan timeStart = TimeSpan.Parse(txtBoxTimeStart.Text);
            TimeSpan timeEnd = TimeSpan.Parse(txtBoxTimeEnd.Text);

            //Availability newAvailability = new Availability
            //{
            //    EmployeeId = employeeId,
            //    Day = date,
            //    timeStart = timeStart,
            //    timeEnd = timeEnd
            //};

            try
            {
                //AnimalCareEntities.Availabilities.Add(newAvailability);
                //AnimalCareEntities.SaveChanges();

                string query = "INSERT INTO Availability (EmployeeId, Day, timeStart, timeEnd) VALUES (@EmployeeId, @Day, @timeStart, @timeEnd)";
                using (var connection = new SqlConnection("data source=.\\SQL2022DEV;initial catalog=AnimalCare;integrated security=True;TrustServerCertificate=true;MultipleActiveResultSets=True;"))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.Parameters.AddWithValue("@Day", date); // Aquí usas un DateTime con la hora si es necesario
                        command.Parameters.AddWithValue("@timeStart", timeStart);
                        command.Parameters.AddWithValue("@timeEnd", timeEnd);

                        command.ExecuteNonQuery();
                    }
                }

                this.lblMessage.Text = "Availability created successcully";
                this.lblMessage.ForeColor = System.Drawing.Color.Green;

            }
            catch (Exception ex)
            {
                string errorMessage;

                if (ex.InnerException?.InnerException != null)
                {
                    errorMessage = ex.InnerException.InnerException.Message;
                }
                else if (ex.InnerException != null)
                {
                    errorMessage = ex.InnerException.Message;
                }
                else
                {
                    errorMessage = ex.Message;
                }

                this.lblMessage.Text = "Error: " + errorMessage;
                this.lblMessage.ForeColor = System.Drawing.Color.Red;

            }

           
            //Récupérations des disponibilitées selon l'id
            var availability = AnimalCareEntities.vw_VeterinaryAvailabilityForWeek
                .Where(v => v.EmployeeId == employeeId)
                .ToList();

            GridView2.DataSource = availability;
            GridView2.DataBind();

            ViewState["DateStartChanged"] = null;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtBoxDate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            this.PanelCalendar.Visible = false;

        }
    }
}