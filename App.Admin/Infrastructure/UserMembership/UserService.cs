using DynamicData.Admin.Infrastructure.UserMembership;
using DynamicData.Admin.Model;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RazorEngine.Templating;
using DynamicData.Admin.DTO;
using DynamicData.Admin.Infrastructure.MailSetting;

namespace DynamicData.Admin.Infrastructure.Services
{
    public class UserService
    {
        private AdminEntities dbAdmin;
        public UserService()
        {
            dbAdmin = new AdminEntities();
        }

        public User CreateUser(string Email, string password)
        {
            MembershipUser membershipUser = null;
            try
            {
                membershipUser = AspNetMembershipService.RegisterUser(Email, password);
                User user=new User
                {
                    AspNetUserId= (Guid)membershipUser.ProviderUserKey
                };

                dbAdmin.Users.Add(user);
                dbAdmin.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                if (membershipUser != null)
                    AspNetMembershipService.DeleteUser(membershipUser);
                throw ex;
            }
        }

        public void VerifyUser(Guid AspNetUserId)
        {
            AspNetMembershipService.VerifyUser(AspNetUserId);
        }

        public User GetUser(int id)
        {
            return dbAdmin.Users.First(x => x.Id == id);
        }

        public User GetUser(string userName)
        {
            MembershipUser user = AspNetMembershipService.GetUser(userName);
            return dbAdmin.Users.First(x => x.AspNetUserId == (Guid)user.ProviderUserKey);
        }

        public User GetUser(Guid passwordResetKey, int userId)
        {
            return dbAdmin.Users.First(x => x.Id == userId && x.PasswordResetKey == passwordResetKey);
        }

        public User GetUser(Guid AspNetUserId)
        {
            return dbAdmin.Users.First(x => x.AspNetUserId == AspNetUserId);
        }

        public bool LogIn(string userName, string password)
        {
            if (AspNetMembershipService.IsUserValid(userName, password))
            {
                return true;
            }
            else
                return false;
        }

        private DateTime GetUserCreationDate(int userId)
        {
            User user = GetUser(userId);
            MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            return membershipUser.CreationDate;
        }


        public bool IsAdmin(User user)
        {
            MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            return AspNetMembershipService.IsUserInRole(membershipUser.Email, "Admin");
        }


        public void ResetPassword(int userId, string newPassword)
        {
            User user = GetUser(userId);
            MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            AspNetMembershipService.ResetPassword(membershipUser.Email, newPassword);

            user.PasswordResetKey = null;
            user.PasswordResetTime = null;
            dbAdmin.SaveChanges();
        }

        public List<string> GetUserRole(string username)
        {
            return Roles.GetRolesForUser(username).ToList();
        }

        public List<string> GetAllRoles()
        {
            return Roles.GetAllRoles().ToList();
        }

        public void ChangeCurrentUserPassword(string oldPassword, string password)
        {
            MembershipUser membershipUser = AspNetMembershipService.GetCurrentLoggedUser();
            membershipUser.ChangePassword(oldPassword, password);
        }

        public void Modify(int userId, string password, bool active, string roleName)
        {
            User updateUser = GetUser(userId);
            MembershipUser membershipUser = AspNetMembershipService.GetUser(updateUser.AspNetUserId);

            //Update User password
            if (!String.IsNullOrEmpty(password))
            {
                string oldPassword = membershipUser.GetPassword();
                if (oldPassword != password)
                    membershipUser.ChangePassword(oldPassword, password);
            }
            //lock user
            if (!active)
                AspNetMembershipService.DeactivateUser(membershipUser);
            else if (active && !membershipUser.IsApproved)
                AspNetMembershipService.VerifyUser(updateUser.AspNetUserId);

            Roles.RemoveUserFromRole(membershipUser.UserName, updateUser.FirstRole);
            Roles.AddUserToRole(membershipUser.UserName, roleName);

            dbAdmin.SaveChanges();
        }

        public void Delete(int userId)
        {
            User user = GetUser(userId);

            MembershipUser aspUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            AspNetMembershipService.DeleteUser(aspUser);

            dbAdmin.Users.Remove(user);
            dbAdmin.SaveChanges();
        }

        public void Delete(Guid aspUserId)
        {
            User user = GetUser(aspUserId);

            MembershipUser aspUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            AspNetMembershipService.DeleteUser(aspUser);

            dbAdmin.Users.Remove(user);
            dbAdmin.SaveChanges();
        }

        public void UnLockUser(int userId)
        {
            User user = GetUser(userId);
            AspNetMembershipService.UnLockUser(user.AspNetUserId);
        }

        public bool IsCurrentUserAdmin()
        {
            MembershipUser membershipUser = AspNetMembershipService.GetCurrentLoggedUser();
            if (membershipUser == null)
                return false;
            if (AspNetMembershipService.IsUserInRole(membershipUser.UserName, "SuperAdmin"))
                return true;
            else if (AspNetMembershipService.IsUserInRole(membershipUser.UserName, "Admin"))
                return true;
            return false;
        }

        public void CreateResetPasswordRequest(string email, string absoluteUri)
        {
            var memberShipUser = AspNetMembershipService.GetUser(email);
            if (memberShipUser == null)
                throw new Exception("Invalid Email");
            User user = GetUser(new Guid(memberShipUser.ProviderUserKey.ToString()));

            var resetKey = Guid.NewGuid();
            user.PasswordResetKey = resetKey;
            user.PasswordResetTime = DateTime.Now;

            dbAdmin.SaveChanges();

            SendResetPasswordMail(resetKey, user, absoluteUri);
        }

        private void SendResetPasswordMail(Guid resetKey, User user, string absoluteUri)
        {
            MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            var resetPasswordModel = new UserModel()
            {
                Email = membershipUser.Email,
                ResetPasswordLink = new Uri(absoluteUri).Host + "/reset-password.aspx?key=" + resetKey + "&UserId=" + user.Id
            };

            var mailTemplate = System.IO.File.OpenText(
                    HttpContext.Current.Server.MapPath("~/App_Data/reset-password.cshtml")).ReadToEnd();

            Engine.Razor.AddTemplate("ResetPasswordTemplate", mailTemplate);

            var mailBody = Engine.Razor.RunCompile(mailTemplate, "ResetPassword", resetPasswordModel.GetType(), resetPasswordModel);

            ElasticMailService mailService = new ElasticMailService();
            Email email = new Email
            {
                To = membershipUser.Email,
                Subject = "Reset Password",
                Body = mailBody
            };
            mailService.Send(email);
        }


        public void SendPasswordByMail(User user, string absoluteUri, string password)
        {
            MembershipUser membershipUser = AspNetMembershipService.GetUser(user.AspNetUserId);
            var sendPasswordModel = new UserModel()
            {
                Email = membershipUser.Email,
                Password = password,
                LoginLink = new Uri(absoluteUri).Host + "/login.aspx"
            };

            var mailTemplate = System.IO.File.OpenText(
                    HttpContext.Current.Server.MapPath("~/App_Data/send-password.cshtml")).ReadToEnd();

            Engine.Razor.AddTemplate("SendPasswordTemplate", mailTemplate);

            var mailBody = Engine.Razor.RunCompile(mailTemplate, "SendPassword", sendPasswordModel.GetType(), sendPasswordModel);

            ElasticMailService mailService = new ElasticMailService();
            Email email = new Email
            {
                To = membershipUser.Email,
                Subject = "Your Admin Account Information",
                Body = mailBody
            };
            mailService.Send(email);
        }
    }
}
