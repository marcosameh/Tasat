using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using Humanizer;
using DynamicData.Admin.Controls;
using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Model;
using System.Web.UI.HtmlControls;

namespace DynamicData.Admin.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        protected MetaTable table;
        
        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            FormView1.SetMetaTable(table);
            DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName;
            DetailsDataSource.Include = table.ForeignKeyColumnsNames;
        }
        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            //Update user
            try
            {
                MembershipUser membershipUser = (FormView1.FindControl("MembershipUser") as MembershipUser);
                membershipUser.SaveUser(new Guid(e.CommandArgument.ToString()));
                e.Cancel = true;

                //Redirect back to list page
                Response.Redirect(table.ListActionPath);
            }
            catch (Exception ex)
            {
                e.Cancel = true;

                (Master as Site).ShowMessage("Edit user failed",
                    String.Format("Please correct this error (<strong>{0}</strong>) and try again.", ex.Message),
                    NotificationType.Error);
            }
            e.Cancel = true;
        }


       
    }
}
