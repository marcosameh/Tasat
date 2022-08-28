using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class YandexMap_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            SetupReadonly();
            SetupHintAttribute();

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);

            if (Column.IsRequired)
            {
                txtLatitude.CssClass += " required";
                txtLatitude.CssClass += " required";
            }
        }

        private void SetupHintAttribute()
        {
            var metadata = MetadataAttributes.OfType<HintAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                if (metadata.Hint.Length > 0)
                {
                    lblHint.Visible = true;
                    lblHint.Text = metadata.Hint;
                }
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            string point = "POINT(37.64 55.76)";
            if (hidLatitude.Value != "0")
            {
                point = string.Format("POINT({0} {1})", txtLongitude.Text, txtLatitude.Text);
            }
            else if (hidLatitude.Value == "0")
            {
                point = "POINT(37.64 55.76)";
            }
            dictionary[Column.Name] = DbSpatialServices.Default.GeographyFromText(point, 4326);
        }

        public override Control DataControl
        {
            get
            {
                return txtLatitude;
            }
        }

        protected void SetupReadonly()
        {
            if (MetadataAttributes.OfType<ReadonlyAttribute>().FirstOrDefault() != null)
            {
                txtZoomLevel.Visible = txtLongitude.Visible = txtLatitude.Visible = false;
                Label1.Visible = true;
            }
        }

        public string GetCoordinates(object value)
        {
            System.Data.Entity.Spatial.DbGeography point = value != null ? (System.Data.Entity.Spatial.DbGeography)value : DbSpatialServices.Default.GeographyFromText("POINT(37.64 55.76)", 4326);
            return string.Format("{0},{1}", point.Latitude, point.Longitude);
        }

        public string GetLat(object value)
        {
            System.Data.Entity.Spatial.DbGeography point = value != null ? (System.Data.Entity.Spatial.DbGeography)value : DbSpatialServices.Default.GeographyFromText("POINT(37.64 55.76)", 4326);

            hidLatitude.Value = point.Latitude.Value.ToString();
            return point.Latitude.Value.ToString();
        }

        public string GetLng(object value)
        {
            System.Data.Entity.Spatial.DbGeography point = value != null ? (System.Data.Entity.Spatial.DbGeography)value : DbSpatialServices.Default.GeographyFromText("POINT(37.64 55.76)", 4326);
            hidLongitude.Value = point.Longitude.Value.ToString();
            return point.Longitude.Value.ToString();
        }
    }
}