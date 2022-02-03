using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace PhysioWebPortal.WebPortal
{
    public partial class EditHospitalStay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }

                using (PHYSIODBEntities ctx = new PHYSIODBEntities())
                {
                    if (Request.QueryString["StayId"] != null)
                    {
                        ViewState["StayId"] = Request.QueryString["StayId"];
                        ViewState["Remarks"] = Request.QueryString["Remarks"];
                        ViewState["StartDate"] = Request.QueryString["StartDate"];
                        ViewState["EndDate"] = Request.QueryString["EndDate"];
                        ViewState["PatientId"] = Request.QueryString["PatientId"];

                        Int32 id = Convert.ToInt32(Request.QueryString["StayId"]);

                        var hospitalstay = (from a in ctx.HospitalStays
                                       where a.StayId == id
                                       join b in ctx.Patients
                                       on a.PatientId equals b.Id
                                       select a).FirstOrDefault();
                        if (hospitalstay != null)
                        {
                            TextBox2.Text = hospitalstay.Remarks;
                            TextBox1.Text = hospitalstay.Patient.PatientCodeName;
                            TextBox4.Text = hospitalstay.StartDate.ToShortDateString();
                            TextBox5.Text = hospitalstay.EndDate.ToShortDateString();
                        }
                    }
                }
            }
        }

        protected void Save1_Click(object sender, EventArgs e)
        {
            String strCurrentUserId = User.Identity.GetUserId();
            Int32 id = Convert.ToInt32(Request.QueryString["StayId"]);

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var hospitalstay = (from a in ctx.HospitalStays
                                    where a.StayId == id
                                    select a).FirstOrDefault();
                
                hospitalstay.Remarks = TextBox2.Text;
                hospitalstay.Pose = Int32.Parse(DropDownList1.SelectedValue);
                hospitalstay.LastUpdated = DateTime.Now;
                hospitalstay.LastUpdatedBy = strCurrentUserId;
                hospitalstay.StartDate = DateTime.Parse(TextBox4.Text);
                hospitalstay.EndDate = DateTime.Parse(TextBox5.Text);

                ctx.SaveChanges();

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }
        //CancelBtn
        protected void Button2_Click(object sender, EventArgs e)
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