using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

namespace DynamicData.Admin.DynamicData.FieldTemplates
{
    public partial class IconSelect_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (!String.IsNullOrEmpty(FieldValueString))
            {
                HtmlSelect select = ((System.Web.UI.HtmlControls.HtmlSelect)this.FindControl("ddlIcons"));
                select.Items.FindByValue(FieldValueString).Selected = true;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ddlIcons.Value.ToString();
        }

        public override Control DataControl
        {
            get
            {
                return hdnValue;
            }
        }
    }
}
