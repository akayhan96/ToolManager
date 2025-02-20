using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToolManager.Entity;

namespace ToolManager.DataAccess
{
    public class DBManager
    {
        private ToolTree toolTree;
        public DBManager()
        {
            toolTree = XmlSerialization.Deserialize<ToolTree>(Globals.XmlToolTree);
        }

        public List<Node> GetToolTree(Expression<Func<Node, bool>> filter = null)
        {
            return filter == null ? toolTree.Nodes : toolTree.Nodes.AsQueryable().Where(filter).ToList();
        }
    }
}
