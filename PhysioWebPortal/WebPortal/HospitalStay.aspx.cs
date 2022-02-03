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
    public partial class HospitalStay1 : System.Web.UI.Page
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

            SqlDataSource2.SelectParameters["PatientId"].DefaultValue = Request.QueryString["PatientId"];
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            RadGrid1.DataBind();
        }

        //HopsitalStay RadGrid
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadGrid grid = (RadGrid)sender;

            GridDataItem dataBoundItem = e.Item as GridDataItem;

            if (e.CommandName == "EditCommand")
            {
                String StayId = dataBoundItem["StayId"].Text;

                RadWindow UserListDialog = RadWindow1;

                UserListDialog.NavigateUrl = "EditHospitalStay.aspx?StayId=" + StayId;
                UserListDialog.Modal = true;
                UserListDialog.Height = 400;
                UserListDialog.Width = 700;
                UserListDialog.VisibleOnPageLoad = true;
                UserListDialog.DestroyOnClose = true;

                e.Canceled = true;
            }
        }

        //AddHospitalStay data
        protected void RadButton3_Click(object sender, EventArgs e)
        {
            RadButton button = (RadButton)sender;
            RadWindow UserListDialog = RadWindow2;

            String id = Request.QueryString["PatientId"];

            UserListDialog.NavigateUrl = "AddHospitalStay.aspx?PatientId=" + id;
            UserListDialog.Modal = true;
            UserListDialog.Height = 400;
            UserListDialog.Width = 700;
            UserListDialog.VisibleOnPageLoad = true;
            UserListDialog.DestroyOnClose = true;
        }

        //AddPrescribedExercises data
        protected void RadButton2_Click(object sender, EventArgs e)
        {
            RadButton button = (RadButton)sender;
            RadWindow UserListDialog = RadWindow3;

            GridDataItem selectedStayItem = RadGrid1.SelectedItems[0] as GridDataItem;
            
            String id = selectedStayItem["StayId"].Text.ToString();

            UserListDialog.NavigateUrl = "AddPrescribedExercise.aspx?StayId=" + id;
            UserListDialog.Modal = true;
            UserListDialog.Height = 400;
            UserListDialog.Width = 700;
            UserListDialog.VisibleOnPageLoad = true;
            UserListDialog.DestroyOnClose = true;
        }

        //HospitalStay Pose
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                TableCell cellPose = item["Pose"];

                TableCell cellPoseName = item["PoseName"];

                if (cellPose.Text.Equals("1"))
                {
                    cellPoseName.Text = "Standing";
                }
                else if (cellPose.Text.Equals("2"))
                {
                    cellPoseName.Text = "Lying";
                }
            }
        }

        //PrescribedExercises RadGrid
        //protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    RadGrid grid = (RadGrid)sender;

        //    GridDataItem dataBoundItem = e.Item as GridDataItem;

        //    if (e.CommandName == "DetailsCommand")
        //    {
        //        String PEId = dataBoundItem["PEId"].Text;

        //        RadWindow UserListDialog = RadWindow1;

        //        UserListDialog.NavigateUrl = "EditHospitalStay.aspx?PEId=" + PEId;
        //        UserListDialog.Modal = true;
        //        UserListDialog.Height = 400;
        //        UserListDialog.Width = 700;
        //        UserListDialog.VisibleOnPageLoad = true;
        //        UserListDialog.DestroyOnClose = true;

        //        e.Canceled = true;
        //    }
        //}

        //Upload PerformedExercises
        protected void RadButton4_Click(object sender, EventArgs e)
        {

        }
    }
}