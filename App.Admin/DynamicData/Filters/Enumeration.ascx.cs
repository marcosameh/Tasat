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
    public partial class EnumerationFilter : System.Web.DynamicData.QueryableFilterUserControl
    {
        private const string NullValueString = "[null]";
        public override Control FilterControl
        {
            get
            {
                return ddlEnum;
            }
        }

        public void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateList();
                // Set the initial value if there is one
                string initialValue = DefaultValue;
                if (!String.IsNullOrEmpty(initialValue))
                {
                    ddlEnum.SelectedValue = initialValue;
                }
            }
        }

        private void PopulateList()
        {
            ddlEnum.Items.Clear();
            ddlEnum.Items.Add(new ListItem("All", String.Empty));

            if (!Column.IsRequired)
            {
                ddlEnum.Items.Add(new ListItem("[Not Set]", NullValueString));
            }
            PopulateListControl(ddlEnum);
        }

        public override IQueryable GetQueryable(IQueryable source)
        {
            string selectedValue = Request.Form[ddlEnum.UniqueID];
            if (String.IsNullOrEmpty(selectedValue))
            {
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
            PopulateList();
            ddlEnum.SelectedValue = Request.Form[ddlEnum.UniqueID];
            return ApplyEqualityFilter(source, Column.Name, value);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

    }
}
