using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class AnimalDetails : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int petId;
                if (int.TryParse(Request.QueryString["PetId"], out petId))
                {
                    lblmessage.Text = "Pet ID received: " + petId;
                    LoadActiveTreatments(petId);
                }
                else
                {
                    lblmessage.Text = "No Pet ID found in URL.";
                }
            }
        }

        protected void LoadActiveTreatments(int petId)
        {
            var treatments = entities.vw_ActivePetTreatments
                .Where(t => t.PetId == petId)
                .Select(t => new
                {
                    t.PetId,
                    t.PetName,
                    t.Description, 
                    t.Medicine,
                    t.Dose
                })
                .ToList();

            gvTreatments.DataSource = treatments;
            gvTreatments.DataBind();

            if (treatments.Count == 0)
            {
                lblmessage.Text += " - No treatments found for this pet.";
            }
        }
    }
}
