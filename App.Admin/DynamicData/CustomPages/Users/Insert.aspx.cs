using DynamicData.Admin.Controls;
using DynamicData.Admin.Controls.Localized;
using DynamicData.Admin.DynamicData.FieldTemplates;
using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Infrastructure.UserMembership;
using DynamicData.Admin.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace DynamicData.Admin.CustomPages.Users
{
    public partial class Insert : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            FormView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
            DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName;
        }



        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void DetailsDataSource_Inserted(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceChangedEventArgs e)
        {
            if (e.Exception == null)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void DetailsDataSource_Inserting(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceChangingEventArgs e)
        {
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            try
            {
                var membershipUser = (FormView1.FindControl("MembershipUser") as Controls.MembershipUser);
                membershipUser.SaveUser();

                e.Cancel = true;
                Response.Redirect(table.ListActionPath);
            }
            catch (Exception ex)
            {
                (Master as Site).ShowMessage("Adding new user failed",
                   String.Format("Please correct this error (<strong>{0}</strong>) and try again.", ex.Message),
                   NotificationType.Error);
                e.Cancel = true;
            }
        }
    }
}
