using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormPet : System.Web.UI.Page
    {
        AnimalCareEntities db = new AnimalCareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPets();
            }
        }

        private void LoadPets()
        {
            GridViewPets.DataSource = db.Pets.ToList();
            GridViewPets.DataBind();
        }

        protected void btnAddPet_Click(object sender, EventArgs e)
        {
            try
            {
                Pet newPet = new Pet
                {
                    Name = txtName.Text,
                    Species = txtSpecies.Text,
                    Age = int.Parse(txtAge.Text),
                    OwnerId = int.Parse(txtOwnerId.Text)
                };

                db.Pets.Add(newPet);
                db.SaveChanges();
                LoadPets();

                txtName.Text = "";
                txtSpecies.Text = "";
                txtAge.Text = "";
                txtOwnerId.Text = "";
            }
            catch (Exception ex)
            {
                // Handle error (log it, display message, etc.)
            }
        }

        protected void GridViewPets_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPets.EditIndex = e.NewEditIndex;
            LoadPets();
        }

        protected void GridViewPets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewPets.Rows[e.RowIndex];
            int petId = Convert.ToInt32(GridViewPets.DataKeys[e.RowIndex].Value);

            TextBox txtEditName = row.Cells[1].Controls[0] as TextBox;
            TextBox txtEditSpecies = row.Cells[2].Controls[0] as TextBox;
            TextBox txtEditAge = row.Cells[3].Controls[0] as TextBox;
            TextBox txtEditOwnerId = row.Cells[4].Controls[0] as TextBox;

            Pet pet = db.Pets.FirstOrDefault(p => p.PetId == petId);
            if (pet != null)
            {
                pet.Name = txtEditName.Text;
                pet.Species = txtEditSpecies.Text;
                pet.Age = int.Parse(txtEditAge.Text);
                pet.OwnerId = int.Parse(txtEditOwnerId.Text);

                db.SaveChanges();
            }

            GridViewPets.EditIndex = -1;
            LoadPets();
        }

        protected void GridViewPets_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPets.EditIndex = -1;
            LoadPets();
        }

        protected void GridViewPets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int petId = Convert.ToInt32(GridViewPets.DataKeys[e.RowIndex].Value);
            Pet pet = db.Pets.FirstOrDefault(p => p.PetId == petId);
            if (pet != null)
            {
                db.Pets.Remove(pet);
                db.SaveChanges();
            }
            LoadPets();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormRec.aspx");
        }
    }
}
