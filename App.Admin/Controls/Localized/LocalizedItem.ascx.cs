using DynamicData.Admin.Infrastructure;
using Humanizer;
using System;
using System.Web.DynamicData;
using System.Web.UI;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedItem : UserControl
    {
        public int ItemId
        {
            get { return Convert.ToInt32(ViewState["ItemId"]); }
            set { ViewState["ItemId"] = value; }
        }

        public int LanguageId
        {
            get { return Convert.ToInt32(ViewState["LanguageId"]); }
            set { ViewState["LanguageId"] = value; }
        }
        public string LanguageFriendlyName
        {
            get { return ViewState["LanguageFriendlyName"].ToString(); }
            set { ViewState["LanguageFriendlyName"] = value; }
        }


        private LocalizedControl localizedControl;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private LocalizedControl GetUserControl()
        {
            MetaTable table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

            var sigularName = table.Name.Singularize();
            var controlId = "Localized" + sigularName;
            return (LocalizedControl)FindControl(controlId);
        }
        private void BindData()
        {
            localizedControl = GetUserControl();
            if (localizedControl == null)
                return;
            int itemId = ItemId;
            if (itemId == 0)
                Int32.TryParse(Request.QueryString["Id"], out itemId);
            localizedControl.BindData(itemId, LanguageId, LanguageFriendlyName);
            localizedControl.Visible = true;
        }

        public void SaveData(int itemId)
        {
            localizedControl = GetUserControl();
            if (localizedControl == null)
                return;
            localizedControl.SaveData(itemId, LanguageId);
        }
    }
}