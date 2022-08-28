using System;
using System.Web.Http;
using System.Web.Routing;
using System.Web.DynamicData;
using System.Web.UI;
using Microsoft.AspNet.DynamicData.ModelProviders;
using DynamicData.Admin.Model;

/// <summary>
/// This class is used to register data models with the ASP.NET dynamic data runtime.
/// </summary>
/// 
namespace DynamicData.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, MetaModel defaultModel)
        {


            //                    IMPORTANT: DATA MODEL REGISTRATION 
            // Uncomment this line to register an ADO.NET Entity Framework model for ASP.NET Dynamic Data.
            // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
            // data model to support a scaffold (i.e. templates) view. To control scaffolding for
            // individual tables, create a partial class for the table and apply the
            // [ScaffoldTable(true)] attribute to the partial class.
            // Note: Make sure that you change "YourDataContextType" to the name of the data context
            // class in your application.
            // See http://go.microsoft.com/fwlink/?LinkId=257395 for more information on how to register Entity Data Model with Dynamic Data            
            // DefaultModel.RegisterContext(() =>
            // {
            //    return ((IObjectContextAdapter)new YourDataContextType()).ObjectContext;
            // }, new ContextConfiguration() { ScaffoldAllTables = false });
            var context = new EFDataModelProvider(() => new AdminEntities());
            defaultModel.RegisterContext(context, new ContextConfiguration() { ScaffoldAllTables = true });
            // The following registration should be used if YourDataContextType does not derive from DbContext
            // DefaultModel.RegisterContext(typeof(YourDataContextType), new ContextConfiguration() { ScaffoldAllTables = false });

            // The following statement supports separate-page mode, where the List, Detail, Insert, and 
            // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
            // route definition, and comment out the route definitions in the combined-page mode section that follows.
            routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
            {
                Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
                Model = defaultModel
            });
            //Web Api Routing
            RouteTable.Routes.MapHttpRoute(
                        name: "WebApi",
                        routeTemplate: "api/{controller}/{action}/{id}/{currentMemberId}",
                        defaults: new { id = System.Web.Http.RouteParameter.Optional, currentMemberId = System.Web.Http.RouteParameter.Optional }
                        );
            // The following statements support combined-page mode, where the List, Detail, Insert, and
            // Update tasks are performed by using the same page. To enable this mode, uncomment the
            // following routes and comment out the route definition in the separate-page mode section above.
            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.List,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});

            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.Details,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});


        }
    }
}
