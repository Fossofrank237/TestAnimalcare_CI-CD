using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare_dbFirst
{
    public partial class WebFormVetSchedule : System.Web.UI.Page
    {
        AnimalCareEntities entities = new AnimalCareEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate the GridView on page load 
            var scheduleList = entities.VeterinarySchedules.ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.FirstName,
                vs.LastName,
                vs.Role,
                vs.Speciality,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();

            this.GridViewVetSchedule.DataBind();
        }

        /// <summary>
        /// Shows the schedule for the next 7 days.
        /// All the data is order By EmployeeId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnNextWeek_Click(object sender, EventArgs e)
        {
            var scheduleList = entities.vw_VeterinaryAvailabilityForWeek.ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.EmployeeFirstName,
                vs.EmployeeLastName,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();
            this.GridViewVetSchedule.DataBind();
        }

        /// <summary>
        /// Show the schedule for today. 
        /// All the data is order By EmployeeId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnToday_Click(object sender, EventArgs e)
        {
            var scheduleList = entities.VeterinarySchedules.Where(
                vs => DbFunctions.TruncateTime(vs.Day) == DateTime.Today.Date).ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.FirstName,
                vs.LastName,
                vs.Role,
                vs.Speciality,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();
            this.GridViewVetSchedule.DataBind();
        }

        protected void BtnPast_Click(object sender, EventArgs e)
        {
            var scheduleList = entities.VeterinarySchedules.Where(
                vs => vs.Day < DateTime.Today).ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.FirstName,
                vs.LastName,
                vs.Role,
                vs.Speciality,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();
            this.GridViewVetSchedule.DataBind();
        }

        protected void BtnViewAll_Click(object sender, EventArgs e)
        {
            var scheduleList = entities.VeterinarySchedules.ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.FirstName,
                vs.LastName,
                vs.Role,
                vs.Speciality,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();

            this.GridViewVetSchedule.DataBind();
        }

        protected void BtnFutur_Click(object sender, EventArgs e)
        {
            var scheduleList = entities.VeterinarySchedules.Where(
                vs => vs.Day > DateTime.Today).ToList();
            this.GridViewVetSchedule.DataSource = scheduleList.Select(vs => new
            {
                vs.EmployeeId,
                vs.FirstName,
                vs.LastName,
                vs.Role,
                vs.Speciality,
                Day = vs.Day.ToString("yyyy-MM-dd"),
                vs.timeStart,
                vs.timeEnd,
            }).OrderBy(vs => vs.EmployeeId).ToList();
            this.GridViewVetSchedule.DataBind();
        }
    }
}