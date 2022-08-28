using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedHtmlField : System.Web.UI.UserControl
    {
        #region Properties

        public string DisplayName { get; set; }

        public string FieldName
        {
            set
            {
                lblFieldName.Text = value;
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldName#", value);
                cvMaxLength.ErrorMessage = cvMaxLength.ErrorMessage.Replace("#FieldName#", value);
            }
        }

        public string FieldValue
        {
            set
            {
                txtHtmlField.Text = value;
                lblFieldView.Text = Utility.Truncate(Server.HtmlDecode(value), 100);
            }
            get
            {
                return txtHtmlField.Text;
            }
        }


        private bool _fieldIsRequired;
        public bool FieldIsRequired
        {
            set
            {
                _fieldIsRequired = value;
            }
            get
            {
                return _fieldIsRequired;
            }
        }

        public int FieldMaxLength
        {
            set
            {
                ViewState["MaxLength"] = value;
                cvMaxLength.ErrorMessage = cvMaxLength.ErrorMessage.Replace("#MaxLength#", value.ToString());
                cvMaxLength.Enabled = true;
            }
        }

        /// <summary>
        /// FieldLanguage (Field LanguageFriendlyName)
        /// </summary>
        /// 
        private string _fieldLanguage;
        public string FieldLanguage
        {
            set
            {
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldLanguage#", value);
                cvMaxLength.ErrorMessage = cvMaxLength.ErrorMessage.Replace("#FieldLanguage#", value);
                _fieldLanguage = value;
            }
            get
            {
                return _fieldLanguage;
            }
        }

        public string RequiredLanguage { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DisplayName))
            {
                lblFieldName.Text = DisplayName;
            }
            //Is readonly?
            string requestPath = Request.Path.ToLower();
            bool isReadonly = requestPath.Contains("list.aspx") || requestPath.Contains("details.aspx");

            txtHtmlField.Visible = !isReadonly;
            lblFieldView.Visible = isReadonly;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RequiredLanguage) && _fieldIsRequired)
            {
                if (FieldLanguage == RequiredLanguage)
                {
                    rfvRequired.Enabled = true;
                    txtHtmlField.CssClass += " required";
                }
            }
            else
            {
                rfvRequired.Enabled = false;
            }
        }

        protected void cvMaxLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int maxLength = Convert.ToInt32(ViewState["MaxLength"]);

            args.IsValid = maxLength < 1 || (maxLength > 0 && txtHtmlField.Text.Length < maxLength);
        }
    }
}