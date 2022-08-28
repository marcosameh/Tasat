using DynamicData.Admin.Infrastructure.Services;
using DynamicData.Admin.Model;
using Humanizer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class List : ListPage
    {
        protected MetaTable table;
        private bool hideEditButton;
        private bool hideDeleteButton;
        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
            GridDataSource.EntityTypeFilter = table.EntityType.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName.Humanize2();
            GridDataSource.Include = table.ForeignKeyColumnsNames;
            // Disable various options if the table is readonly
            if (table.IsReadOnly)
            {
                GridView1.Columns[0].Visible = false;
                InsertHyperLink.Visible = false;
                GridView1.EnablePersistedSelection = false;
            }

            //Apply sort order as specified by OrderBy Attribute on the entity
            foreach (var item in table.Attributes)
            {
                if (item is DisableActionsAttribute)
                {
                    var disableInsert = ((DisableActionsAttribute)item).DisableInsert;
                    var disableEdit = ((DisableActionsAttribute)item).DisableEditing;
                    var disableDelete = ((DisableActionsAttribute)item).DisableDelete;

                    if (disableInsert)
                    {
                        InsertHyperLink.Visible = false;
                    }

                    if (disableEdit)
                    {
                        hideEditButton = true;
                    }

                    if (disableDelete)
                    {
                        hideDeleteButton = true;
                    }
                }
                if (item is OrderByAttribute)
                {
                    var attr = (OrderByAttribute)item;
                    GridDataSource.OrderBy = string.Format("It.{0} {1}",
                        attr.ColumnName,
                        attr.DescendingOrder ? "desc" : "");
                }
                else if (item is DataTableAttribute)
                {
                    var attr = (DataTableAttribute)item;
                    if (attr.RenderDataTable == false)
                    {
                        GridView1.CssClass = "table table-primary mb30 responsive";
                        GridView1.AllowPaging = GridView1.AllowSorting = true;
                    }
                }
                else if (item is MembershipAttribute)
                {
                    var attr = (MembershipAttribute)item;
                    GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
                    GridView1.RowDeleting += new GridViewDeleteEventHandler(GridView1_RowDeleting);
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (hideDeleteButton)
                {
                    var btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                    if (btnDelete != null)
                    {
                        btnDelete.Visible = false;
                    }
                }

                if (hideEditButton)
                {
                    var btnEdit = (DynamicHyperLink)e.Row.FindControl("btnEdit");
                    if (btnEdit != null)
                    {
                        btnEdit.Visible = false;
                    }
                }

                var td = e.Row.DataItem as ICustomTypeDescriptor;
                if (td != null)
                {
                    object currentRow = td.GetPropertyOwner(null);
                    System.Reflection.PropertyInfo pi = currentRow.GetType().GetProperty("AspNetUserId");
                    if (pi != null)
                    {
                        User user = new UserService().GetUser((Guid)(pi.GetValue(currentRow, null)));
                        if (user.FirstRole == "SuperAdmin")
                            e.Row.Visible = false;
                        if (user.Locked)
                        {
                            e.Row.BackColor = Color.LightGray;
                            LinkButton lnkUnLock = (LinkButton)e.Row.FindControl("lnkUnLock");
                            lnkUnLock.Visible = true;
                            lnkUnLock.CommandArgument = user.Id.ToString();
                        }
                    }
                }
            }
        }

        protected void lnkUnLock_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "UnLock")
            {
                new UserService().UnLockUser(Convert.ToInt32(e.CommandArgument));
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid userId = (Guid)(e.Keys["AspNetUserId"]);
            new UserService().Delete(userId);

            //e.Cancel = true;
            //GridView1.DataBind();
            //GridView1.EditIndex = -1;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (FilterRepeater.HasControls() == false)
            {
                rptFilters.Visible = false;
            }
        }

        protected void Label_PreRender(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
            QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
            if (fuc != null && fuc.FilterControl != null)
            {
                label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
            InsertHyperLink.NavigateUrl = table.GetActionPath(PageAction.Insert, routeValues);
            base.OnPreRenderComplete(e);
        }

        protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            RenderGridHeaderRow(e);
        }
    }
}