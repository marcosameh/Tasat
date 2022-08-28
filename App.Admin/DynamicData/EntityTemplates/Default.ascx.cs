using Humanizer;
using System;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class DefaultEntityTemplate : System.Web.DynamicData.EntityTemplateUserControl
    {
        public class _NamingContainer : Control, INamingContainer { }

        protected override void OnLoad(EventArgs e)
        {
            foreach (MetaColumn column in Table.GetScaffoldColumns(Mode, ContainerType))
            {
                currentColumn = column;
                Control item = new _NamingContainer();

                EntityTemplate1.ItemTemplate.InstantiateIn(item);
                EntityTemplate1.Controls.Add(item);
            }
        }

        protected void Label_Init(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Text = currentColumn.DisplayName.Humanize2();
        }

        protected void DynamicControl_Init(object sender, EventArgs e)
        {
            DynamicControl dynamicControl = (DynamicControl)sender;
            dynamicControl.DataField = currentColumn.Name;
        }

        private MetaColumn currentColumn;
    }
}