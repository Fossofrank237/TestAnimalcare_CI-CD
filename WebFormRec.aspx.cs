using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormRec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            string employeeRole = Session["EmployeeRole"].ToString();
        }

        protected void btnManagePets_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormPet.aspx");
        }
    }
}