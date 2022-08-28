using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public class AdvancedEntityTemplateFactory : System.Web.DynamicData.EntityTemplateFactory
    {
        public override string BuildEntityTemplateVirtualPath(string templateName, DataBoundControlMode mode)
        {
            var path = base.BuildEntityTemplateVirtualPath(templateName, mode);
            var editPath = base.BuildEntityTemplateVirtualPath(templateName, DataBoundControlMode.Edit); ;
            var defaultPath = base.BuildEntityTemplateVirtualPath(templateName, DataBoundControlMode.ReadOnly); ;

            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                return path;

            if (mode == DataBoundControlMode.Insert && File.Exists(HttpContext.Current.Server.MapPath(editPath)))
                return editPath;

            if (mode != DataBoundControlMode.ReadOnly && File.Exists(HttpContext.Current.Server.MapPath(defaultPath)))
                return defaultPath;

            return path;
        }

        public override EntityTemplateUserControl CreateEntityTemplate(MetaTable table, DataBoundControlMode mode, string uiHint)
        {
            var et = table.GetAttribute<EntityUIHintAttribute>();
            if (et != null && !String.IsNullOrEmpty(et.UIHint))
                return base.CreateEntityTemplate(table, mode, et.UIHint);

            return base.CreateEntityTemplate(table, mode, uiHint);
        }

        public override string GetEntityTemplateVirtualPath(MetaTable table, DataBoundControlMode mode, string uiHint)
        {
            var et = table.GetAttribute<EntityUIHintAttribute>();
            if (et != null && !String.IsNullOrEmpty(et.UIHint))
                return base.GetEntityTemplateVirtualPath(table, mode, et.UIHint);

            return base.GetEntityTemplateVirtualPath(table, mode, uiHint);
        }
    }
}