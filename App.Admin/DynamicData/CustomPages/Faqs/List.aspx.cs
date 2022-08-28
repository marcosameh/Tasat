using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using Humanizer;

namespace DynamicData.Admin.CustomPages.Faqs
{
    public partial class List : ListPage
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
            GridDataSource.EntityTypeFilter = table.EntityType.Name;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName.Humanize();
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
            }
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
