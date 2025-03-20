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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtBoxDateStart.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd") + " 00:00:00";
            this.PanelCalendar.Visible = false;
        }

        protected void txtBoxDateStart_TextChanged1(object sender, EventArgs e)
        {
            this.PanelCalendar.Visible = true;
        }
    }
}