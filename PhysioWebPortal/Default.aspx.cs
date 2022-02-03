using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PhysioWebPortal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            RadButton clickedButton = (RadButton)sender;
        }

        protected void CommandBtn_Click(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Login")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}