using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Infrastructure.UserMembership;
using DynamicData.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("~/unauthorized.aspx");
            }
        }

        protected void btnAuthenticate_Click(object sender, EventArgs e)
        {
            //new UserService().CreateUser("info@innovixsolutions.com", "Pass4Admin");
            //Roles.CreateRole("SuperAdmin");
            //Roles.CreateRole("Admin");
            //Roles.AddUserToRole("info@innovixsolutions.com", "SuperAdmin");
            //Roles.AddUserToRole("info@innovixsolutions.com", "Admin");
            //Roles.CreateRole("User");

            string userName = UserName.Value;
            string password = Password.Value;
            CustomValidator validator = (CustomValidator)Page.FindControl("cvLoginFailed");
            validator.IsValid = true;
            validator.ErrorMessage = null;

            if (!AspNetMembershipService.IsUserValid(userName, password))
            {
                validator.IsValid = false;
                validator.ErrorMessage = AspNetMembershipService.GetUserInvalidReason(userName, password);
                return;
            }
            Session["CurrentUser"] = AspNetMembershipService.GetUser(userName);
            FormsAuthentication.RedirectFromLoginPage(userName, rememberMe.Checked);
        }
    }
}