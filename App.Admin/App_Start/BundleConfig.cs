using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace DynamicData.Admin
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {

          


            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/vendors/jquery-2.1.3.min.js",
                DebugPath = "~/scripts/vendors/jquery-2.1.3.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.3.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.3.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            //BundleTable.EnableOptimizations = false;
        }
    }
}