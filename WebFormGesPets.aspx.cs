using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormGesPets : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOwnersDropdown();
                LoadTotalPets(); // On charge tout par défaut
            }
        }

        private void LoadActivePets()
        {
            var activePets = entities.vw_ActiveVisitsForPets
                .AsEnumerable()
                .Select(p => new
                {
                    p.PetId,
                    Name = p.PetName,
                    OwnerName = p.OwnerFirstName + " " + p.OwnerPhoneNumber
                }).ToList();

            GridView1.DataSource = activePets;
            GridView1.DataBind();
        }

        private void LoadActiveVisits()
        {
            var activeVisits = entities.vw_ActiveVisitsForPets
                .AsEnumerable()
                .Select(v => new
                {
                    v.PetId,
                    Name = v.PetName,
                    OwnerName = v.OwnerFirstName + " " + v.OwnerPhoneNumber,
                    VisitDate = v.VisitDateStart.ToString("yyyy-MM-dd HH:mm"),
                    Veterinary = v.EmployeeFirstName + " " + v.EmployeeLastName
                }).ToList();

            GridView1.DataSource = activeVisits;
            GridView1.DataBind();
        }

        private void LoadTotalPets()
        {
            var allPets = entities.Pets
                .Join(entities.Owners,
                    pet => pet.OwnerId,
                    owner => owner.OwnerId,
                    (pet, owner) => new
                    {
                        pet.PetId,
                        Name = pet.Name,
                        pet.Species,
                        pet.Age,
                        OwnerName = owner.FirstName + " " + owner.LastName
                    }).ToList();

            GridView1.DataSource = allPets;
            GridView1.DataBind();
        }

        private void LoadOwnersDropdown()
        {
            var owners = entities.Owners
                .Select(o => new { o.OwnerId, OwnerName = o.FirstName + " " + o.LastName })
                .ToList();

            ddlOwner.DataSource = owners;
            ddlOwner.DataTextField = "OwnerName";
            ddlOwner.DataValueField = "OwnerId";
            ddlOwner.DataBind();
        }

        protected void btnViewActivePets_Click(object sender, EventArgs e)
        {
            LoadActivePets();
            GridView1.Visible = true;
        }

        protected void btnViewActiveVisits_Click(object sender, EventArgs e)
        {
            LoadActiveVisits();
            GridView1.Visible = true;
        }

        protected void btnShowTotalPets_Click(object sender, EventArgs e)
        {
            LoadTotalPets();
            GridView1.Visible = true;
        }

        protected void btnAddPet_Click(object sender, EventArgs e)
        {
            Pet newPet = new Pet
            {
                Name = txtPetName.Text,
                Species = txtSpecies.Text,
                Age = int.Parse(txtAge.Text),
                OwnerId = int.Parse(ddlOwner.SelectedValue)
            };

            entities.Pets.Add(newPet);
            entities.SaveChanges();
            LoadTotalPets();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadTotalPets();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadTotalPets();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int petId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            var pet = entities.Pets.Find(petId);

            if (pet != null)
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                pet.Name = (row.Cells[1].Controls[0] as TextBox)?.Text;
                pet.Species = (row.Cells[2].Controls[0] as TextBox)?.Text;
                pet.Age = int.Parse((row.Cells[3].Controls[0] as TextBox)?.Text);

                entities.SaveChanges();
                GridView1.EditIndex = -1;
                LoadTotalPets();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int petId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            var pet = entities.Pets.Find(petId);

            if (pet != null)
            {
                entities.Pets.Remove(pet);
                entities.SaveChanges();
                LoadTotalPets();
            }
        }

        protected void btnViewTodayVisits_Click(object sender, EventArgs e)
        {
            var todayVisits = entities.vw_VisitsForToday
                .AsEnumerable()
                .Select(v => new
                {
                    v.VisitId,
                    VisitStart = v.DateStart.ToString("yyyy-MM-dd HH:mm"),
                    VisitEnd = v.DateEnd.ToString("yyyy-MM-dd HH:mm"),
                    v.PetName,
                    Veterinary = v.EmployeeFirstName + " " + v.EmployeeLastName
                })
                .ToList();

            GridView1.DataSource = todayVisits;
            GridView1.DataBind();
            GridView1.Visible = true;
        }

    }
}
