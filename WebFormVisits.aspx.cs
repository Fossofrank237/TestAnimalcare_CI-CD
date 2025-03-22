using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormVisits : System.Web.UI.Page
    {
        AnimalCareEntities AnimalCareEntities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView pour les rendez-vous
            var visits = AnimalCareEntities.vw_ActiveVisitsForPets.ToList();
            GridViewAppointments.DataSource = visits;
            GridViewAppointments.DataBind();

            //GridView pour les disponibilités
            var availability = AnimalCareEntities.vw_VeterinaryAvailabilityForWeek.ToList();
            GridViewAvailability.DataSource = availability;
            GridViewAvailability.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtBoxDateStart.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd") + " 00:00:00";
            this.PanelCalendar.Visible = false;
        }

        protected void txtBoxDateStart_TextChanged1(object sender, EventArgs e)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["EmployeeRole"].ToString().Equals("AD"))
            {
                Response.Redirect("WebFormAdmin.aspx");
            }
            else if (Session["EmployeeRole"].ToString().Equals("RE"))
            {
                Response.Redirect("WebFormRec.aspx");
            }

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var query = AnimalCareEntities.vw_ActiveVisitsForPets.AsQueryable();

            //Les filtres
            //Owner phone number
            if (!string.IsNullOrEmpty(this.txtBoxOwnerPhone.Text))
            {
                query = query.Where(v => v.OwnerPhoneNumber.ToLower().StartsWith(this.txtBoxOwnerPhone.Text.ToLower()));
            }

            //Pet name
            if (!string.IsNullOrEmpty(this.txtBoxPetName.Text))
            {
                query = query.Where(v => v.PetName.ToLower().StartsWith(this.txtBoxPetName.Text.ToLower()));
            }

            //Employee first name
            if (!string.IsNullOrEmpty(this.txtBoxEmployeeFirstName.Text))
            {
                query = query.Where(v => v.EmployeeFirstName.ToLower().StartsWith(this.txtBoxEmployeeFirstName.Text.ToLower()));
            }

            //Employee last name
            if (!string.IsNullOrEmpty(this.txtBoxEmployeeLastName.Text))
            {
                query = query.Where(v => v.EmployeeLastName.ToLower().StartsWith(this.txtBoxEmployeeLastName.Text.ToLower()));
            }

            //Application du filtre
            this.GridViewAppointments.DataSource = query.ToList();
            this.GridViewAppointments.DataBind();
        }

        protected void btnResetFilter_Click(object sender, EventArgs e)
        {
            var visits = AnimalCareEntities.vw_ActiveVisitsForPets.ToList();
            GridViewAppointments.DataSource = visits;
            GridViewAppointments.DataBind();

            this.txtBoxOwnerPhone.Text = "";
            this.txtBoxPetName.Text = "";
            this.txtBoxEmployeeFirstName.Text = "";
            this.txtBoxEmployeeLastName.Text = "";
            this.txtBoxDateStart.Text = "";
            this.lblMessage.Text = "";
            ViewState["DateStartChanged"] = null;
        }

        protected void btnNewAppointment_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBoxOwnerPhone.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPetName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxEmployeeFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxEmployeeLastName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxDateStart.Text))
            {
                this.lblMessage.Text = "Error: All fields are required (Owner phone number, Pet name, Employee firts and last name, date for the visit.";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //Récupérations des dates, petId et employee
            DateTime dateStart = DateTime.Parse(txtBoxDateStart.Text);
            DateTime dateEnd = dateStart.AddMinutes(30);

            int petId = AnimalCareEntities.Pets.
                Where(p => p.Name == this.txtBoxPetName.Text).
                Select(p => p.PetId).
                FirstOrDefault();

            Employee selectedEmployee = AnimalCareEntities.Employees.
                Where(v => v.FirstName == this.txtBoxEmployeeFirstName.Text &&
                v.LastName == this.txtBoxEmployeeLastName.Text).
                FirstOrDefault();

            //Création de la visit
            Visit newVisit = new Visit
            {
                DateStart = dateStart,
                DateEnd = dateEnd,
                Report = "",
                Active = true,
                PetId = petId,
            };

            try
            {
                //Assignation de la visit dans la propiéte de navigation de la visit
                newVisit.Employees.Add(selectedEmployee);
                AnimalCareEntities.Visits.Add(newVisit);
                AnimalCareEntities.SaveChanges();

                this.lblMessage.Text = "Visit created successcully";
                this.lblMessage.ForeColor = System.Drawing.Color.Green;
            } catch (Exception ex)
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


            //GridView pour les rendez-vous
            var visits = AnimalCareEntities.vw_ActiveVisitsForPets.ToList();
            GridViewAppointments.DataSource = visits;
            GridViewAppointments.DataBind();
        }

        protected void btnModifyAppointment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxOwnerPhone.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPetName.Text))
            {
                this.lblMessage.Text = "Error: Owner phone number and Pet name are required.";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //Récupération des petId et Visit à modifier

            int petId = AnimalCareEntities.Pets.
                Where(p => p.Name == this.txtBoxPetName.Text).
                Select(p => p.PetId)
                .FirstOrDefault();

            if(petId == 0)
            {
                this.lblMessage.Text = "Pet not found";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Visit visitSelected = AnimalCareEntities.Visits.
                Where(v => v.PetId == petId).
                FirstOrDefault();

            if(visitSelected == null)
            {
                this.lblMessage.Text = "Visit not found";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Employee selectedEmployee = AnimalCareEntities.Employees.
                Where(v => v.FirstName == this.txtBoxEmployeeFirstName.Text &&
                v.LastName == this.txtBoxEmployeeLastName.Text).
                FirstOrDefault();

            //Récupération de la nouvelle date
            DateTime dateStart = DateTime.Parse(txtBoxDateStart.Text);
            DateTime dateEnd = dateStart.AddMinutes(30);

            try
            {
                visitSelected.DateStart = dateStart;
                visitSelected.DateEnd = dateEnd;
                visitSelected.Report = "";
                visitSelected.Active = true;
                visitSelected.PetId = petId;

                //Vérification si la visit est avec le meme vet ou autre.
                if(selectedEmployee != null)
                {
                    visitSelected.Employees.Clear();
                    visitSelected.Employees.Add(selectedEmployee);
                }
                

                AnimalCareEntities.SaveChanges();

                //GridView pour les rendez-vous
                var visits = AnimalCareEntities.vw_ActiveVisitsForPets.ToList();
                GridViewAppointments.DataSource = visits;
                GridViewAppointments.DataBind();

                this.lblMessage.Text = "Visit updated successfully!";
                this.lblMessage.ForeColor = System.Drawing.Color.Green;
            } catch (Exception ex)
            {
                this.lblMessage.Text = "Error updating the visit " + ex.Message;
                this.lblMessage.ForeColor= System.Drawing.Color.Red;
            }
        }

        protected void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxOwnerPhone.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPetName.Text))
            {
                this.lblMessage.Text = "Error: Owner phone number and Pet name are required.";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //Récupération des petId et Visit à modifier

            int petId = AnimalCareEntities.Pets.
                Where(p => p.Name == this.txtBoxPetName.Text).
                Select(p => p.PetId)
                .FirstOrDefault();

            if (petId == 0)
            {
                this.lblMessage.Text = "Pet not found";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Visit visitSelected = AnimalCareEntities.Visits.
                Where(v => v.PetId == petId).
                FirstOrDefault();

            if (visitSelected == null)
            {
                this.lblMessage.Text = "Visit not found";
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            visitSelected.Employees.Clear();
            AnimalCareEntities.Visits.Remove(visitSelected);
            AnimalCareEntities.SaveChanges();

            //GridView pour les rendez-vous
            var visits = AnimalCareEntities.vw_ActiveVisitsForPets.ToList();
            GridViewAppointments.DataSource = visits;
            GridViewAppointments.DataBind();

            this.lblMessage.Text = "Visit deleted successfully!";
            this.lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}