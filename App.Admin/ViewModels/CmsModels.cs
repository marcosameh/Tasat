using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicData.Admin
{
    public class CmsUpdateModel
    {
        public string FilePath { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Hint { get; set; }
    }

    public class TreeNode
    {
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }
        public TreeNodeType Type { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public List<TreeNode> Children { get; set; }
    }
    public enum TreeNodeType : int
    {
        Folder = 1,
        File = 2
    }
}