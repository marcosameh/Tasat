using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class DbGeography_Edit : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Entity.Spatial.DbGeography geo;
        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            //object val = location.Text;            
            //geo = ((System.Data.Spatial.DbGeography)val);
            //dictionary[Column.Name] = System.Data.Spatial.DbGeography.FromText(location.Text);

            //string[] latLongStr = location.Text.Split(',');
            //string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            ////4326 format puts LONGITUDE first then LATITUDE
            //System.Data.Spatial.DbGeography result = System.Data.Spatial.DbGeography.FromText(point, 4326);
            //dictionary[Column.Name] = result;
            dictionary[Column.Name] = location.Text;

        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            geo = FieldValue as System.Data.Entity.Spatial.DbGeography;
            if (geo != null)
            {
                location.Text = geo.Latitude.Value.ToString("G", CultureInfo.InvariantCulture) + "," + geo.Longitude.Value.ToString("G", CultureInfo.InvariantCulture);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override Control DataControl
        {
            get
            {
                return location;
            }
        }
    }
}