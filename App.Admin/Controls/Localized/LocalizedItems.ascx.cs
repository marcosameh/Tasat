using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicData.Admin.Model;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedItems : System.Web.UI.UserControl
    {
        public int ItemId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void SaveData(int ItemId)
        {
            foreach (ListViewDataItem repeaterItem in lvControls.Items)
            {
                LocalizedItem localizedItem = (LocalizedItem)repeaterItem.FindControl("ucLocalizedItem");
                localizedItem.SaveData(ItemId);
            }
        }
    }
}