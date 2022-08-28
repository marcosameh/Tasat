using Humanizer;
using System;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public class ListPage : System.Web.UI.Page
    {
        public ListPage()
            : base()
        {
            PreInit += new EventHandler(PageBase_PreInit);
        }

        public bool EnableViewStateCompression
        {
            get { return enableViewStateCompression; }
            set { enableViewStateCompression = value; }
        }

        protected static void RenderGridHeaderRow(GridViewRowEventArgs e, string cssClass = null)
        {
            if (cssClass != null)
            {
                e.Row.CssClass = cssClass;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Controls.Count > 0)
                    {
                        ((LinkButton)e.Row.Cells[i].Controls[0]).Text = ((LinkButton)e.Row.Cells[i].Controls[0]).Text.Humanize();
                    }
                    else
                    {
                        e.Row.Cells[i].Text = e.Row.Cells[i].Text.Humanize();
                    }
                }
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
        
        protected override object LoadPageStateFromPersistenceMedium()
        {
            if (EnableViewStateCompression)
            {
                string viewState = Request.Form[compressedViewState];
                byte[] bytes = Convert.FromBase64String(viewState);
                bytes = Compressor.Decompress(bytes);
                LosFormatter formatter = new LosFormatter();
                return formatter.Deserialize(Convert.ToBase64String(bytes));
            }
            else
                return base.LoadPageStateFromPersistenceMedium();
        }

        protected override void SavePageStateToPersistenceMedium(object viewState)
        {
            if (EnableViewStateCompression)
            {
                LosFormatter formatter = new LosFormatter();
                StringWriter writer = new StringWriter();
                formatter.Serialize(writer, viewState);
                string viewStateString = writer.ToString();
                byte[] bytes = Convert.FromBase64String(viewStateString);
                bytes = Compressor.Compress(bytes);
                if (ScriptManager.GetCurrent(Page) != null)
                    ScriptManager.RegisterHiddenField(Page, compressedViewState, Convert.ToBase64String(bytes));
                else
                    ClientScript.RegisterHiddenField(compressedViewState, Convert.ToBase64String(bytes));
            }
            else
                base.SavePageStateToPersistenceMedium(viewState);
        }

        private string compressedViewState = "__COMPRESSEDVIEWSTATE";

        private bool enableViewStateCompression;

        private void PageBase_PreInit(object sender, EventArgs e)
        {
            EnableViewStateCompression =
                Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableViewStateCompression"]);
        }
    }
}