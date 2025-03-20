using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormAdmin : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewHistory.DataSource = entities.HistoryVisits.ToList();
            this.GridViewHistory.DataBind();

            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            string employeeRole = Session["EmployeeRole"].ToString();
        }

        protected void TxtBoxFilterPetName_TextChanged(object sender, EventArgs e)
        {
            // Outdated 
        }

        /// <summary>
        /// Apply all the filters that have been selected to modify the Visit History View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            var query = entities.HistoryVisits.AsQueryable();
            // Date filter 
            if (this.CalendarFilterDate.SelectedDate != default) {
                query = query.Where(h => DbFunctions.TruncateTime(h.DateStart) == this.CalendarFilterDate.SelectedDate.Date);
            }

            // Pet Filter
            if (!string.IsNullOrEmpty(this.TxtBoxFilterPetName.Text)) {
                query = query.Where(h => h.PetName.ToLower().StartsWith(this.TxtBoxFilterPetName.Text));
            }
            // Owner First Name Filter
            if (!string.IsNullOrEmpty(this.TxtBoxFilterOwnerFN.Text)) {
                query = query.Where(h => h.OwnerFirstName.ToLower().StartsWith(this.TxtBoxFilterOwnerFN.Text));
            }
            // Owner Last Name Filter 
            if (!string.IsNullOrEmpty(this.TxtBoxFilterOwnerLN.Text))
            {
                query = query.Where(h => h.OwnerLastName.ToLower().StartsWith(this.TxtBoxFilterOwnerLN.Text));
            }
            // Owner Phone Number Filter 
            if (!string.IsNullOrEmpty(this.TxtBoxFilterOwnerPN.Text))
            {
                query = query.Where(h => h.OwnerPhone.ToLower().StartsWith(this.TxtBoxFilterOwnerPN.Text));
            }
            // Employee First Name
            if (!string.IsNullOrEmpty(this.TxtBoxFilterEmployeeFN.Text))
            {
                query = query.Where(h => h.EmployeeFirstName.ToLower().StartsWith(this.TxtBoxFilterEmployeeFN.Text));
            }
            // Employee Last Name
            if (!string.IsNullOrEmpty(this.TxtBoxFilterEmployeeLN.Text))
            {
                query = query.Where(h => h.EmployeeLastName.ToLower().StartsWith(this.TxtBoxFilterEmployeeLN.Text));
            }
            // Apply the filters and update the gridview 
            this.GridViewHistory.DataSource = query.ToList();
            this.GridViewHistory.DataBind();
        }

        protected void CalendarFilterDate_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtnRemoveDateFilter_Click(object sender, EventArgs e)
        {
            this.CalendarFilterDate.SelectedDate = default;
        }

        protected void GridViewHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnDispoVt_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormVetSchedule.aspx");
        }
    }
}