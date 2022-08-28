using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using DynamicData.Admin.Model;
using System.Web.Security;
using DynamicData.Admin.Infrastructure.Services;

namespace DynamicData.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!new UserService().IsCurrentUserAdmin())
            //    lnkUsers.Visible = false;
            //if (!IsPostBack)
            //{
            //    bool isLocalized = Setting.DefaultLanguage > -1 && !Request.Path.ToLower().Contains("login.aspx");

            //    divLanguage.Visible = ddlLanguages.Enabled = isLocalized;
            //}

        }

        //protected void ddlLanguages_DataBound(object sender, EventArgs e)
        //{
        //    ddlLanguages.SelectedIndex = ddlLanguages.Items.IndexOf(ddlLanguages.Items.FindByValue(Setting.CurrentLanguage.ToString()));
        //}

        //protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["CurrentLanguage"] = ddlLanguages.SelectedValue;
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}

        public object GetLanguagesData()
        {
            AdminEntities db = new AdminEntities();
            return db.Languages.Where(l => l.Active).OrderBy(l => l.FriendlyName);
        }

        /// <summary>
        /// Displays a status message top of the page
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="messageType">Message type (successMsg, errorMsg or warningMsg)</param>
        public void ShowMessage(string title, string message, NotificationType messageType)
        {
            ucNotifier.Show(title, message, messageType);
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/login.aspx");
        }
    }
}
