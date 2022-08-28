using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Linq;
using System.Globalization;

namespace DynamicData.Admin
{
    public partial class DateTime_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        private static DataTypeAttribute DefaultDateAttribute = new DataTypeAttribute(DataType.DateTime);
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ToolTip = Column.Description;

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(RegularExpressionValidator1);
            // SetUpValidator(DynamicValidator1);
            // SetUpCustomValidator(DateValidator);
            if (Column.IsRequired)
                TextBox1.CssClass += " required";
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            SetupDateTime(FieldValue);
        }

        private void SetUpCustomValidator(CustomValidator validator)
        {
            if (Column.DataTypeAttribute != null)
            {
                switch (Column.DataTypeAttribute.DataType)
                {
                    case DataType.Date:
                    case DataType.DateTime:
                    case DataType.Time:
                        validator.Enabled = true;
                        DateValidator.ErrorMessage = HttpUtility.HtmlEncode(Column.DataTypeAttribute.FormatErrorMessage(Column.DisplayName));
                        break;
                }
            }
            else if (Column.ColumnType.Equals(typeof(DateTime)))
            {
                validator.Enabled = true;
                DateValidator.ErrorMessage = HttpUtility.HtmlEncode(DefaultDateAttribute.FormatErrorMessage(Column.DisplayName));
            }
        }

        protected void DateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dummyResult;
            args.IsValid = DateTime.TryParse(args.Value, out dummyResult);
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            string DateTimeEditFormat = WebConfigurationManager.AppSettings["DateTimeEditFormat"];

            var metadata = MetadataAttributes.OfType<AutoGenerateAttribute>().FirstOrDefault();
            if (metadata != null)
            {
                AutoGenerateModes autoGenerateMode = metadata.AutoGenerateMode;

                if (autoGenerateMode == AutoGenerateModes.Once && TextBox1.Text != "(Auto Generated)")
                    dictionary[Column.Name] = DateTime.Parse(TextBox1.Text);
                else //AutoGenerateModes.EveryTime
                    dictionary[Column.Name] = DateTime.Now;
            }
            else
            {

                DateTime dateTime;
                if (DateTime.TryParseExact(TextBox1.Text, DateTimeEditFormat, CultureInfo.CreateSpecificCulture("en-GB"), DateTimeStyles.None, out dateTime))
                    dictionary[Column.Name] = dateTime.ToShortDateString();
                else
                    dictionary[Column.Name] = null;
            }
            //dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }


        public override Control DataControl
        {
            get
            {
                return TextBox1;
            }
        }

        protected void SetupDateTime(object fieldValue)
        {
            string DateTimeEditFormat = WebConfigurationManager.AppSettings["DateTimeEditFormat"];

            var metadataAutoGenerate = MetadataAttributes.OfType<AutoGenerateAttribute>().FirstOrDefault();
            var metadataReadonly = MetadataAttributes.OfType<ReadonlyAttribute>().FirstOrDefault();

            if (metadataAutoGenerate != null || metadataReadonly != null)
            {
                if (fieldValue != null)
                    lblHint.Text = TextBox1.Text = ((System.DateTime)fieldValue).ToString(DateTimeEditFormat);
                else
                    lblHint.Text = TextBox1.Text = "(Auto Generated)";

                TextBox1.Visible = false;
                lblHint.Visible = lblHintIcon.Visible = true;
            }
            else
            {
                if (fieldValue != null)
                    TextBox1.Text = ((System.DateTime)fieldValue).ToString(DateTimeEditFormat);
            }
        }

    }
}
