using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.error
{
    public partial class generic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["msg"]))
                litErrorMessage.Text = Server.UrlDecode(Request.QueryString["msg"]);
        }
    }
}