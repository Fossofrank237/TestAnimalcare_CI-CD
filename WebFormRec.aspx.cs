﻿using System;
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
            //Récupérations des données de session
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            string employeeRole = Session["EmployeeRole"].ToString();
            string employeeName = Session["EmployeeName"].ToString();

            this.lblUserName.Text = "Welcome, " + employeeName;

        }

        protected void btnManagePets_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormGesPets.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //Effacecr les données de session
            Session.Clear();
            Session.Abandon();

            Response.Redirect("WebFormLogin.aspx");

        }

        protected void btnNewAppointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormVisits.aspx");
        }

        protected void btnManageOwners_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormOwners.aspx");
        }
    }
}