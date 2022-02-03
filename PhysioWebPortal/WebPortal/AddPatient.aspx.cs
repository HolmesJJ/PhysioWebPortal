using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PhysioWebPortal.Models;

namespace PhysioWebPortal.WebPortal
{
    public partial class AddPatient : System.Web.UI.Page
    {
        //ApplicationDbContext context = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String strCurrentUserId = User.Identity.GetUserId();

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var patient = new Patient();

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = TextBox1.Text, Email = TextBox1.Text + "@gmail.com"};
                IdentityResult result = manager.Create(user, "P@ssw0rd");
                
                if (result.Succeeded)
                {
                    try
                    {
                        patient.Id = user.Id;
                        patient.PatientCodeName = TextBox1.Text;
                        patient.Remarks = TextBox2.Text;
                        patient.PreferredLanguage = Int32.Parse(DropDownList1.SelectedValue);
                        patient.LastUpdated = DateTime.Now;
                        patient.LastUpdatedBy = strCurrentUserId;

                        AddUserToRole(user.UserName, "Patient");

                        ctx.Patients.Add(patient);
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }

        internal void AddUserToRole(string userName, string roleName)
        {
            var UserManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>(); 

            try
            {
                var user = UserManager.FindByName(userName);
                UserManager.AddToRole(user.Id, roleName);

                //DataAccessObject.contextDB.SaveChanges();
                //context.SaveChanges();
                UserManager.UpdateAsync(user);
            }
            catch
            {
                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }
    }
}