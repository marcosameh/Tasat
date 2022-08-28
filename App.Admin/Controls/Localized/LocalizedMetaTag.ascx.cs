using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Model;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedMetaTag : LocalizedControl
    {


        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            var db = new AdminEntities();
            var localizedItems = from l in db.MetaTagLocalizeds where l.MetaTagId == itemId && l.LanguageId == languageId select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                MetaTagLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfMetaTitle.FieldValue = localizedItemsArray[0].MetaTitle;
                lfMetaDescription.FieldValue = localizedItemsArray[0].MetaDescription;
                lfMetaKeywords.FieldValue = localizedItemsArray[0].MetaKeywords;
            }

            //Fields language
            lfMetaTitle.FieldLanguage = lfMetaDescription.FieldLanguage = lfMetaKeywords.FieldLanguage = languageFriendlyName;
        }


        public override void UpdateData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            try
            {
                var item =
                    db.MetaTagLocalizeds.Single(l => l.MetaTagId == itemId && l.LanguageId == languageId);

                item.MetaTitle = lfMetaTitle.FieldValue;
                item.MetaDescription = lfMetaDescription.FieldValue;
                item.MetaKeywords = lfMetaKeywords.FieldValue;

                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "Sequence contains no elements") // Should appear only if new languages just added.
                    InsertData(itemId, languageId);
                else throw ex;
            }
        }

        public override void InsertData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            var item = new MetaTagLocalized
            {
                MetaTagId = itemId,
                LanguageId = languageId,
                MetaTitle = lfMetaTitle.FieldValue,
                MetaDescription = lfMetaDescription.FieldValue,
                MetaKeywords = lfMetaKeywords.FieldValue
            };
            db.MetaTagLocalizeds.Add(item);
            db.SaveChanges();
        }
    }
}