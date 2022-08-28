using DynamicData.Admin.Infrastructure;
using System;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using DynamicData.Admin.Model;
using System.Linq;
using DynamicData.Admin.Infrastructure.MultiUploadEntities;

namespace DynamicData.Admin.Controls
{
    public partial class multi_upload : UserControl
    {
        public string targetFolder { get; set; }

        public bool resize { get; set; }

        public string photoThumbnail { get; set; }
        public string FieldHint
        {
            set
            {
                lblFieldHint.Text = value;
            }
        }
        private MultiUpload MultiUploadProperties
        {
            get
            {
                return new MultiUpload()
                {
                    TargetFolder = targetFolder,
                    Resize = resize,
                    PhotoThumbnail = photoThumbnail
                };
            }
        }

        public List<UploadedPhoto> UploadedPhotos
        {
            get
            {
                if (string.IsNullOrEmpty(hdnPhotoNamesArray.Value))
                    return new List<UploadedPhoto> { };

                return new JavaScriptSerializer().Deserialize<List<UploadedPhoto>>(hdnPhotoNamesArray.Value);
            }
        }

        public int[] DeletedPhotosIds
        {
            get
            {
                if (string.IsNullOrEmpty(hdnJsonDeletedPhotos.Value))
                    return new int[] { };

                return new JavaScriptSerializer().Deserialize<int[]>(hdnJsonDeletedPhotos.Value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Path.ToLower().Contains("edit.aspx"))
            {
                divSavedPhotos.Visible = true;
            }
            hdnJsonParam.Value = new JavaScriptSerializer().Serialize(MultiUploadProperties);
        }

        public IQueryable<EntityPhoto> lvPhotos_GetData()
        {
            AdminEntities db = new AdminEntities();
            string photoTableName = Page.Title + "Photos";

            //ToDo: set cases according to your entity 
            int itemId = Convert.ToInt32(Request.QueryString["Id"]);
            switch (photoTableName)
            {
                //case "PropertiesPhotos":
                //    IQueryable<PropertyPhoto> photos = from l in db.PropertyPhotos where l.PropertyId == itemId select l;
                //    return photos.Select(x => new EntityPhoto()
                //    {
                //        EntityId = x.PropertyId,
                //        EntityName = "Property",
                //        PhotoId = x.PhotoId,
                //        PhotoPath = Setting.FrontendVirtualPath + "/Photos/properties/" + x.Photo.Replace("_lg", "_sm")
                //    });
            }
            return null;
        }

        private void InsertData(int itemId, AdminEntities db)
        {
            if (UploadedPhotos.Count > 0)
            {
                int displayOrder = 0;
                string photoTableName = Page.Title + "Photos";

                //ToDo: set cases according to your entity 
                switch (photoTableName)
                {
                    //case "PropertiesPhotos":
                    //    foreach (UploadedPhoto photo in UploadedPhotos)
                    //    {
                    //        db.PropertyPhotos.Add(new PropertyPhoto()
                    //        {
                    //            PropertyId = itemId,
                    //            DisplayOrder = displayOrder,
                    //            Photo = photo.LargePhotoName
                    //        });
                    //        displayOrder++;
                    //    }
                    //    break;
                }
            }
        }

        private void DeletePhotos(int itemId, AdminEntities db)
        {
            if (DeletedPhotosIds.Length > 0)
            {
                string photoTableName = Page.Title + "Photos";

                //ToDo: set cases according to your entity 
                switch (photoTableName)
                {
                    //case "PropertiesPhotos":
                    //    foreach (int id in DeletedPhotosIds)
                    //    {
                    //        PropertyPhoto photo = db.PropertyPhotos.First(x => x.PhotoId == id);
                    //        db.PropertyPhotos.Remove(photo);
                    //    }
                    //    break;
                }
            }
        }

        public void SaveData(int itemId)
        {
            AdminEntities db = new AdminEntities();

            string requestPath = Request.Path.ToLower();
            if (requestPath.Contains("edit.aspx"))
            {
                DeletePhotos(itemId, db);
            }
            InsertData(itemId, db);
            db.SaveChanges();
        }
    }
}