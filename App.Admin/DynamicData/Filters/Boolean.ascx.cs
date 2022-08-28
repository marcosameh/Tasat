using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{

    public partial class BooleanFilter : System.Web.DynamicData.QueryableFilterUserControl
    {
        private const string NullValueString = "[null]";
        public override Control FilterControl
        {
            get
            {
                return ddlBool;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Column.ColumnType.Equals(typeof(bool)))
            {
                throw new InvalidOperationException(String.Format("A boolean filter was loaded for column '{0}' but the column has an incompatible type '{1}'.", Column.Name, Column.ColumnType));
            }

            if (!Page.IsPostBack)
            {
                PopulateList();
                // Set the initial value if there is one
                string initialValue = DefaultValue;
                if (!String.IsNullOrEmpty(initialValue))
                {
                    ddlBool.SelectedValue = initialValue;
                }
            }

        }

        private void PopulateList()
        {
            ddlBool.Items.Add(new ListItem("All", String.Empty));
            if (!Column.IsRequired)
            {
                ddlBool.Items.Add(new ListItem("[Not Set]", NullValueString));
            }
            ddlBool.Items.Add(new ListItem("True", Boolean.TrueString));
            ddlBool.Items.Add(new ListItem("False", Boolean.FalseString));
        }

        public override IQueryable GetQueryable(IQueryable source)
        {
            string selectedValue = Request.Form[ddlBool.UniqueID];
            if (String.IsNullOrEmpty(selectedValue))
            {
                ddlBool.Items.Clear();
                PopulateList();
                return source;
            }

            object value = selectedValue;
            if (selectedValue == NullValueString)
            {
                value = null;
            }
            if (DefaultValues != null)
            {
                DefaultValues[Column.Name] = value;
            }


            ddlBool.Items.Clear();
            PopulateList();
            ddlBool.SelectedValue = Request.Form[ddlBool.UniqueID];


            return ApplyEqualityFilter(source, Column.Name, value);
        }

        protected void ddlBool_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
            ddlBool.Items.Clear();
            PopulateList();
            ddlBool.SelectedValue = Request.Form[ddlBool.UniqueID];
        }

    }
}
