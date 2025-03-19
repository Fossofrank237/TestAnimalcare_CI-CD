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
            GridView1.DataSource = AnimalCareEntities.vw_VisitsForToday.ToList();
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Style["white-space"] = "nowrap";
        }
    }
}