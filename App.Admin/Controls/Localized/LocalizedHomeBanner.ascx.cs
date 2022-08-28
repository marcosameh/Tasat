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
    public partial class BannerItem : LocalizedControl
    {

        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            var db = new AdminEntities();
            var localizedItems = from l in db.HomeBannerLocalizeds
                                 where l.HomeBannerId == itemId && l.LanguageId == languageId
                                 select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                HomeBannerLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfTitle.FieldValue = localizedItemsArray[0].Title;
                lfSubTitle.FieldValue = localizedItemsArray[0].SubTitle;
                //lfLink.FieldValue = localizedItemsArray[0].LinkText;

            }

            //Fields language
            lfTitle.FieldLanguage = lfSubTitle.FieldLanguage /*= lfLink.FieldLanguage */= languageFriendlyName;
        }

        public override void UpdateData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            try
            {
                HomeBannerLocalized item =
                    db.HomeBannerLocalizeds.Single(l => l.HomeBannerId == itemId && l.LanguageId == languageId);

                item.Title = lfTitle.FieldValue;
                item.SubTitle = lfSubTitle.FieldValue;
                //item.LinkText = lfLink.FieldValue;
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

            var item = new HomeBannerLocalized
            {
                HomeBannerId = itemId,
                LanguageId = languageId,
                Title = lfTitle.FieldValue,
                SubTitle = lfSubTitle.FieldValue,
                //LinkText = lfLink.FieldValue,
            };
            db.HomeBannerLocalizeds.Add(item);
            db.SaveChanges();
        }
    }
}