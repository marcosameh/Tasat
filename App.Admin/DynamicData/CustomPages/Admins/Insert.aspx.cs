using DynamicData.Admin.Controls;
using DynamicData.Admin.Controls.Localized;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace DynamicData.Admin.CustomPages.Admins
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
            }
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            var membershipUser = (FormView1.FindControl("MembershipUser") as MembershipUser);
            membershipUser.SaveUser();
            e.Values["AspNetUserId"] = membershipUser.AspNetId;
        }
    }
}
