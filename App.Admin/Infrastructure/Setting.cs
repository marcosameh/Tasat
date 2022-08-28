using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;


public class Setting
{
    #region Properties

    public static string WebsiteUrl
    {
        get
        {
            return WebConfigurationManager.AppSettings["WebsiteUrl"];
        }
    }

    public static int DefaultLanguage
    {
        get
        {
            return Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultLanguage"]);
        }
    }

    public static int CurrentLanguage
    {
        get
        {
            if (HttpContext.Current.Session["CurrentLanguage"] == null)
                HttpContext.Current.Session["CurrentLanguage"] = DefaultLanguage;

            return Convert.ToInt32(HttpContext.Current.Session["CurrentLanguage"]);
        }
    }

    public static string FrontendVirtualPath
    {
        get
        {
            return WebConfigurationManager.AppSettings["FrontendVirtualPath"];
        }
    }

    public static string FrontendPhysicalPath
    {
        get
        {
            return WebConfigurationManager.AppSettings["FrontendPhysicalPath"];
        }
    }

    #endregion
}
