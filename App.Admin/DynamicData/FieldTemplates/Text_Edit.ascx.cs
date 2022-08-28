using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class Text_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {

        protected void Page_PreRender(object sender, EventArgs e)
        {
            TextBox1.MaxLength = Column.MaxLength;
            if (Column.MaxLength < Convert.ToInt32(WebConfigurationManager.AppSettings["AutoMultiLineTextLength"]))
                TextBox1.Columns = Column.MaxLength;
            TextBox1.ToolTip = Column.Description;

            SetupTextArea();
            SetupReadonly();
            SetupHtmlAttribute();
            SetupUrl();
            SetupEMail();
            SetupPageNameAttribute();
            SetupHintAttribute();

            //SetUpValidator(rfv1);
            //SetUpValidator(rev1);
            //SetUpValidator(dv1);

            if (Column.IsRequired)
            {
                TextBox1.CssClass += " required";
                rfv1.ErrorMessage = Column.DisplayName + " is required";
                rfv1.Enabled = true;
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (Column.MaxLength > 0)
            {
                TextBox1.MaxLength = Math.Max(FieldValueEditString.Length, Column.MaxLength);
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }

        private void SetupPageNameAttribute()
        {
            var metadata = MetadataAttributes.OfType<PageNameAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                TextBox1.CssClass += " pageName";
            }
        }
        private void SetupHintAttribute()
        {
            var metadata = MetadataAttributes.OfType<HintAttribute>().FirstOrDefault();
            lblHintIcon.Visible = false;

            if (metadata != null)
            {
                if (metadata.Hint.Length > 0)
                {
                    lblHintIcon.Visible = lblHint.Visible = true;
                    lblHint.Text = metadata.Hint;
                }
            }
        }
        protected void SetupTextArea()
        {
            if (MetadataAttributes.OfType<MultiLineAttribute>().FirstOrDefault() != null)
                SetMultiLineText();
            else if (Column.MaxLength > Convert.ToInt32(WebConfigurationManager.AppSettings["AutoMultiLineTextLength"]))
                SetMultiLineText();
        }
        protected void SetMultiLineText()
        {
            TextBox1.TextMode = TextBoxMode.MultiLine;
            TextBox1.Attributes["style"] = "width:500px;height:75px;";

            revMax.Text = String.Format("{0}, max length is ({1})", Column.Name, Column.MaxLength);
            revMax.ErrorMessage = revMax.Text;
            revMax.ValidationExpression = @"^[\s\S]{0," + Column.MaxLength + "}$";
            revMax.Enabled = true;

            SetUpValidator(revMax);
        }

        protected void SetupReadonly()
        {
            if (MetadataAttributes.OfType<ReadonlyAttribute>().FirstOrDefault() != null)
            {
                TextBox1.Visible = false;
                Label1.Visible = true;
            }
        }

        private void SetupHtmlAttribute()
        {
            var metadata = MetadataAttributes.OfType<HtmlAttributeAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                if (metadata.HtmlAttributeMode == HtmlAttributeModes.Both)
                {
                    Label1.Attributes[metadata.Key] = metadata.Value;
                    TextBox1.Attributes[metadata.Key] = metadata.Value;
                }
                else if (metadata.HtmlAttributeMode == HtmlAttributeModes.ViewOnly)
                    Label1.Attributes[metadata.Key] = metadata.Value;
                else if (metadata.HtmlAttributeMode == HtmlAttributeModes.EditOnly)
                    TextBox1.Attributes[metadata.Key] = metadata.Value;

            }
        }

        private void SetupUrl()
        {
            var metadata = MetadataAttributes.OfType<UrlAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                rev1.ValidationExpression = @"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?";
                rev1.ErrorMessage = "Invalid internet URL.";
                rev1.Enabled = true;
            }
        }
        private void SetupEMail()
        {
            var metadata = MetadataAttributes.OfType<EmailAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                rev1.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                rev1.ErrorMessage = "Invalid e-mail address.";
                rev1.Enabled = true;
            }
        }

        private string WellFormedUrl(string url)
        {
            var metadata = MetadataAttributes.OfType<UrlAttribute>().FirstOrDefault();

            if (metadata != null && !String.IsNullOrEmpty(url))
                if (!(url.Contains("https://") || url.Contains("http://")))
                    return "http://" + url;

            return url;
        }

        public string BrToCRLF(string text)
        {
            return text.Replace("<br/>", "\r\n");
        }
        public string CRLFToBr(string text)
        {
            return text.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        }
        public override Control DataControl
        {
            get
            {
                return TextBox1;
            }
        }

    }
}
