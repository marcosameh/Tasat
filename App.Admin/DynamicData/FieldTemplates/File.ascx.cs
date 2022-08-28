using System;
using System.Linq;
using System.Web.UI;

namespace DynamicData.Admin
{
    public partial class FileField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            if (!String.IsNullOrEmpty(FieldValueString))
            {
                var metadata = MetadataAttributes.OfType<FileAttribute>().FirstOrDefault();

                if (metadata != null)
                {
                    HyperLink1.NavigateUrl = Setting.FrontendVirtualPath + metadata.Path + FieldValueString;
                    HyperLink1.Visible = true;
                }
            }
        }

        public override Control DataControl
        {
            get
            {
                return HyperLink1;
            }
        }
    }
}