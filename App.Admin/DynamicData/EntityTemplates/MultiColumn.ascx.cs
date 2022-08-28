using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.DynamicData.EntityTemplates
{
    public partial class MultiColumnEntityTemplate : System.Web.DynamicData.EntityTemplateUserControl
    {
        private const string COLUMNS = "Columns";
        private const string TITLE_CSS_CLASS = "TitleCssClass";
        private const string FIELD_CSS_CLASS = "FieldCssClass";

        protected override void OnLoad(EventArgs e)
        {
            // get columns from table
            var metaColumns = Table.GetScaffoldColumns(Mode, ContainerType).ToList();

            // do not render any HTML table if there are no columns returned
            if (metaColumns.Count == 0)
                return;

            // default the HTML table columns and CSS class names
            int columns = 2;
            String titleCssClass = String.Empty;
            String fieldCssClass = String.Empty;

            // Get the CssClass for the title & Field from the attribute
            var entityUHint = Table.GetAttribute<EntityUIHintAttribute>();
            if (entityUHint != null)
            {
                if (entityUHint.ControlParameters.Keys.Contains(COLUMNS))
                    columns = (int)entityUHint.ControlParameters[COLUMNS];
                if (entityUHint.ControlParameters.Keys.Contains(TITLE_CSS_CLASS))
                    titleCssClass = entityUHint.ControlParameters[TITLE_CSS_CLASS].ToString();
                if (entityUHint.ControlParameters.Keys.Contains(FIELD_CSS_CLASS))
                    fieldCssClass = entityUHint.ControlParameters[FIELD_CSS_CLASS].ToString();
            }

            // start in the left column
            int col = 0;

            string colCssCLass = "col-md-" + (columns / 12).ToString() + " ";

            // create the header & data cells
            var headerRow = new HtmlTableRow();
            if (!String.IsNullOrEmpty(titleCssClass))
                headerRow.Attributes.Add("class", "row " + titleCssClass);
            var dataRow = new HtmlTableRow();
            if (!String.IsNullOrEmpty(fieldCssClass))
                dataRow.Attributes.Add("class", colCssCLass + fieldCssClass);

            // step through each of the columns to be added to the table
            foreach (var metaColumn in metaColumns)
            {
                // get the MultiColumn attribute for the column
                var multiColumn = metaColumn.GetAttributeOrDefault<MultiColumnAttribute>();
                if (multiColumn.ColumnSpan > columns)
                    throw new InvalidOperationException(String.Format("MultiColumn attribute specifies that this field occupies {0} columns, but the EntityUIHint attribute for the class only allocates {1} columns in the HTML table.", multiColumn.ColumnSpan, columns));

                // check if there are sufficient columns left in the current row
                if (col + multiColumn.ColumnSpan > columns)
                {
                    // save this header row
                    this.Controls.Add(headerRow);
                    headerRow = new HtmlTableRow();
                    if (!String.IsNullOrEmpty(titleCssClass))
                        headerRow.Attributes.Add("class", "row " + titleCssClass);

                    // save this data row
                    this.Controls.Add(dataRow);
                    dataRow = new HtmlTableRow();
                    if (!String.IsNullOrEmpty(fieldCssClass))
                        dataRow.Attributes.Add("class", colCssCLass + fieldCssClass);

                    // need to start a new row
                    col = 0;
                }

                // add the header cell
                var th = new HtmlTableCell();
                var label = new Label();
                label.CssClass = "control-label";
                label.Text = metaColumn.DisplayName;
                //if (Mode != System.Web.UI.WebControls.DataBoundControlMode.ReadOnly)
                //    label.PreRender += Label_PreRender;

                th.InnerText = metaColumn.DisplayName;
                if (multiColumn.ColumnSpan > 1)
                    th.ColSpan = multiColumn.ColumnSpan;
                headerRow.Cells.Add(th);

                // add the data cell
                var td = new HtmlTableCell();
                var dynamicControl = new DynamicControl(Mode);
                dynamicControl.DataField = metaColumn.Name;
                dynamicControl.ValidationGroup = this.ValidationGroup;

                td.Controls.Add(dynamicControl);
                if (multiColumn.ColumnSpan > 1)
                    td.ColSpan = multiColumn.ColumnSpan;
                dataRow.Cells.Add(td);

                // record how many columns we have used
                col += multiColumn.ColumnSpan;
            }
            this.Controls.Add(headerRow);
            this.Controls.Add(dataRow);
        }
    }
}