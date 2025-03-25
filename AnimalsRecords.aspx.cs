using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

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
            var records = this.entities.Pets.Include(p => p.Owner).ToList();
                gvAnimalRecords.DataSource = records;
                gvAnimalRecords.DataBind();
            }
    }
}
