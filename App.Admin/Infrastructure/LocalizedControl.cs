using DynamicData.Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity.Validation;
using System.Web.DynamicData;
using DynamicData.Admin.Controls.Localized;
using Humanizer;

namespace DynamicData.Admin.Infrastructure
{
    public abstract class LocalizedControl : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MetaTable table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

            MetaTable localizedTable;
            var type = Type.GetType("DynamicData.Admin.Model." + table.Name.Singularize() + "Localized");
            if (type == null || MetaTable.TryGetTable(type, out localizedTable) == false)
            {
                return;
            }


            foreach (var control in this.Controls)
            {
                if (control is LocalizedField)
                {
                    var localizedField = (LocalizedField)control;
                    var columnName = localizedField.FieldName.Replace(" ", "");
                    MetaColumn metaColumn;
                    if (localizedTable.TryGetColumn(columnName, out metaColumn) == true)
                    {
                        localizedField.FieldMaxLength = metaColumn.MaxLength;
                        localizedField.FieldIsRequired = metaColumn.IsRequired;
                    }
                }
            }
        }


        public abstract void BindData(int itemId, int languageId, string languageFriendlyName);
        public void SaveData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            string requestPath = Request.Path.ToLower();
            
            try
            {
                if (requestPath.Contains("edit.aspx"))
                {
                    UpdateData(itemId, languageId);
                }
                else if (requestPath.Contains("insert.aspx"))
                {
                    InsertData(itemId, languageId);
                }
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(DbEntityValidationException))
                {
                    var ex = string.Empty;
                    foreach (var eve in ((DbEntityValidationException)e).EntityValidationErrors)
                    {
                        ex += $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors: <br>";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            ex += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"<br>";
                        }
                    }
                    throw new Exception(ex);
                }
                else
                {
                	throw;
            	}
            }
        }

        public abstract void UpdateData(int itemId, int languageId);

        public abstract void InsertData(int itemId, int languageId);
    }
}