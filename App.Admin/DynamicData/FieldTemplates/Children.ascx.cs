using Humanizer;
using System;
using System.Web.UI;

namespace DynamicData.Admin
{
    public partial class ChildrenField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }

        public bool AllowNavigation
        {
            get
            {
                return _allowNavigation;
            }
            set
            {
                _allowNavigation = value;
            }
        }

        public override Control DataControl
        {
            get
            {
                return HyperLink1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink1.Text = "View " + ChildrenColumn.ChildTable.DisplayName.Humanize2();
        }

        protected string GetChildrenPath()
        {
            if (!AllowNavigation)
            {
                return null;
            }

            if (String.IsNullOrEmpty(NavigateUrl))
            {
                return ChildrenPath;
            }
            else
            {
                return BuildChildrenPath(NavigateUrl);
            }
        }

        private bool _allowNavigation = true;
        private string _navigateUrl;
    }
}