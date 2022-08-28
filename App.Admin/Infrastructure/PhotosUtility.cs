using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Image = System.Drawing.Image;

public class PhotosUtility
{
    #region Properties

    int maxThumbnailWidth;
    public int MaxThumbnailWidth
    {
        get
        {
            return maxThumbnailWidth;
        }
        set
        {
            maxThumbnailWidth = value;
        }
    }

    int maxThumbnailHeight;
    public int MaxThumbnailHeight
    {
        get
        {
            return maxThumbnailHeight;
        }
        set
        {
            maxThumbnailHeight = value;
        }
    }

    string photoPostfix;
    public string PhotoPostfix
    {
        get
        {
            return photoPostfix;
        }
        set
        {
            photoPostfix = value;
        }
    }

    string thumbnailPostfix;
    public string ThumbnailPostfix
    {
        get
        {
            return thumbnailPostfix;
        }
        set
        {
            thumbnailPostfix = value;
        }
    }

    string thumbnailExtension;
    public string ThumbnailExtension
    {
        get
        {
            return thumbnailExtension;
        }
        set
        {
            thumbnailExtension = value;
        }
    }

    string photoPath;
    public string PhotoPath
    {
        get
        {
            return photoPath;
        }
        set
        {
            photoPath = value;
        }
    }

    string thumbnailPath;
    public string ThumbnailPath
    {
        get
        {
            return thumbnailPath;
        }
        set
        {
            thumbnailPath = value;
        }
    }

    string tempPath;
    public string TempPath
    {
        get
        {
            return tempPath;
        }
        set
        {
            tempPath = value;
        }
    }

    private Color brushBrush;
    public Color BrushBrush
    {
        get
        {
            return brushBrush;
        }
        set
        {
            brushBrush = value;
        }
    }

    private string waterMarkPath;
    public string WaterMarkPath
    {
        get { return waterMarkPath; }
        set { waterMarkPath = value; }
    }

    private Point waterMarkPosition;
    public Point WaterMarkPosition
    {
        get { return waterMarkPosition; }
        set { waterMarkPosition = value; }
    }
    #endregion

    public PhotosUtility()
    {
        maxThumbnailWidth = 0;
        maxThumbnailHeight = 0;
        photoPostfix = String.Empty;
        thumbnailPostfix = String.Empty;
        thumbnailExtension = ".jpg";
        photoPath = String.Empty;
        thumbnailPath = String.Empty;
        tempPath = String.Empty;
        brushBrush = Color.White;
        waterMarkPosition = new Point();
        WaterMarkPath = string.Empty;
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }

    public byte[] GetThumbnail(byte[] imageBytes)
    {
        return GetThumbnail(imageBytes, MaxThumbnailWidth, MaxThumbnailHeight, false, thumbnailExtension);
    }
    public byte[] GetThumbnail(byte[] imageBytes, int maxWidth, int maxHeight, bool fixedSizeBackground, string thumbnailExtension)
    {
        using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(imageBytes)))
        {
            if (maxWidth < 1)
                maxWidth = image.Width;
            if (maxHeight < 1)
                maxHeight = image.Height;

            //maxWidth += 2;
            //maxHeight += 2;

            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                double widthRatio = (double)image.Width / maxWidth;
                double heightRatio = (double)image.Height / maxHeight;
                double ratio = Math.Max(widthRatio, heightRatio);
                int thumbWidth = (int)(image.Width / ratio);
                int thumbHeight = (int)(image.Height / ratio);

                //Encoder
                ImageCodecInfo jgpEncoder = GetEncoder(thumbnailExtension == ".png" ? ImageFormat.Png : ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID for the Quality parameter category.
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one  EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                if (fixedSizeBackground)
                {
                    using (Bitmap bitmap = new Bitmap(maxWidth, maxHeight, PixelFormat.Format32bppArgb))
                    {
                        bitmap.SetResolution(72, 72);

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.CompositingMode = CompositingMode.SourceCopy;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.FillRectangle(new SolidBrush(BrushBrush), new Rectangle(0, 0, maxWidth, maxHeight));
                            int x = (maxWidth - thumbWidth) / 2;
                            int y = (maxHeight - thumbHeight) / 2;

                            graphics.DrawImage(image, x, y, thumbWidth, thumbHeight);

                            MemoryStream memoryStream = new MemoryStream();
                            bitmap.Save(memoryStream, jgpEncoder, myEncoderParameters);
                            return memoryStream.GetBuffer();
                        }
                    }
                }
                else
                {
                    using (Bitmap bitmap = new Bitmap(thumbWidth, thumbHeight, PixelFormat.Format32bppArgb))
                    {
                        bitmap.SetResolution(72, 72);

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.CompositingMode = CompositingMode.SourceCopy;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            graphics.FillRectangle(new System.Drawing.SolidBrush(BrushBrush), new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight));

                            graphics.DrawImage(image, -2, -2, thumbWidth + 4, thumbHeight + 4);

                            MemoryStream memoryStream = new MemoryStream();
                            bitmap.Save(memoryStream, jgpEncoder, myEncoderParameters);
                            return memoryStream.GetBuffer();
                        }
                    }

                }
            }
            else
            {
                return imageBytes;
            }
        }
    }

    public byte[] AddWatermark(byte[] originalImage)
    {
        Image image = Image.FromStream(new MemoryStream(originalImage));
        Image watermarkImage = Image.FromFile(waterMarkPath);
        using (Graphics graphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            watermarkBrush.TranslateTransform(waterMarkPosition.X, waterMarkPosition.Y);
            graphics.FillRectangle(watermarkBrush, new Rectangle(waterMarkPosition,
                new Size(watermarkImage.Width, watermarkImage.Height)));
        }
        using (var ms = new MemoryStream())
        {
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
    /// <summary>
    /// Writes photo file contents.
    /// </summary>
    /// <param name="filename">File name without extension (photo).</param>
    /// <param name="prefix">File name prefix (prefix-).</param>
    /// <param name="extension">File name extension (.jpg)</param>
    /// <param name="bytes">File contents</param>
    /// <returns>Full file name/path.</returns>
    public string CreatePhotoFile(string filename, string prefix, string postfix, string extension, byte[] bytes)
    {
        if (String.IsNullOrEmpty(postfix))
            postfix = photoPostfix;

        filename = prefix + filename + photoPostfix + extension;
        return CreateFile(filename, photoPath, bytes);
    }
    /// <summary>
    /// Writes thumbnail file contents.
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="prefix"></param>
    /// <param name="bytes">Resized file contents</param>
    /// <returns>Full file name/path.</returns>
    public string CreateThumbnailFile(string filename, string prefix, string postfix, byte[] bytes)
    {
        if (String.IsNullOrEmpty(postfix))
            postfix = thumbnailPostfix;

        filename = prefix + filename + postfix + thumbnailExtension;
        return CreateFile(filename, thumbnailPath, bytes);
    }
    public string CreateTempThumbnailFile(string filename, string prefix, string postfix, byte[] bytes)
    {
        if (String.IsNullOrEmpty(postfix))
            postfix = thumbnailPostfix;

        filename = prefix + filename + thumbnailPostfix + thumbnailExtension;
        return CreateFile(filename, TempPath, bytes);
    }
    public void RenameTempThumbnailFile(string filename, string newFileName)
    {
        RenameFile(filename, newFileName, tempPath);
    }
    public void MoveFromTempToThumbnail(string filename)
    {
        MoveFile(filename, tempPath, thumbnailPath);
    }
    public void DeletePhotoFile(string filename)
    {
        DeleteFile(photoPath + filename);
    }
    public void DeleteThumbnailFile(string filename)
    {
        DeleteFile(thumbnailPath + filename);
    }

    #region Static Methods

    public static string CreateFile(string filename, string filepath, byte[] bytes)
    {
        string physicalFilename = filepath + filename;

        if (!String.IsNullOrEmpty(physicalFilename))
        {
            using (FileStream fileStream = File.Open(physicalFilename, FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
            }
        }

        return filename;
    }
    /// <summary>
    /// Writes file contents to a specific file name/path, like (~/directory/prefix-photo-postfix.jpg).
    /// </summary>
    /// <param name="filename">File name without extension (photo).</param>
    /// <param name="prefix">File name prefix (prefix-).</param>
    /// <param name="postfix">File name postfix, will be added before the file extension (-postfix).</param>
    /// <param name="extension">File name extension (.jpg)</param>
    /// <param name="filepath">File directory (~/directory/).</param>
    /// <param name="bytes">File contents.</param>
    /// <returns>Full file name/path.</returns>
    public static string CreateFile(string filename, string prefix, string postfix, string extension, string filepath, byte[] bytes)
    {
        filename = prefix + filename + postfix + extension;
        return CreateFile(filename, filepath, bytes);
    }

    public static void MoveFile(string sourceFileName, string destFileName)
    {
        if (!String.IsNullOrEmpty(sourceFileName))
        {
            if (File.Exists(sourceFileName))
                try
                {
                    File.Move(sourceFileName, destFileName);
                }
                catch { }
        }
    }
    public static void MoveFile(string filename, string sourceFilepath, string destFilepath)
    {
        MoveFile(sourceFilepath + filename, destFilepath + filename);
    }
    public static void RenameFile(string filename, string newFilename, string filepath)
    {
        MoveFile(filepath + filename, filepath + newFilename);
    }

    public static void DeleteFile(string physicalFilename)
    {
        if (!String.IsNullOrEmpty(physicalFilename))
        {
            if (File.Exists(physicalFilename))
                try
                {
                    File.Delete(physicalFilename);
                }
                catch { }
        }
    }
    public static void DeleteFile(string filename, string filepath)
    {
        DeleteFile(filepath + filename);
    }

    #endregion
}