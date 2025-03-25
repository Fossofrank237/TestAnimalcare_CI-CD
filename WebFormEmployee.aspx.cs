using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Loader le gridView avec la vue EmployeeContacts
            this.GridViewEmployee.DataSource = entities.vw_EmployeeContacts.ToList();
            this.GridViewEmployee.DataBind();
        }

        /// <summary>
        /// Reset all the possible input to default value. 
        /// </summary>
        private void ResetAllInput()
        {
            TxtBoxId.Text = string.Empty;
            TxtBoxFn.Text = string.Empty;
            TxtBoxLn.Text = string.Empty;
            DropDownRole.ClearSelection();
            TxtBoxSpec.Text = string.Empty;
            TxtBoxPhone.Text = string.Empty;
            TxtBoxEmail.Text = string.Empty;
            TxtBoxPassword.Text = string.Empty;
        }

        /// <summary>
        /// Disable all the possible input
        /// </summary>
        private void DisableAllInput()
        {
            TxtBoxId.Enabled = false;
            TxtBoxFn.Enabled = false;
            TxtBoxLn.Enabled = false;
            DropDownRole.Enabled = false;
            TxtBoxSpec.Enabled = false;
            TxtBoxPhone.Enabled = false;
            TxtBoxEmail.Enabled = false;
            TxtBoxPassword.Enabled = false;
            BtnApply.Enabled = false;
        }

        /// <summary>
        /// Checking function for input selection before making an action.
        /// </summary>
        /// <param name="withId">
        /// Does the function check for all input other than the id or for only the id.
        /// true for only the id and false for all but id.
        /// </param>
        /// <returns></returns>
        private bool CheckAllInputSelected(bool withId)
        {
            if (withId)
            {
                return !string.IsNullOrEmpty(TxtBoxId.Text);
            }
            else
            {
                if (
                    !string.IsNullOrEmpty(TxtBoxFn.Text) &&
                    !string.IsNullOrEmpty(TxtBoxLn.Text) &&
                    !string.IsNullOrEmpty(TxtBoxSpec.Text) &&
                    !string.IsNullOrEmpty(TxtBoxPhone.Text) &&
                    !string.IsNullOrEmpty(TxtBoxEmail.Text) &&
                    !string.IsNullOrEmpty(TxtBoxPassword.Text)
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Add a message to the label used for this effect and make it red or green if error or not
        /// </summary>
        /// <param name="error">Is an error</param>
        /// <param name="msg">the text to print</param>
        private void AddMessage(bool error, string msg)
        {
            if (error)
            {
                LabelMsg.ForeColor = Color.Red;
            }
            else
            {
                LabelMsg.ForeColor = Color.Green;
            }
            LabelMsg.Text = msg;
        }

        /// <summary>
        /// Selecting add as the action on the page  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            HiddenFieldOption.Value = "add";
            DisableAllInput(); // Reset the input. 

            // Reset LabelMsg
            LabelMsg.Text = string.Empty;

            // Enable only the necessary input
            TxtBoxFn.Enabled = true;
            TxtBoxLn.Enabled = true;
            DropDownRole.Enabled = true;
            TxtBoxSpec.Enabled = true;
            TxtBoxPhone.Enabled = true;
            TxtBoxEmail.Enabled = true;
            TxtBoxPassword.Enabled = true;
            BtnApply.Enabled = true;
        }

        /// <summary>
        /// Selecting show as the action on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            HiddenFieldOption.Value = "show";
            DisableAllInput(); // Reset the input. 

            // Reset LabelMsg
            LabelMsg.Text = string.Empty;

            // Enable only the necessary input
            TxtBoxId.Enabled = true;
            BtnApply.Enabled = true;
        }

        /// <summary>
        /// Selecting edit as the action on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            HiddenFieldOption.Value = "edit";
            DisableAllInput(); // Reset the input. 

            // Reset LabelMsg
            LabelMsg.Text = string.Empty;

            // Enable only the necessary input
            TxtBoxFn.Enabled = true;
            TxtBoxLn.Enabled = true;
            DropDownRole.Enabled = true;
            TxtBoxSpec.Enabled = true;
            TxtBoxPhone.Enabled = true;
            TxtBoxEmail.Enabled = true;
            TxtBoxPassword.Enabled = true;
            BtnApply.Enabled = true;
        }

        /// <summary>
        /// Selecting remove as the action on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            HiddenFieldOption.Value = "remove";
            DisableAllInput(); // Reset the input. 

            // Reset LabelMsg
            LabelMsg.Text = string.Empty;

            // Enable only the necessary input
            TxtBoxId.Enabled = true;
            BtnApply.Enabled = true;
        }

        protected void BtnApply_Click(object sender, EventArgs e)
        {
            // Depending on the option selected do the right logic.
            try
            {
                LabelMsg.Text = HiddenFieldOption.Value;
                switch (HiddenFieldOption.Value)
                {
                    case "add":
                        if (CheckAllInputSelected(false))
                        {
                            // Création du nouveau employee
                            Employee emp = new Employee();
                            emp.FirstName = TxtBoxFn.Text;
                            emp.LastName = TxtBoxLn.Text;
                            emp.Role = DropDownRole.SelectedValue;
                            emp.Speciality = TxtBoxSpec.Text;
                            emp.PhoneNumber = TxtBoxPhone.Text;
                            emp.Email = TxtBoxEmail.Text;
                            emp.Password = TxtBoxPassword.Text;

                            // Sending it to the database
                            entities.Employees.Add(emp);
                            entities.SaveChanges();

                            // Updating the GridView
                            GridViewEmployee.DataSource = entities.vw_EmployeeContacts.ToList();
                            GridViewEmployee.DataBind();

                            // Validation Message
                            AddMessage(false, "Successfully added new Employee!");

                            // Reseting the view
                            DisableAllInput();
                            ResetAllInput();

                        }
                        else
                        {
                            // Error message.
                            AddMessage(true, "Please fill all the required input!");
                        }
                        return;
                    case "show":
                        if (CheckAllInputSelected(true))
                        {
                            // Recherche de l'employee by its Id
                            Employee emp = entities.Employees.Find(Convert.ToInt32(TxtBoxId.Text));

                            // Check if employee doesnt exist 
                            if (emp == null)
                            {
                                AddMessage(true, "Employee with this ID doesn't exist!");
                                ResetAllInput();
                                return;
                            }

                            // Filling the input with the employee found
                            TxtBoxFn.Text = emp.FirstName;
                            TxtBoxLn.Text = emp.LastName;
                            DropDownRole.SelectedValue = emp.Role;
                            TxtBoxSpec.Text = emp.Speciality;
                            TxtBoxPhone.Text = emp.PhoneNumber;
                            TxtBoxEmail.Text = emp.Email;
                            TxtBoxPassword.Text = emp.Password;

                            // Validation Message
                            AddMessage(false, "Successfully found the Employee!");

                            // Reseting the view but keeping the data in input
                            DisableAllInput();

                        }
                        else
                        {
                            // Error message.
                            AddMessage(true, "Please fill all the required input!");
                        }
                        return;
                    case "edit":
                        if (CheckAllInputSelected(false))
                        {
                            // Obtenir l'employee a modifier
                            Employee emp = entities.Employees.Find(Convert.ToInt32(TxtBoxId.Text));

                            // Modification de l'employee
                            emp.FirstName = TxtBoxFn.Text;
                            emp.LastName = TxtBoxLn.Text;
                            emp.Role = DropDownRole.SelectedValue;
                            emp.Speciality = TxtBoxSpec.Text;
                            emp.PhoneNumber = TxtBoxPhone.Text;
                            emp.Email = TxtBoxEmail.Text;
                            emp.Password = TxtBoxPassword.Text;

                            // Saving it to the database
                            entities.SaveChanges();

                            // Updating the GridView
                            GridViewEmployee.DataSource = entities.vw_EmployeeContacts.ToList();
                            GridViewEmployee.DataBind();

                            // Validation Message
                            AddMessage(false, "Successfully Modified the Employee!");

                            // Reseting the view
                            DisableAllInput();
                            ResetAllInput();

                        }
                        else
                        {
                            // Error message.
                            AddMessage(true, "Please fill all the required input!");
                        }
                        return;
                    case "remove":
                        if (CheckAllInputSelected(true))
                        {
                            // Recherche de l'employee by its Id
                            Employee emp = entities.Employees.Find(Convert.ToInt32(TxtBoxId.Text));

                            // Check if employee doesnt exist 
                            if (emp == null)
                            {
                                AddMessage(true, "Employee with this ID doesn't exist!");
                                ResetAllInput();
                                return;
                            }

                            // Removing the employee from the database
                            entities.Employees.Remove(emp);

                            // Save the changes 
                            entities.SaveChanges();

                            // Updating the GridView
                            GridViewEmployee.DataSource = entities.vw_EmployeeContacts.ToList();
                            GridViewEmployee.DataBind();

                            // Validation Message
                            AddMessage(false, "Successfully deleted the Employee!");

                            // Reseting the view
                            DisableAllInput();
                            ResetAllInput();

                        }
                        else
                        {
                            // Error message.
                            AddMessage(true, "Please fill all the required input!");
                        }
                        return;
                }
            }
            catch (Exception ex)
            {
                string errorMessage;

                if (ex.InnerException?.InnerException != null)
                {
                    errorMessage = ex.InnerException.InnerException.Message;
                }
                else if (ex.InnerException != null)
                {
                    errorMessage = ex.InnerException.Message;
                }
                else
                {
                    errorMessage = ex.Message;
                }
                AddMessage(true, "Error: " + errorMessage);
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAdmin.aspx");
        }
    }
}