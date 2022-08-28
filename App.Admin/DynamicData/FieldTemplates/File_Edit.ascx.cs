using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelRedSea.Admin
{
    public partial class File_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            SetupHintAttribute();
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            if (!String.IsNullOrEmpty(FieldValueString))
            {
                string fileAttributePath = GetFileAttributePath();

                HyperLink1.NavigateUrl = Setting.FrontendVirtualPath + fileAttributePath + FieldValueString;

                HyperLink1.Visible = true;
                btnRemoveFile.Visible = true;
            }
            else
            {
                SetUpValidator(RequiredFieldValidator1);
            }

            // Set Session 
            Session.Add("FieldValueString", FieldValueString);

            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);

            if (Column.IsRequired)
                FileUpload1.CssClass += " required";
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            //Check If File Upload Has A file 
            if (FileUpload1.HasFile)
            {
                //return File Name Which Save In DB 
                dictionary[Column.Name] = SaveNewFile();
            }
            // File Upload Hasn't A file check Hiden Field
            else
            {
                if (!string.IsNullOrEmpty(hdfFileName.Value))
                {
                    DeleteFile();
                    dictionary[Column.Name] = string.Empty;
                }
            }
        }

        public string SaveNewFile()
        {
            string fileAttributeFullPath = Setting.FrontendPhysicalPath + GetFileAttributePath();
            string fileName = Utility.GetRand() + "-" + FileUpload1.FileName;

            //save file in front end physical path 
            FileUpload1.SaveAs(fileAttributeFullPath + fileName);

            if (!String.IsNullOrEmpty(Session["FieldValueString"].ToString()))
            {
                try
                {
                    // Delete Old File 
                    File.Delete(fileAttributeFullPath + Session["FieldValueString"].ToString());
                }
                catch
                {

                }
            }
            return fileName;
        }
        public void DeleteFile()
        {
            string fileAttributeFullPath = Setting.FrontendPhysicalPath + GetFileAttributePath();
            if (!String.IsNullOrEmpty(Session["FieldValueString"].ToString()))
            {
                // Delete Old File from Physical Path
                File.Delete(fileAttributeFullPath + Session["FieldValueString"].ToString());
                HyperLink1.NavigateUrl = string.Empty;
                Session.Add("FieldValueString", string.Empty);
            }
        }

        public override Control DataControl
        {
            get
            {
                return FileUpload1;
            }
        }

        private string GetFileAttributePath()
        {
            var metadata = MetadataAttributes.OfType<FileAttribute>().FirstOrDefault();

            if (metadata != null)
                return metadata.Path;
            else
                return String.Empty;
        }

        private void SetupHintAttribute()
        {
            var metadata = MetadataAttributes.OfType<HintAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                if (metadata.Hint.Length > 0)
                {
                    lblHint.Visible = true;
                    lblHint.Text = metadata.Hint;
                }
            }
        }

        //protected void RemoveFile(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(HyperLink1.NavigateUrl))
        //    {
        //        hdfFileName.Value = HyperLink1.NavigateUrl;
        //        HyperLink1.Visible = false;
        //        btnRemoveFile.Visible = false;
        //    }
        //}
    }
}