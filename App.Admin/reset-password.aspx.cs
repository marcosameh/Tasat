using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Infrastructure.UserMembership;
using DynamicData.Admin.Model;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class reset_password : System.Web.UI.Page
    {
        private UserService userService;
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            userService = new UserService();

            if (Request["key"] != null && Request["UserId"] != null)
            {
                var key = new Guid(Request.QueryString["key"]);
                var userId = Convert.ToInt32(Request.QueryString["UserId"]);
                user = userService.GetUser(key, userId);
                if (user == null)
                {
                    //RedirectAndNotify(GetLocalizedUrl("/"), "Invalid link address", "Error", NotificationType.Error);
                }
                divNewPassword.Visible = true;
                divResetForm.Visible = false;
            }
            else
            {
                divNewPassword.Visible = false;
                divResetForm.Visible = true;
            }
        }

        protected void btnRequestResetLink_OnClick(object sender, EventArgs e)
        {
            try
            {
                userService.CreateResetPasswordRequest(txtEmail.Value, Request.Url.AbsoluteUri);
                ucNotifier.Show("Seccess", "Please Check Your Email", NotificationType.Success);
            }
            catch (Exception ex)
            {
                CustomValidator validator = (CustomValidator)Page.FindControl("cvLoginFailed");
                validator.IsValid = false;
                validator.ErrorMessage = ex.Message;
                return;
            }
        }


        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            CustomValidator validator = (CustomValidator)Page.FindControl("cvLoginFailed");
            if (IsRequestExpired())
            {
                validator.IsValid = false;
                validator.ErrorMessage = "Expired request";
                return;
            }
            if(password.Value!= confirm_password.Value)
            {
                validator.IsValid = false;
                validator.ErrorMessage = "Password not match";
                return;
            }
            try
            {
                userService.ResetPassword(user.Id, password.Value);
                MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
                if (userService.LogIn(membershipUser.Email, password.Value))
                {
                    Session["CurrentUser"] = membershipUser;
                    FormsAuthentication.RedirectFromLoginPage(membershipUser.Email, true);
                }
            }
            catch (Exception ex)
            {
                validator.IsValid = false;
                validator.ErrorMessage = ex.Message;
                return;
            }

        }
        private bool IsRequestExpired()
        {
            const int expireHours = 24;
            int resetRequestHours = (DateTime.Now).Subtract(user.PasswordResetTime.Value).Hours;
            return resetRequestHours > expireHours;
        }
    }
}