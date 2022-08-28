using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Text;
using System.Data.Entity.Validation;

namespace DynamicData.Admin
{

    static class EntityDataSourceExtensions
    {
        public static TEntity GetItemObject<TEntity>(object dataItem) where TEntity : class
        {
            var entity = dataItem as TEntity;
            if (entity != null)
            {
                return entity;
            }
            var td = dataItem as ICustomTypeDescriptor;
            if (td != null)
            {
                return (TEntity)td.GetPropertyOwner(null);
            }
            return null;
        }

        public static T GetAttribute<T>(this MetaTable table) where T : Attribute
        {
            return table.Attributes.OfType<T>().FirstOrDefault();
        }

        public static T GetAttributeOrDefault<T>(this MetaTable table) where T : Attribute, new()
        {
            return table.Attributes.OfType<T>().DefaultIfEmpty(new T()).FirstOrDefault();
        }

        public static T GetAttributeOrDefault<T>(this MetaColumn column) where T : Attribute, new()
        {
            return column.Attributes.OfType<T>().DefaultIfEmpty(new T()).FirstOrDefault();
        }

        public static T GetAttribute<T>(this MetaColumn column) where T : Attribute
        {
            return column.Attributes.OfType<T>().FirstOrDefault();
        }
    }

    static class HttpServerUtilityExtensions
    {
        public static void HandleError(this HttpServerUtility server, HttpContext httpContext)
        {
            Exception exception = server.GetLastError();
            server.ClearError();
            httpContext.Response.Clear();

            string error;
            if (exception.InnerException.InnerException == null)
                error = exception.InnerException.Message;
            else
                error = exception.InnerException.InnerException.Message;


            if (exception.InnerException != null && exception.InnerException is DbEntityValidationException)
            {
                //var typedEx = ex as DbEntityValidationException;
                var builder = new StringBuilder("Entity Validation Errors: <br />");

                foreach (var entity in ((DbEntityValidationException)exception.InnerException).EntityValidationErrors)
                {
                    builder.AppendFormat("{0} <br />", entity.Entry.Entity);
                    foreach (var DBerror in entity.ValidationErrors)
                    {
                        builder.AppendFormat("{0} <br />", DBerror.ErrorMessage);
                    }
                }
                server.Transfer("~/error/generic.aspx?msg=" + builder.ToString());
            }
            else if (exception is HttpException)
            {
                var httpEx = exception as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        server.Transfer("~/error/404.htm");
                        break;
                    case 403:
                        server.Transfer("~/error/403.htm");
                        break;
                    default:
                        server.Transfer("~/error/generic.aspx?msg=" + error);
                        break;
                }
            }
            else
            {
                server.Transfer("~/error/generic.aspx?msg=" + error);
            }
        }
    }
}