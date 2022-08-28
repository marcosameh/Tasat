using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;


/// <summary>
/// Upload attribute defines values for the upload
/// field templates
/// </summary>
/// <remarks></remarks>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class UploadAttribute : Attribute
{
    #region Properties
    /// <summary>
    /// Gets or sets the height to display the image, 
    /// if only one of the two dimensions are specified
    /// then the aspect ration will be retained.
    /// </summary>
    /// <value>The height.</value>
    /// <remarks></remarks>
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the width to display the image, 
    /// if only one of the two dimensions are specified
    /// then the aspect ration will be retained.
    /// </summary>
    /// <value>The width.</value>
    /// <remarks></remarks>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the uploads folder.
    /// </summary>
    /// <value>The uploads folder.</value>
    /// <remarks></remarks>
    public String UploadFolder { get; set; }

    /// <summary>
    /// Gets or sets the icons folder.
    /// </summary>
    /// <value>The icons folder.</value>
    /// <remarks></remarks>
    public String ImagesFolder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [show hyperlink].
    /// </summary>
    /// <value><c>true</c> if [show hyperlink]; otherwise, <c>false</c>.</value>
    /// <remarks></remarks>
    public Boolean ShowHyperlink { get; set; }

    /// <summary>
    /// Gets or sets the file types.
    /// </summary>
    /// <value>The file types.</value>
    /// <remarks></remarks>
    public String[] FileTypes { get; set; }

    /// <summary>
    /// Gets or sets the image extension.
    /// </summary>
    /// <value>The image extension.</value>
    /// <remarks></remarks>
    public String ImageExtension { get; set; }
    public String ImagePath { get; set; }
    public String ImagePrefix { get; set; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Attribute"/> class
    /// setting the Height to 50 and the folder to "~/images".
    /// </summary>
    /// <remarks></remarks>
    public UploadAttribute()
    {
        // set a default value of 50 and constrain aspect ratio.
        Height = 50;
        // set default images folder
        UploadFolder = Setting.FrontendPhysicalPath;
    }
}

public enum HtmlAttributeModes
{
    ViewOnly, EditOnly, Both
}
public enum Position
{
    Center, TopRight, TopLeft, BottomRight, BottomLeft
}
public class HtmlAttributeAttribute : Attribute
{
    private string key;
    private string value;
    private HtmlAttributeModes htmlAttributeMode;
    private bool displayInEdit = true;

    public HtmlAttributeAttribute(string key, string value, HtmlAttributeModes htmlAttributeMode)
    {
        this.key = key;
        this.value = value;
        this.htmlAttributeMode = htmlAttributeMode;
    }
    public HtmlAttributeAttribute(string key, string value)
        : this(key, value, HtmlAttributeModes.ViewOnly)
    { }

    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }

    public string Key { get { return key; } }

    public string Value { get { return value; } }

    public HtmlAttributeModes HtmlAttributeMode { get { return htmlAttributeMode; } }
}

public class MultiLineAttribute : Attribute
{
    public int DisplayLength { get; set; }
    public MultiLineAttribute() { }
    public MultiLineAttribute(int displayLength)
    {
        DisplayLength = displayLength;
    }

    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public class ReadonlyAttribute : Attribute
{
    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public class UrlAttribute : Attribute
{
    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}
public class EmailAttribute : Attribute
{
    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public enum AutoGenerateModes
{
    Once, EveryTime
}
public class AutoGenerateAttribute : Attribute
{
    private AutoGenerateModes autoGenerateMode;
    private bool displayInEdit = true;

    public AutoGenerateAttribute(AutoGenerateModes autoGenerateMode)
    {
        this.autoGenerateMode = autoGenerateMode;
    }

    public AutoGenerateModes AutoGenerateMode
    {
        get { return autoGenerateMode; }
    }

    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public class FileAttribute : Attribute
{
    private string path;
    private bool displayInEdit = true;

    public FileAttribute(string path)
    {
        this.path = path;
    }

    public string Path
    {
        get { return path; }
    }

    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public class PhotoAttribute : Attribute
{
    private string photoPath;
    private string thumbnailsPath;
    private bool displayInEdit = true;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="photoPath">Set to empty string ("") to avoid saving the original photos</param>
    /// <param name="thumbnailsPath"></param>
    public PhotoAttribute(string photoPath, string thumbnailsPath)
    {
        this.photoPath = photoPath;
        this.thumbnailsPath = thumbnailsPath;
    }

    public string PhotoPath { get { return photoPath; } }

    public string ThumbnailsPath { get { return thumbnailsPath; } }

    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

public class PhotoThumbnail
{
    public int Width { get; set; }
    public int Height { get; set; }
    public bool FixedSizeBackground { get; set; }
    public string Format { get; set; }

    string postfix;
    public string Postfix
    {
        get { return postfix; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception("Postfix can not be null or empty string.");

            postfix = value;
        }
    }

    public string WaterMarkPath { get; set; }
    public Point WaterMarkPosition { get; set; }

    public PhotoThumbnail(int width, int height, bool fixedSizeBackground, string postfix, string format, string waterMarkPath = "", int waterMarkPositionX = 0, int waterMarkPositionY = 0)
    {
        SetProperties(width, height, fixedSizeBackground, postfix, format, waterMarkPath, waterMarkPositionX, waterMarkPositionY);
    }

    /// <summary>
    /// Comma separated properties, paramters signature is (int width, int height, bool fixedSizeBackground, string postfix).
    /// A valid example is "400,300,false,-thumb".
    /// </summary>
    /// <param name="properties"></param>
    public PhotoThumbnail(string properties)
    {
        string[] propertiesArray = properties.Split(',');
        if (propertiesArray.Length < 5 || propertiesArray.Length > 8)
            throw new Exception("Invalid paramter signature/count. valid example is \"400,300,false,-thumb,.jpg\"");

        if (propertiesArray.Length == 5)
            SetProperties(Convert.ToInt32(propertiesArray[0].Trim()), Convert.ToInt32(propertiesArray[1].Trim()),
                Convert.ToBoolean(propertiesArray[2].Trim()), propertiesArray[3], propertiesArray[4], "", 0, 0);
        else
            SetProperties(Convert.ToInt32(propertiesArray[0].Trim()), Convert.ToInt32(propertiesArray[1].Trim()),
                Convert.ToBoolean(propertiesArray[2].Trim()), propertiesArray[3], propertiesArray[4], propertiesArray[5], Convert.ToInt32(propertiesArray[6].Trim()), Convert.ToInt32(propertiesArray[7].Trim()));

    }

    private void SetProperties(int width, int height, bool fixedSizeBackground, string postfix, string format, string waterMarkPath, int waterMarkPositionX, int waterMarkPositionY)
    {
        Width = width;
        Height = height;
        FixedSizeBackground = fixedSizeBackground;
        Postfix = postfix;
        Format = format;
        WaterMarkPath = string.IsNullOrEmpty(waterMarkPath) ? string.Empty : (Setting.FrontendPhysicalPath + waterMarkPath).Replace('/', '\\');
        WaterMarkPosition = new Point(waterMarkPositionX, waterMarkPositionY);
    }
}
public class PhotoThumbnailAttribute : Attribute
{
    int dbThumbnail;
    int adminThumbnail;
    Dictionary<string, PhotoThumbnail> thumbnails;
    protected bool displayInEdit = true;

    /// <summary>
    /// A thumbnail is a comma separated properties, paramters signature is (int width, int height, bool fixedSizeBackground, string postfix).
    /// A valid example is "400,300,false,-thumb".
    /// </summary>
    /// <param name="thumbnails"></param>
    public PhotoThumbnailAttribute(int dbThumbnail, int adminThumbnail, params string[] thumbnails)
    {
        this.thumbnails = new Dictionary<string, PhotoThumbnail>();

        if (thumbnails.Length < 1)
            throw new Exception("No thumbnails found.");

        if (dbThumbnail > -1 && adminThumbnail > -1 && dbThumbnail < thumbnails.Length && adminThumbnail < thumbnails.Length)
        {
            this.dbThumbnail = dbThumbnail;
            this.adminThumbnail = adminThumbnail;
        }
        else
            throw new Exception("Invalid dbThumbnail or adminThumbnail, must be > -1 and < thumbnails.Length.");

        foreach (string sThumbnail in thumbnails)
        {
            PhotoThumbnail thumbnail = new PhotoThumbnail(sThumbnail);

            if (this.thumbnails.ContainsKey(thumbnail.Postfix))
                throw new Exception("Duplicate postfix, postfix must be unique.");

            this.thumbnails.Add(thumbnail.Postfix, thumbnail);
        }
    }

    public int DbThumbnail { get { return dbThumbnail; } }
    public int AdminThumbnail { get { return adminThumbnail; } }
    public Dictionary<string, PhotoThumbnail> Thumbnails { get { return thumbnails; } }

    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}


public class HintAttribute : Attribute
{
    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }

    public string Hint { get; set; }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class OrderByAttribute : Attribute
{
    public string ColumnName { get; set; }

    public bool DescendingOrder { get; set; }


    private OrderByAttribute() { }

    public OrderByAttribute(string columnName)
    {
        ColumnName = columnName;
        DescendingOrder = false;
    }

    public OrderByAttribute(string columnName, bool descendingOrder)
    {
        ColumnName = columnName;
        DescendingOrder = descendingOrder;
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DisableEditingAttribute : Attribute
{
    public Boolean Disable { get; set; }

    public DisableEditingAttribute() : this(false) { }

    public DisableEditingAttribute(Boolean disable)
    {
        Disable = disable;
    }
}

public class PageNameAttribute : Attribute
{
    private bool displayInEdit = true;
    public bool DisplayInEdit
    {
        get { return displayInEdit; }
        set { displayInEdit = value; }
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class GroupByAttribute : Attribute
{
    public string TableName { get; set; }

    public string ColumnName { get; set; }

    public GroupByAttribute(string tableName)
    {
        TableName = tableName;
    }

    public GroupByAttribute(string tableName, string columnName)
    {
        ColumnName = columnName;
        TableName = tableName;
    }
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class EntityUIHintAttribute : Attribute
{
    private IDictionary<string, object> _controlParameters;

    public IDictionary<string, object> ControlParameters
    {
        get { return this._controlParameters; }
    }

    /// <summary>
    /// Gets or sets the UI hint.
    /// </summary>
    /// <value>The UI hint.</value>
    public String UIHint { get; private set; }

    public EntityUIHintAttribute(string uiHint) : this(uiHint, new object[0]) { }

    public EntityUIHintAttribute(string uiHint, params object[] controlParameters)
    {
        UIHint = uiHint;
        _controlParameters = BuildControlParametersDictionary(controlParameters);
    }

    public override object TypeId
    {
        get { return this; }
    }

    private IDictionary<string, object> BuildControlParametersDictionary(object[] objArray)
    {
        IDictionary<string, object> dictionary = new Dictionary<string, object>();
        if ((objArray != null) && (objArray.Length != 0))
        {
            if ((objArray.Length % 2) != 0)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Need even number of control parameters.", new object[0]));

            for (int i = 0; i < objArray.Length; i += 2)
            {
                object obj2 = objArray[i];
                object obj3 = objArray[i + 1];
                if (obj2 == null)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Control parameter key is null.", new object[] { i }));

                string key = obj2 as string;
                if (key == null)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Control parameter key is not a string.", new object[] { i, objArray[i].ToString() }));

                if (dictionary.ContainsKey(key))
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Control parameter key occurs more than once.", new object[] { i, key }));

                dictionary[key] = obj3;
            }
        }
        return dictionary;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class MultiColumnAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the column span.
    /// </summary>
    /// <value>The column span.</value>
    public int ColumnSpan { get; private set; }

    public static MultiColumnAttribute Default = new MultiColumnAttribute();

    public MultiColumnAttribute()
    {
        ColumnSpan = 1;
    }

    public MultiColumnAttribute(int columnSpan)
    {
        ColumnSpan = columnSpan;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class DataTableAttribute : Attribute
{
    private bool renderDataTable = true;
    public bool RenderDataTable
    {
        get { return renderDataTable; }
        set { renderDataTable = value; }
    }
}


[AttributeUsage(AttributeTargets.Class)]
public class MembershipAttribute : Attribute
{
    //private bool colorLockedUsers = true;
    //public bool ColorLockedUsers
    //{
    //    get { return colorLockedUsers; }
    //    set { colorLockedUsers = value; }
    //}
}

[AttributeUsage(AttributeTargets.Class)]
public class DisableActionsAttribute : Attribute
{
    public bool DisableInsert { get; set; } = true;
    public bool DisableDelete { get; set; } = true;
    public bool DisableEditing { get; set; } = true;

    public DisableActionsAttribute() : this(true, true, true) { }

    public DisableActionsAttribute(bool disableInsert, bool disableDelete, bool disableEditing)
    {
        DisableInsert = disableInsert;
        DisableDelete = disableDelete;
        DisableEditing = disableEditing;
    }
}
