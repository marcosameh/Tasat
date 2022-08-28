using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using Microsoft.AspNet.DynamicData.ModelProviders;
using DynamicData.Admin.Model;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Optimization;
using NotAClue.Web.DynamicData;

namespace DynamicData.Admin
{
    public class Global : System.Web.HttpApplication
    {
        private static MetaModel s_defaultModel = new AdvancedMetaModel();
        public static MetaModel DefaultModel
        {
            get
            {
                return s_defaultModel;
            }
        }


        void Application_Start(object sender, EventArgs e)
        {
            //Add custom entity UiHint -- Should be before register context
            DefaultModel.EntityTemplateFactory = new AdvancedEntityTemplateFactory();

            RouteConfig.RegisterRoutes(RouteTable.Routes, DefaultModel);
            GlobalConfiguration.Configure(WebApiConfig.Register);
           BundleConfig.RegisterBundles(BundleTable.Bundles);

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (HttpContext.Current.IsDebuggingEnabled == false && Request.IsLocal == false)
            {
                Server.HandleError(((HttpApplication)sender).Context);
            }
        }

        // The code below is to enable Session State for WebAPIs calls
        public override void Init()
        {
            this.PostAuthenticateRequest += Application_PostAuthenticateRequest;
            base.Init();
        }

        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.StartsWith("/api/"))
            {
                System.Web.HttpContext.Current.SetSessionStateBehavior(
                    SessionStateBehavior.Required);
            }
        }

        //end of APIs session state fix
    }
}
