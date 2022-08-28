using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedFileUploadField : System.Web.UI.UserControl
    {
        #region Properties
        public string FieldName
        {
            set
            {
                lblFieldName.Text = value;
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldName#", value);
            }
        }

        public HttpPostedFile FieldValue
        {
            get
            {
                return uplFileUploadField.PostedFile;
            }
        }

        public bool FieldIsRequired
        {
            set
            {
                rfvRequired.Enabled = value;
            }
        }

        public string UploadFolder { get; set; }

        string _filePath;
        public string FileName
        {
            get
            {
                return Path.GetFileName(_filePath);
            }
            set
            {
                _filePath = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FrontendVirtualPath"], UploadFolder, value);
                lnkFieldView.NavigateUrl = _filePath;
                lnkFieldView.Text = value;
            }
        }

        /// <summary>
        /// FieldLanguage (Field LanguageFriendlyName)
        /// </summary>
        public string FieldLanguage
        {
            set
            {
                rfvRequired.ErrorMessage = rfvRequired.ErrorMessage.Replace("#FieldLanguage#", value);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Is readonly?
            string requestPath = Request.Path.ToLower();
            uplFileUploadField.Visible = requestPath.Contains("insert.aspx") || requestPath.Contains("edit.aspx");
            lnkFieldView.Visible = (requestPath.Contains("list.aspx") || requestPath.Contains("details.aspx") || requestPath.Contains("edit.aspx"));
            if (!string.IsNullOrEmpty(_filePath))
            {
                lnkFieldView.NavigateUrl = _filePath;
            }
        }

        public bool SaveFile()
        {
            try
            {
                string savePath = string.Format("{0}{1}\\{2}", ConfigurationManager.AppSettings["FrontendPhysicalPath"], UploadFolder, Path.GetFileName(uplFileUploadField.PostedFile.FileName));
                _filePath = string.Format("{0}{1}/{2}", ConfigurationManager.AppSettings["FrontendPhysicalPath"], UploadFolder, Path.GetFileName(uplFileUploadField.PostedFile.FileName));
                uplFileUploadField.PostedFile.SaveAs(savePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}