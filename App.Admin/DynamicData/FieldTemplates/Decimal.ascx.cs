using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class DecimalField : System.Web.DynamicData.FieldTemplateUserControl
    {
        

        public override string FieldValueString
        {
            get
            {

                if (string.IsNullOrEmpty(base.FieldValueString))
                {
                    return string.Empty;
                }
                return (Convert.ToDecimal(base.FieldValueString)).ToString("###,###,###.##");
            }
        }

        public override Control DataControl
        {
            get
            {
                return Literal1;
            }
        }

    }
}
