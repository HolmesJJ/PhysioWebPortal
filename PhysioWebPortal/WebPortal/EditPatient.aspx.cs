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
    public partial class EditPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }
                using (PHYSIODBEntities ctx = new PHYSIODBEntities())
                {
                    if(Request.QueryString["Id"] != null)
                    {
                        ViewState["Id"] = Request.QueryString["Id"];
                        ViewState["PatientCodeName"] = Request.QueryString["PatientCodeName"];
                        ViewState["Remarks"] = Request.QueryString["Remarks"];

                        String id = Request.QueryString["Id"].ToString();

                        var patient = (from a in ctx.Patients
                                       where a.Id == id
                                       select a).FirstOrDefault();
                        if(patient != null)
                        {
                            TextBox1.Text = patient.PatientCodeName;
                            TextBox2.Text = patient.Remarks;
                        }
                        
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String strCurrentUserId = User.Identity.GetUserId();
            String id = Request.QueryString["Id"].ToString();

            using (PHYSIODBEntities ctx = new PHYSIODBEntities())
            {
                var patient = (from a in ctx.Patients
                               where a.Id == id
                               select a).FirstOrDefault();

                patient.PatientCodeName = TextBox1.Text;
                patient.Remarks = TextBox2.Text;
                patient.PreferredLanguage = Int32.Parse(DropDownList1.SelectedValue);
                patient.LastUpdated = DateTime.Now;
                patient.LastUpdatedBy = strCurrentUserId;

                ctx.SaveChanges();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }
        //CancelBtn
        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "returnSelection(true)", true);
        }
    }
}