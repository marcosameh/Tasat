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
    public partial class LocalizedFaqsCategoriesItem : LocalizedControl
    {


        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            AdminEntities db = new AdminEntities();
            var localizedItems = from l in db.FaqCategoryLocalizeds where l.CategoryId == itemId && l.LanguageId == languageId select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                FaqCategoryLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfTitle.FieldValue = localizedItemsArray[0].Name;
            }

            //Fields language
            lfTitle.FieldLanguage = languageFriendlyName;
        }

        public override void UpdateData(int itemId, int languageId)
        {
            AdminEntities db = new AdminEntities();

            try
            {
                FaqCategoryLocalized item = db.FaqCategoryLocalizeds.Single(l => l.CategoryId == itemId && l.LanguageId == languageId);
                item.Name = lfTitle.FieldValue;
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
            AdminEntities db = new AdminEntities();

            FaqCategoryLocalized item = new FaqCategoryLocalized
            {
                CategoryId = itemId,
                LanguageId = languageId,
                Name = lfTitle.FieldValue,

            };
            db.FaqCategoryLocalizeds.Add(item);
            db.SaveChanges();
        }
    }
}