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
    public partial class LocalizedFaqsItem : LocalizedControl
    {

        public override void BindData(int itemId, int languageId, string languageFriendlyName)
        {
            var db = new AdminEntities();
            var localizedItems = from l in db.FaqLocalizeds where l.FaqId == itemId && l.LanguageId == languageId select l;

            //Fields value
            if (localizedItems.Count() == 1) //Should be 1 for (details and edit), and 0 for (list and insert).
            {
                FaqLocalized[] localizedItemsArray = localizedItems.ToArray();
                lfQuestion.FieldValue = localizedItemsArray[0].Question;
                lfAnswer.FieldValue = localizedItemsArray[0].Answer;
            }

            //Fields language
            lfQuestion.FieldLanguage = lfAnswer.FieldLanguage = languageFriendlyName;
        }
        public override void UpdateData(int itemId, int languageId)
        {
            var db = new AdminEntities();

            try
            {
                FaqLocalized item = db.FaqLocalizeds.Single(l => l.FaqId == itemId && l.LanguageId == languageId);
                item.Question = lfQuestion.FieldValue;
                item.Answer = lfAnswer.FieldValue;
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

            FaqLocalized item = new FaqLocalized
            {
                FaqId = itemId,
                LanguageId = languageId,
                Question = lfQuestion.FieldValue,
                Answer = lfAnswer.FieldValue

            };
            db.FaqLocalizeds.Add(item);
            db.SaveChanges();
        }
    }
}