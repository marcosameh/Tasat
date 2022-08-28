using DynamicData.Admin.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.Controls
{
    public partial class UserRoleSelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Add(new ListItem("[Not Set]", String.Empty));
        }


        public string SelectedRoleName
        {
            get { return DropDownList1.SelectedItem.Text; }
        }

        public string SelectedRole
        {
            get
            {
                return DropDownList1.SelectedValue;
            }
            set
            {
                DropDownList1.SelectedValue = value.ToString();
            }
        }

        public List<ListItem> LoadRoles()
        {
            IEnumerable<string> userRoles = new UserService().GetAllRoles();
            userRoles = userRoles.ToList().FindAll(x => x != "SuperAdmin");
            return userRoles.Select(x => new ListItem { Text = x, Value = x }).ToList();
        }
    }
}