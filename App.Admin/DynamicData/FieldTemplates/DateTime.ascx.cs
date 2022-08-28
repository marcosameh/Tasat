using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web.Configuration;

namespace DynamicData.Admin
{
    public partial class DateTimeField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            SetupDisplayFormat(FieldValue);
        }

        public override Control DataControl
        {
            get
            {
                return litDate;
            }
        }

        private void SetupDisplayFormat(object fieldValue)
        {
            if (fieldValue != null)
            {
                var metadata = MetadataAttributes.OfType<DisplayFormatAttribute>().FirstOrDefault();

                if (metadata == null)
                {
                    litDate.Text = ((System.DateTime)fieldValue).ToString(WebConfigurationManager.AppSettings["DateTimeDisplayFormat"]);
                }
            }
        }

    }
}
