using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedField : System.Web.UI.UserControl
    {
        #region Properties
        private string _fieldName;
        public string FieldName
        {
            set
            {
                _fieldName = value;
                lblFieldName.Text = value;
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldName#", value);
                revMaxLength.ErrorMessage = revMaxLength.ErrorMessage.Replace("#FieldName#", value);
            }
            get
            {
                return _fieldName;
            }
        }

        public string FieldValue
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    txtFieldEdit.Text = value.Replace("<br/>", "\r\n");
                    lblFieldView.Text = Utility.Truncate(value, 100);
                }
            }
            get
            {
                return txtFieldEdit.Text.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
            }
        }

        public bool PageName { get; set; }
        private bool _fieldIsRequired;
        public bool FieldIsRequired
        {
            get
            {
                return _fieldIsRequired;
            }
            set
            {
                _fieldIsRequired = value;
            }
        }

        public int FieldMaxLength
        {
            set
            {
                txtFieldEdit.Attributes["maxLength"] = value.ToString();

                //Is multiline?
                if (value > Convert.ToInt32(WebConfigurationManager.AppSettings["AutoMultiLineTextLength"]))
                {
                    txtFieldEdit.TextMode = TextBoxMode.MultiLine;
                    txtFieldEdit.Attributes["style"] = "height:100px;";

                    revMaxLength.ValidationExpression = revMaxLength.ValidationExpression.Replace("#MaxLength#", value.ToString());
                    revMaxLength.ErrorMessage = revMaxLength.ErrorMessage.Replace("#MaxLength#", value.ToString());
                    revMaxLength.Enabled = true;
                }
            }
        }

        /// <summary>
        /// FieldLanguage (Field LanguageFriendlyName)
        /// </summary>
        private string _fieldLanguage;
        public string FieldLanguage
        {
            set
            {
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldLanguage#", value);
                revMaxLength.ErrorMessage = revMaxLength.ErrorMessage.Replace("#FieldLanguage#", value);
                _fieldLanguage = value;
            }
            get
            {
                return _fieldLanguage;
            }
        }

        public string RequiredLanguage { get; set; }
        public bool FieldMultiline
        {
            set
            {
                txtFieldEdit.TextMode = value ? TextBoxMode.MultiLine : TextBoxMode.SingleLine;
                txtFieldEdit.Attributes["style"] = "height:100px;";
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Is readonly?
            string requestPath = Request.Path.ToLower();
            bool isReadonly = requestPath.Contains("list.aspx") || requestPath.Contains("details.aspx");

            txtFieldEdit.Visible = !isReadonly;
            lblFieldView.Visible = isReadonly;
        }
        public string FieldHint
        {
            set
            {
                lblFieldHint.Text = value;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RequiredLanguage) && _fieldIsRequired)
            {
                if (FieldLanguage == RequiredLanguage)
                {
                    rfvRequired.Enabled = true;
                    txtFieldEdit.CssClass += " required";
                }
            }
            else
            {
                rfvRequired.Enabled = false;
            }
            SetupPageNameAttribute();
        }

        private void SetupPageNameAttribute()
        {
            if (PageName)
            {
                txtFieldEdit.Attributes["onblur"] = string.Format("validatePageName('{0}')", txtFieldEdit.ClientID);
            }
        }
    }
}