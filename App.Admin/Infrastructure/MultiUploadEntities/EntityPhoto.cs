using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicData.Admin.Infrastructure.MultiUploadEntities
{
    public class EntityPhoto
    {
        public String EntityName { get; set; }
        public int EntityId { get; set; }
        public int PhotoId { get; set; }
        public String PhotoPath { get; set; }
    }
}