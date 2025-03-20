using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        //Création du contexte pour la DataBase
        AnimalCareEntities AnimalCareEntities = new AnimalCareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Récuperation des données pour le login
            string userName = Login1.UserName;
            string password = Login1.Password;

            Employee employee = AnimalCareEntities.Employees.FirstOrDefault(u => u.Email == userName && u.Password == password);

            if (employee != null)
            {
                e.Authenticated = true;

                //Sauvgarder les données pour la session
                Session["EmployeeId"] = employee.EmployeeId;
                Session["EmployeeRole"] = employee.Role;

                if (employee.Role.Equals("VT"))
                {
                    Response.Redirect("WebFormVet.aspx");
                    
                } 
                else if (employee.Role.Equals("AD"))
                {
                    Response.Redirect("WebFormAdmin.aspx");

                }
                else if (employee.Role.Equals("RE"))
                {
                    Response.Redirect("WebFormRec.aspx");
                }
            }
            else { e.Authenticated = false; }
        }
    }
}