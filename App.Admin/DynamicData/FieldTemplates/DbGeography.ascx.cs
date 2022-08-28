using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class DbGeography : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Entity.Spatial.DbGeography geo;

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            geo = (System.Data.Entity.Spatial.DbGeography)(FieldValue);
            location.Text = geo.Latitude + "," + geo.Longitude;
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