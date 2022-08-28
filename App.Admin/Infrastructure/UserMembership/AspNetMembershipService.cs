using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DynamicData.Admin.Infrastructure.UserMembership
{
    public class AspNetMembershipService
    {
        public static MembershipUser RegisterUser(string Email, string password)
        {
            MembershipCreateStatus createStatus;
            //create membership user
            MembershipUser newUser = Membership.CreateUser(Email,
                                                           password,
                                                           Email, null, null, false, out createStatus);

            //Roles.CreateRole("Admin");
            //Roles.AddUserToRole(Email, "Admin");

            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    return newUser;
                case MembershipCreateStatus.DuplicateUserName:
                    throw new Exception("Username already exists. Please enter a different user name.");

                case MembershipCreateStatus.DuplicateEmail:
                    throw new Exception("A username for that e-mail address already exists. Please enter a different e-mail address.");

                case MembershipCreateStatus.InvalidPassword:
                    throw new Exception("The password provided is invalid. Please enter a valid password value.");

                case MembershipCreateStatus.InvalidEmail:
                    throw new Exception("The e-mail address provided is invalid. Please check the value and try again.");

                case MembershipCreateStatus.InvalidUserName:
                    throw new Exception("The user name provided is invalid. Please check the value and try again.");

                case MembershipCreateStatus.ProviderError:
                    throw new Exception("The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.");

                case MembershipCreateStatus.UserRejected:
                    throw new Exception("The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.");

                default:
                    throw new Exception("An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.");
            }
        }

        //verify/activate user
        public static void VerifyUser(Guid id)
        {
            MembershipUser membershipUser = Membership.GetUser(id);
            membershipUser.IsApproved = true;
            Update(membershipUser);
            //FormsAuthentication.RedirectFromLoginPage(membershipUser.UserName, true);
        }

        public static void DeactivateUser(MembershipUser user)
        {
            user.IsApproved = false;
            Update(user);
        }

        //delete user
        public static void DeleteUser(MembershipUser user)
        {
            Membership.DeleteUser(user.UserName);
        }

        public static bool IsApproved(Guid userId)
        {
            MembershipUser membershipUser = Membership.GetUser(userId);
            return membershipUser.IsApproved;
        }

        public static bool IsLocked(string userName)
        {
            MembershipUser membershipUser = Membership.GetUser(userName);
            return membershipUser.IsLockedOut;
        }
        public static bool IsUserValid(string userName, string password)
        {
            if (Membership.ValidateUser(userName, password))
            {
                MembershipUser memberShipUser = Membership.GetUser(userName);
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                return true;
            }
            else
            {
                return false;
            }
        }

        //get user
        public static MembershipUser GetUser(string userName)
        {
            return Membership.GetUser(userName);
        }

        public static MembershipUser GetCurrentLoggedUser()
        {
            return Membership.GetUser(true);
        }

        public static MembershipUser GetUser(Guid userId)
        {
            return Membership.GetUser(userId);
        }

        public static void UnLockUser(Guid userId)
        {
            GetUser(userId).UnlockUser();
        }

        public static bool IsUserInRole(string userName, string roleName)
        {
            return Roles.IsUserInRole(userName, roleName);
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }

        //resetPassword
        internal static void ResetPassword(string userName, string newPassword)
        {
            var memberShipUser = GetUser(userName);
            var resetPassword = memberShipUser.ResetPassword();
            memberShipUser.ChangePassword(resetPassword, newPassword);
        }

        //change password by user
        public static bool UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            var memberShipUser = GetUser(userName);
            return memberShipUser.ChangePassword(oldPassword, newPassword);
        }

        public static string GetPassword(string userName)
        {
            var memberShipUser = GetUser(userName);
            return memberShipUser.GetPassword();
        }

        public static void Update(MembershipUser user)
        {
            Membership.UpdateUser(user);
        }


        public static string GetUserInvalidReason(string userName, string password)
        {
            if (IsUserValid(userName, password))
                return "";
            MembershipUser membershipUser = GetUser(userName);
            if (membershipUser == null)
                return "Wrong username, Please contact system admin";
            if (IsLocked(userName))
                return "Your account has been locked, Please contact system admin";
            if (!IsApproved((Guid)membershipUser.ProviderUserKey))
                return "Inactive account, Please contact system admin";
            else
                return "Wrong password, Please contact system admin";
        }
        
        //change email
    }
}
