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
    public partial class YandexMapField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        public override Control DataControl
        {
            get
            {
                return Label1;
            }
        }

        public string GetCoordinates(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var pointData = value.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            System.Data.Entity.Spatial.DbGeography mapCoordinates = System.Data.Entity.Spatial.DbGeography.PointFromText(pointData[1], int.Parse(pointData[0].Replace("SRID=", "")));
            return string.Format("Lat: {0}, Lng: {1}",
                mapCoordinates.Latitude, mapCoordinates.Longitude);
        }

    }
}