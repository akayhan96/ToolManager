using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolManager.DataAccess;
using ToolManager.Entity;

namespace ToolManager.Business
{
    public class BusinessManager
    {
        private DBManager dbManager;
        public BusinessManager()
        {
            this.dbManager = new DBManager();
        }

        public List<Node> GetToolTree()
        {
            return dbManager.GetToolTree();
        }
        public List<Node> GetToolTreeWorkNodes(string workName)
        {
            return dbManager.GetToolTree(n => n.Name == workName);
        }
    }
}
