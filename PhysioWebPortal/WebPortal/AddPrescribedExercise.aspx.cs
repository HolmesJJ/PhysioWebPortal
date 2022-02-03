using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysioWebPortal.WebPortal
{
    public partial class AddPrescribedExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 id = Int32.Parse(Request.QueryString["StayId"]);

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var prescribed = (from a in ctx.HospitalStays
                                    where a.StayId == id
                                    select a).FirstOrDefault();

                TextBox1.Text = id.ToString();
            }

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
                var prescribed = new PrescribedExercis();

                prescribed.StayId = Int32.Parse(TextBox1.Text);
                prescribed.AssignedDate = DateTime.Parse(TextBox4.Text);
                prescribed.EndDate = DateTime.Parse(TextBox5.Text);
                prescribed.LastUpdated = DateTime.Now;
                prescribed.LastUpdatedBy = strCurrentUserId;
                prescribed.ExRepNo = Int32.Parse(TextBox2.Text);
                prescribed.ExSetNo = Int32.Parse(TextBox3.Text);
                prescribed.ExTimePerDay = Int32.Parse(TextBox6.Text);
                prescribed.ExId = Int32.Parse(dropdownlist1.SelectedValue);

                ctx.PrescribedExercises.Add(prescribed);
                ctx.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox4.Text = Calendar1.SelectedDate.ToLongDateString();
            Calendar1.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox5.Text = Calendar2.SelectedDate.ToLongDateString();
            Calendar2.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }
    }
}