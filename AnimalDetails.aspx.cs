using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                int petId = Convert.ToInt32(Request.QueryString["PetId"]);
                LoadActiveTreatments(petId);
            }
        }

        protected void LoadActiveTreatments(int petId)
        {
            var treatments = entities.vw_ActivePetTreatments
                .Where(t => t.PetId == petId)
                .ToList();

            gvTreatments.DataSource = treatments;
            gvTreatments.DataBind();
        }
    }
}