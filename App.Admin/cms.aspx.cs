using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Humanizer;
using System.Text.RegularExpressions;
using DynamicData.Admin.Model;

namespace DynamicData.Admin
{
    public partial class cms : Page
    {
        public List<TreeNode> Tree { get; set; }
        public DirectoryInfo ParentDirectory { get; set; }
        public List<Language> ActiveLangauges { get; set; }
        public Dictionary<Language, Dictionary<string, CmsUpdateModel>> ResourceFilesDictionary { get; set; }

        public List<TreeNode> lvTree_GetData()
        {
            Tree.Add(CreateDirectoryNode(ParentDirectory));
            return Tree;
        }

        public object GetLanguages()
        {
            return ResourceFilesDictionary.OrderBy(x => x.Key.DisplayOrder);
        }

        public string GetValue(string value, string hint)
        {
            if (hint.ToLower() == "html")
            {
                return value;
            }
            else
                return Regex.Replace(Regex.Replace(value, @"\s+", " "),
                    @"(<br */>)|(\[br */\])", Environment.NewLine);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Tree = new List<TreeNode>();
            ParentDirectory = new DirectoryInfo
                (WebConfigurationManager.AppSettings["FrontendPhysicalPath"]).GetDirectories("resources")
                                            .Where(d => d.GetFiles("*.resx").Any()).FirstOrDefault();

            ResourceFilesDictionary = new Dictionary<Language, Dictionary<string, CmsUpdateModel>>();

            var db = new AdminEntities();
            ActiveLangauges = db.Languages.Where(x => x.Active).OrderBy(x => x.FriendlyName).ToList();

            string file = Request.QueryString["file"];
            if (string.IsNullOrWhiteSpace(file) == false)
            {
                divNoData.Visible = false;
                LoadResourceFile(file);
            }
            else
            {
                divNoData.Visible = true;
            }
        }

        protected void grdData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected string GetXEditMode(string value, string hint)
        {
            if (hint.ToLower() == "html")
            {
                return "wysihtml5";
            }
            if (value.Length > 99)
            {
                return "textarea";
            }
            return "text";
        }

        private readonly Dictionary<string, string> _translationDictionary = new Dictionary<string, string>()
        {
            {"resources", "Pages"},
            {"index", "Home"},
            {"controls", "Widgets"},
            //{"Layout", "Site Menu"}
        };

        private Language _defaultLanguage;

        private static string HumanizeKey(string key)
        {
            return
                key.Replace("loc", string.Empty)
                    .Replace("Resource1", string.Empty)
                    .Replace("Resource2", string.Empty)
                    .Replace(".Text", string.Empty)
                    .Humanize();
        }

        private void LoadResourceFile(string filePath)
        {
            string fileName = filePath;

            IEnumerable<FileInfo> matchingResourceFiles;

            if (filePath.Contains("resources"))
            {
                fileName = filePath.Split("/".ToCharArray()).Last();
                matchingResourceFiles = ParentDirectory.GetFiles(fileName + "*.resx", SearchOption.TopDirectoryOnly);
            }
            else
            {
                matchingResourceFiles = ParentDirectory.GetFiles(fileName + "*.resx", SearchOption.AllDirectories);
            }


            //show current file name
            hCurrentFileName.InnerText = fileName.Humanize();

            foreach (var file in matchingResourceFiles)
            {

                string fileCulture = file.Name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

                foreach (var language in ActiveLangauges)
                {

                    if (language.CultureName == fileCulture)
                    {
                        ResourceFilesDictionary.Add(language, ReadResourceFile(file));
                        break;
                    }
                }
            }
        }

        private Dictionary<string, CmsUpdateModel> ReadResourceFile(FileInfo file)
        {
            XDocument document = XDocument.Load(file.FullName);
            var dictionary = new Dictionary<string, CmsUpdateModel>();
            var resources = from resource in document.Descendants("data")
                            select new KeyValuePair<string, CmsUpdateModel>(resource.Attribute("name").Value,
                                new CmsUpdateModel
                                {
                                    FilePath = file.FullName,
                                    Key = resource.Attribute("name").Value,
                                    Value = resource.Element("value") == null ? string.Empty : resource.Element("value").Value,
                                    Hint = resource.Element("comment") == null ? string.Empty : resource.Element("comment").Value
                                });

            for (int i = 0; i < resources.Count(); i++)
            {
                if (dictionary.Keys.Contains(HumanizeKey(resources.ElementAt(i).Key)))
                {
                    dictionary.Add(HumanizeKey(resources.ElementAt(i).Key) + i.ToString(), resources.ElementAt(i).Value);
                }
                else
                {
                    dictionary.Add(HumanizeKey(resources.ElementAt(i).Key), resources.ElementAt(i).Value);
                }
            }
            return dictionary;
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directory)
        {
            var localResourcesDirectory = directory.GetDirectories().ToList();

            if (localResourcesDirectory != null)
            {
                var directoryNode = new TreeNode()
                {
                    Name = Translate(directory.Name.Humanize()),
                    Type = TreeNodeType.Folder,
                    Link = "javascript:;"
                };

                foreach (var childDir in localResourcesDirectory)
                {
                    var childNode = CreateDirectoryNode(childDir);
                    if (childNode != null)
                        directoryNode.Children.Add(childNode);
                }

                CreateResourceNodes(directory, directoryNode);
                return directoryNode;
            }
            return null;
        }

        private void CreateResourceNodes(DirectoryInfo localResourcesDirectory, TreeNode directoryNode)
        {
            List<FileInfo> localResourceFiles = new List<FileInfo>();

            if (localResourcesDirectory != null)
                localResourceFiles.AddRange(localResourcesDirectory.GetFiles("*.resx"));


            foreach (var file in localResourceFiles)
            {
                var name = Translate(file.Name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).First().Humanize());

                if (directoryNode.Children.Where(x => x.Name == name).Any() == false)
                    directoryNode.Children.Add(new TreeNode()
                    {
                        Name = name,
                        Type = TreeNodeType.File,
                        Link = GetResourceFileLink(file)
                    });
            }
        }

        private string GetResourceFileLink(FileInfo file)
        {
            string parentDirectory = file.Directory.Parent.FullName == ParentDirectory.FullName.TrimEnd("\\".ToCharArray()) ? null : file.Directory.Parent.Name + "/";

            string fileName = file.Name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).First();
            return string.Format("{0}?file={1}",
                Request.Url.LocalPath,
                parentDirectory + file.Directory.Name + "/" + fileName);
        }

        private string Translate(string originalValue)
        {
            var key = originalValue.ToLower().Trim();
            if (_translationDictionary.ContainsKey(key))
            {
                return _translationDictionary[key];
            }
            return originalValue;
        }
    }
}