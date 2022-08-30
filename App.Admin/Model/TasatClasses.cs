using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.ComponentModel;
//using Microsoft.Data.OData.Query.SemanticAst;
using NotAClue.ComponentModel.DataAnnotations;

namespace DynamicData.Admin.Model
{


    #region Gallery

    [MetadataType(typeof(GalleryMetadata))]
  
    public partial class Gallery
    {
    }

    public class GalleryMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/gallery/originals/", "/photos/gallery/")]
        [PhotoThumbnail(1, 0, "267,200,false,sm,.jpg", "800,600,false,lg,.jpg")]
        [Hint(Hint = "Please upload a 800 X 600 photo")]
     
        public object Photo { get; set; }

        
    }

    #endregion
    #region MenuItems

    [MetadataType(typeof(MenuItemsMetadata))]

    public partial class MenuItem
    {
    }

    public class MenuItemsMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/menu/originals/", "/photos/menu/")]
        [PhotoThumbnail(1, 0, "200,150,false,sm,.png", "415,300,false,lg,.png")]
        [Hint(Hint = "Please upload a 415 X 300 photo")]

        public object Photo { get; set; }


    }

    #endregion
    #region Events

    [MetadataType(typeof(EventsMetadata))]

    public partial class Event
    {
    }

    public class EventsMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/events/originals/", "/photos/events/")]
        [PhotoThumbnail(1, 0, "250,300,false,sm,.png", "525,600,false,lg,.png")]
        [Hint(Hint = "Please upload a 525 X 600 photo")]

        public object Photo { get; set; }


    }

    #endregion
    #region TeamMember

    [MetadataType(typeof(TeamMemberMetadata))]

    public partial class TeamMember
    {
    }

    public class TeamMemberMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/team/originals/", "/photos/team/")]
        [PhotoThumbnail(1, 0, "200,200,false,sm,.png", "415,415,false,lg,.png")]
        [Hint(Hint = "Please upload a 415 X 415 photo")]

        public object Photo { get; set; }


    }

    #endregion
}