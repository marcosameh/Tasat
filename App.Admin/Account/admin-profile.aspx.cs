using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class admin_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Update password button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //hide, in case of old messages.
            //errorMessage.Visible = false;
            //successMessage.Visible = false;

            //validation
            if (String.IsNullOrEmpty(txtCurrentPassword.Value.Trim()) ||
                String.IsNullOrEmpty(txtNewPassword.Value.Trim()) ||
                String.IsNullOrEmpty(txtRetypeNewPassword.Value.Trim()))
            {
                //error message: all fields are required.
                errorConatiner.Visible = true;
                errorMessage.InnerText = "All fields are required, please enter missing data.";                
                return;
            }

            
            if (!String.Equals(txtNewPassword.Value, txtRetypeNewPassword.Value))
            {
                //error message: new password fields should match.
                errorConatiner.Visible = true;
                errorMessage.InnerText = "New password fields should match.";
                
                return;
            }

            //AdminEntities db = new AdminEntities();
            //var adminPasswordSetting = db.Settings.Where(x => x.Key == "AdminPassword").First();
            //string decodedPassword = AccountUtility.DecodePassword(adminPasswordSetting.Value);

            //if (!String.Equals(txtCurrentPassword.Value,decodedPassword))
            //{
            //    //error message: current password is not correct.
            //    errorConatiner.Visible = true;
            //    errorMessage.InnerText = "Current password you entered does not seem to be your current password.";
                
            //    return;
            //}
            try
            {
                new UserService().ChangeCurrentUserPassword(txtCurrentPassword.Value, txtNewPassword.Value);
                //adminPasswordSetting.Value = AccountUtility.EncodePassword(txtNewPassword.Value);
                //db.SaveChanges();

                //password changed successfully message
                successMessage.InnerText = "Your password has been updated successfully! You can start using it the next time you login.";
                successContainer.Visible = true;
                errorConatiner.Visible = false;
            }
            catch (Exception ex)
            {
                //error message: current password is not correct.
                errorMessage.InnerText = "Password couldn't be updated, because of the following error:"+ex.Message;
                errorConatiner.Visible = true;
                return;
            }
        }

        
       
    }
}