using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PhysioWebPortal.WebPortal
{
    public partial class PatientCaregivers : System.Web.UI.Page
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

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            RadGrid1.DataBind();
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            RadButton button = (RadButton)sender;
            RadWindow UserListDialog = RadWindow1;

            UserListDialog.NavigateUrl = "AddCareGiver.aspx";
            UserListDialog.Modal = true;
            UserListDialog.Height = 400;
            UserListDialog.Width = 700;
            UserListDialog.VisibleOnPageLoad = true;
            UserListDialog.DestroyOnClose = true;
        }

        protected void RadButton3_Click(object sender, EventArgs e)
        {
            RadButton button = (RadButton)sender;
            RadWindow UserListDialog = RadWindow2;

            GridDataItem selectedStayItem = RadGrid1.SelectedItems[0] as GridDataItem;

            String id = selectedStayItem["CaregiverId"].Text.ToString();

            UserListDialog.NavigateUrl = "AddAssociate.aspx?CaregiverId=" + id;
            UserListDialog.Modal = true;
            UserListDialog.Height = 400;
            UserListDialog.Width = 700;
            UserListDialog.VisibleOnPageLoad = true;
            UserListDialog.DestroyOnClose = true;
        }
    }
}