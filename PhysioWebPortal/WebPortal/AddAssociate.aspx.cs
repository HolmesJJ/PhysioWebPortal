using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysioWebPortal.WebPortal
{
    public partial class AddAssociate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }

                String id = Request.QueryString["CaregiverId"];

                using (PHYSIODBEntities ctx = new PHYSIODBEntities())
                {
                    var caregiver = (from a in ctx.PatientCaregivers
                                      where a.CaregiverId == id
                                      select a).FirstOrDefault();

                    TextBox1.Text = id;
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String strCurrentUserId = User.Identity.GetUserId();

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var associate = new PatientCaregiver();

                associate.CaregiverId = TextBox1.Text;
                associate.PatientId = dropdownlist1.SelectedValue;
                associate.LastUpdated = DateTime.Now;
                associate.LastUpdatedBy = strCurrentUserId;

                ctx.PatientCaregivers.Add(associate);
                ctx.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }
    }
}