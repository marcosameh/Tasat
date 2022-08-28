using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;


public enum NotificationType
{
    Success = 0,
    Error = 1,
    Warning = 2,
    Info = 4
}


public class Utility
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
    public static string BrToCRLF(string text)
    {
        return text.Replace("<br/>", "\r\n");
    }
    public static string CRLFToBr(string text)
    {
        return text.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
    }

    /// <summary>
    /// Returns the first 5 characters of a GUID as a random string.
    /// </summary>
    /// <returns></returns>
    public static string GetRand()
    {
        return Guid.NewGuid().ToString().Substring(0, 5);
    }

    public static string Truncate(string text, int length)
    {
        if (String.IsNullOrEmpty(text))
            return String.Empty;
        else if (text.Length > length)
        {
            int spaceIndex = text.IndexOf(' ', length);
            if (spaceIndex > -1)
                return text.Substring(0, spaceIndex) + "...";
            else
                return text;
        }
        else
            return text;
    }

    public static string GetSingular(string plural)
    {
        if (plural.EndsWith("ies", StringComparison.InvariantCultureIgnoreCase))
        {
            return plural.Remove(plural.Length - 3) + "y";
        }
        else if (plural.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
        {
            return plural.TrimEnd(new char[] { 's' });
        }
        else
            return plural;
    }

    public static string GetReadable(string value)
    {
        string readable = value;
        char[] chars = value.ToCharArray();
        for (int i = 1; i < value.Length; i++)
        {
            if (char.IsUpper(chars[i]))
            {
                readable = readable.Insert(i, " ");
            }
        }

        return readable;
    }

    //get youtube image
    public static string GetYoutubeThumbnail(string url, bool bigThumbnail = false)
    {
        try
        {
            Uri u = new Uri(url);
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = rand.Next(1, 3);
            string videoCode = System.Web.HttpUtility.ParseQueryString(u.Query).Get("v");
            return bigThumbnail ? string.Format("http://img.youtube.com/vi/{0}/0.jpg", videoCode) : string.Format("http://img.youtube.com/vi/{0}/{1}.jpg", videoCode, numIterations);
        }
        catch
        {
            return string.Empty;
        }
    }
}
