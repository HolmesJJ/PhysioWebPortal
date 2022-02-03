using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PhysioWebPortal.Models;
using Telerik.Web.UI;

namespace PhysioWebPortal.WebPortal
{
    public partial class AddHospitalStay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["PatientId"];

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var hospitalstay = (from a in ctx.HospitalStays
                                    where a.PatientId == id
                                    select a).FirstOrDefault();

                TextBox1.Text = id;
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
                var hospitalstay = new HospitalStay();
                
                hospitalstay.PatientId = TextBox1.Text;
                hospitalstay.Remarks = TextBox2.Text;
                hospitalstay.Pose = Int32.Parse(DropDownList1.SelectedValue);
                hospitalstay.LastUpdated = DateTime.Now;
                hospitalstay.LastUpdatedBy = strCurrentUserId;
                hospitalstay.PhysiotherapistId = strCurrentUserId;
                hospitalstay.StartDate = DateTime.Parse(TextBox4.Text);
                hospitalstay.EndDate = DateTime.Parse(TextBox5.Text);

                ctx.HospitalStays.Add(hospitalstay);
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