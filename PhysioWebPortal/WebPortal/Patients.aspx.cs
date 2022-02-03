using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PhysioWebPortal
{
    public partial class Patients : System.Web.UI.Page
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
        
        protected void RadButton2_Click(object sender, EventArgs e)
        {
            RadGrid1.DataBind();
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadGrid grid = (RadGrid)sender;

            GridDataItem dataBoundItem = e.Item as GridDataItem;

            if (e.CommandName == "EditCommand")
            {
                String patientId = dataBoundItem["Id"].Text;

                RadWindow UserListDialog = RadWindow1;

                UserListDialog.NavigateUrl = "EditPatient.aspx?Id=" + patientId;
                UserListDialog.Modal = true;
                UserListDialog.Height = 400;
                UserListDialog.Width = 700;
                UserListDialog.VisibleOnPageLoad = true;
                UserListDialog.DestroyOnClose = true;
                

                e.Canceled = true;
            }
            else if (e.CommandName == "MoreCommand")
            {
                String PatientId = dataBoundItem["Id"].Text;

                Response.Redirect("HospitalStay.aspx?PatientId=" + PatientId);

                e.Canceled = true;
            }
            
        }

        protected void RadButton3_Click(object sender, EventArgs e)
        { 
            RadButton button = (RadButton)sender;
            RadWindow UserListDialog = RadWindow2;
            
            UserListDialog.NavigateUrl = "AddPatient.aspx";
            UserListDialog.Modal = true;
            UserListDialog.Height = 400;
            UserListDialog.Width = 700;
            UserListDialog.VisibleOnPageLoad = true;
            UserListDialog.DestroyOnClose = true;
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if(e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                TableCell cellPreferredLanguage = item["PreferredLanguage"];

                TableCell cellLanguage = item["Language"];

                if (cellPreferredLanguage.Text.Equals("1"))
                {
                    cellLanguage.Text = "English";
                }
                else if (cellPreferredLanguage.Text.Equals("2"))
                {
                    cellLanguage.Text = "Chinese";
                }
                else if (cellPreferredLanguage.Text.Equals("3"))
                {
                    cellLanguage.Text = "Malay";
                }
                else if (cellPreferredLanguage.Text.Equals("4"))
                {
                    cellLanguage.Text = "Tamil";
                }
            }

        }
    }
}