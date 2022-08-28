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

namespace DynamicData.Admin
{
    public partial class YoutubeField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            if (!String.IsNullOrEmpty(FieldValueString))
            {
                Image1.ImageUrl = Utility.GetYoutubeThumbnail("http://www.youtube.com/watch?v=" + FieldValueString);
                HyperLink1.NavigateUrl = "http://www.youtube.com/watch?v=" + FieldValueString;
                // HyperLink1.ImageUrl = Utility.GetYoutubeThumbnail("http://www.youtube.com/watch?v=" + FieldValueString);
            }
        }

        public override Control DataControl
        {
            get
            {
                return Image1;
            }
        }
    }
}