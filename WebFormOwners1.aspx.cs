using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormOwners : System.Web.UI.Page
    {
        AnimalCareEntities db = new AnimalCareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadOwners();
        }

        private void LoadOwners()
        {
            var owners = db.Owners.ToList();
            GridViewOwners.DataSource = owners;
            GridViewOwners.DataBind();
        }

        protected void btnAddOwner_Click(object sender, EventArgs e)
        {
            Owner o = new Owner
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhone.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };

            db.Owners.Add(o);
            db.SaveChanges();
            LoadOwners();
        }

        protected void GridViewOwners_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOwners.EditIndex = e.NewEditIndex;
            LoadOwners();
        }

        protected void GridViewOwners_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewOwners.EditIndex = -1;
            LoadOwners();
        }

        protected void GridViewOwners_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridViewOwners.DataKeys[e.RowIndex].Value);
            var owner = db.Owners.Find(id);

            GridViewRow row = GridViewOwners.Rows[e.RowIndex];
            owner.FirstName = ((TextBox)row.Cells[1].Controls[0]).Text;
            owner.LastName = ((TextBox)row.Cells[2].Controls[0]).Text;
            owner.PhoneNumber = ((TextBox)row.Cells[3].Controls[0]).Text;
            owner.Email = ((TextBox)row.Cells[4].Controls[0]).Text;
            owner.Address = ((TextBox)row.Cells[5].Controls[0]).Text;

            db.SaveChanges();
            GridViewOwners.EditIndex = -1;
            LoadOwners();
        }

        protected void GridViewOwners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewOwners.DataKeys[e.RowIndex].Value);
            var owner = db.Owners.Find(id);

            db.Owners.Remove(owner);
            db.SaveChanges();
            LoadOwners();
        }
    }
}
