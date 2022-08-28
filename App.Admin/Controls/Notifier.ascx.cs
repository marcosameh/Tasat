using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin.Controls
{
    public partial class Notifier : System.Web.UI.UserControl
    {

        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void Show(string title, string message, NotificationType type)
        //{
        //    Title = title;
        //    Message = message;
        //    Type = type;
        //    mainNotifier.Attributes["style"] = "display: block;";
        //}

        //public void Hide()
        //{
        //    mainNotifier.Attributes["style"] = "display: none;";
        //}


        public void Show(string title, string message, NotificationType type)
        {
            Title = title;
            Message = message;
            Type = type;

            switch (Type)
            {
                case NotificationType.Success:
                    imgType.Src = "~/images/alerts/success.png";
                    mainNotifier.Attributes["class"] = "alertContainer";
                    break;
                case NotificationType.Error:
                    imgType.Src = "~/images/alerts/error.gif";
                    mainNotifier.Attributes["class"] = "alertContainer errorAlert";
                    break;
                case NotificationType.Warning:
                    imgType.Src = "~/images/alerts/warning.gif";
                    mainNotifier.Attributes["class"] = "alertContainer warningAlert";
                    break;
                default:
                    break;
            }
            mainNotifier.Attributes["style"] = "display: block;";
            mainNotifierTitle.InnerHtml = Title;
            mainNotifierMessage.InnerHtml = Message;
        }

        public void Hide()
        {
            mainNotifier.Attributes["style"] = "display: none;";
        }
    }
}