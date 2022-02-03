using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PhysioWebPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysioWebPortal.WebPortal
{
    public partial class AddCareGiver : System.Web.UI.Page
    {
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
                var caregiver = new PatientCaregiver();

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = TextBox1.Text, Email = TextBox1.Text };
                IdentityResult result = manager.Create(user, TextBox2.Text);

                if (result.Succeeded)
                {
                    try
                    {
                        caregiver.CaregiverId = user.Id;
                        caregiver.PatientId = dropdownlist1.SelectedValue;
                        caregiver.LastUpdated = DateTime.Now;
                        caregiver.LastUpdatedBy = strCurrentUserId;

                        AddUserToRole(user.UserName, "Caregiver");

                        ctx.PatientCaregivers.Add(caregiver);
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