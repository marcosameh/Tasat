using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Model;
using System;
using System.Linq;

namespace DynamicData.Admin.Controls.Localized
{
    public partial class AlbumItem : LocalizedControl
    {
        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            var db = new AdminEntities();
            var localizedItems = from l in db.AlbumLocalizeds
                                 where l.AlbumId == itemId && l.LanguageId == languageId
                                 select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                AlbumLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfName.FieldValue = localizedItemsArray[0].Name;
                lfDescription.FieldValue = localizedItemsArray[0].Description;
                lfMetaTitle.FieldValue = localizedItemsArray[0].MetaTitle;
                lfMetaDescription.FieldValue = localizedItemsArray[0].MetaDescription;
            }

            //Fields language
            lfName.FieldLanguage =
                lfDescription.FieldLanguage = lfMetaTitle.FieldLanguage =
                lfMetaDescription.FieldLanguage = languageFriendlyName;
        }

        public override void UpdateData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            try
            {
                AlbumLocalized item =
                    db.AlbumLocalizeds.Single(l => l.AlbumId == itemId && l.LanguageId == languageId);

                item.Name = lfName.FieldValue;
                item.Description = lfDescription.FieldValue;
                item.MetaTitle = lfMetaTitle.FieldValue;
                item.MetaDescription = lfMetaDescription.FieldValue;
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

            var item = new AlbumLocalized
            {
                AlbumId = itemId,
                LanguageId = languageId,
                Name = lfName.FieldValue,
                Description = lfDescription.FieldValue,
                MetaTitle = lfMetaTitle.FieldValue,
                MetaDescription = lfMetaDescription.FieldValue,
            };
            db.AlbumLocalizeds.Add(item);
            db.SaveChanges();
        }

        
    }
}