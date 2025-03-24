using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class AnimalsRecords : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAnimalRecords();
            }
        }
        protected void LoadAnimalRecords()
        {
            var animalData = entities.Pets
                .Select(p => new
                {
                    p.PetId,
                    p.Name,
                    p.Species,
                    OwnerName = p.Owner.FirstName + " " + p.Owner.LastName,
                    OwnerPhone = p.Owner.PhoneNumber
                }).ToList();

            gvAnimals.DataSource = animalData;
            gvAnimals.DataBind();
        }
    }
}
