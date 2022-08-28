using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Model;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class LocalizedNewsItem : LocalizedControl
    {


        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            var db = new AdminEntities();
            var localizedItems = from l in db.NewsLocalizeds
                                 where l.NewsId == itemId && l.LanguageId == languageId
                                 select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                NewsLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfTitle.FieldValue = localizedItemsArray[0].Title;
                lfBody.FieldValue = localizedItemsArray[0].Body;
                lfMetaDescription.FieldValue = localizedItemsArray[0].MetaDescription;
                lfMetaTitle.FieldValue = localizedItemsArray[0].MetaTitle;
                lfShortDescription.FieldValue = localizedItemsArray[0].ShortDescription;
            }

            //Fields language
            lfTitle.FieldLanguage =
                lfBody.FieldLanguage =
                 lfMetaTitle.FieldLanguage=lfShortDescription.FieldLanguage = lfMetaDescription.FieldLanguage = languageFriendlyName;
        }

        public override void UpdateData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            try
            {
                NewsLocalized item = db.NewsLocalizeds.Single(l => l.NewsId == itemId && l.LanguageId == languageId);
                item.Title = lfTitle.FieldValue;
                item.Body = lfBody.FieldValue;
                item.MetaDescription = lfMetaDescription.FieldValue;
                item.MetaTitle = lfMetaTitle.FieldValue;
                item.ShortDescription = lfShortDescription.FieldValue;
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

            var item = new NewsLocalized
            {
                NewsId = itemId,
                LanguageId = languageId,
                Title = lfTitle.FieldValue,
                Body = lfBody.FieldValue,
                ShortDescription=lfShortDescription.FieldValue,
                MetaTitle = lfMetaTitle.FieldValue,
                MetaDescription = lfMetaDescription.FieldValue,
            };
            db.NewsLocalizeds.Add(item);
            db.SaveChanges();
        }

    }
}