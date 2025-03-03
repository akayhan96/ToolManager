using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolManager.Entity;

namespace ToolManager
{
    public partial class form_ToolsConfiguration : Form
    {
        public form_ToolsConfiguration()
        {
            InitializeComponent();
        }
        List<Node> toolsTree;
        private void form_ToolsConfiguration_Load(object sender, EventArgs e)
        {
            lblFormTitle.Text = Globals.serviceManager.ReadMessage("1019",Globals.XmlngTecnoManager);
            toolsTree = Globals.serviceManager.GetToolTree();
            LoadToolTree(toolsTree);
        }

        private void LoadToolTree(List<Node> treeNodes)
        {
            twToolTree.ImageList = Globals.TreeViewImages;
            foreach (var workNode in treeNodes)
            {
                TreeNode workTree = new TreeNode();
                workTree.Text = Globals.serviceManager.GetFieldText(workNode.Name, workNode.Value);
                workTree.Tag = workNode.Value;
                workTree.Checked = workNode.Enabled == 0 ? false : true;
                workTree.ImageKey = workNode.Value;
                workTree.SelectedImageKey = workNode.Value;
                foreach (var sideNode in workNode.SubNodes)
                {
                    TreeNode sideTree = new TreeNode();
                    sideTree.Text = Globals.serviceManager.GetFieldText(sideNode.Name, sideNode.Value);
                    sideTree.Tag = workTree.Tag.ToString() + "|" + sideNode.Value;
                    sideTree.Checked = sideNode.Enabled == 0 ? false : true;
                    sideTree.ImageKey = sideNode.Value;
                    sideTree.SelectedImageKey = sideNode.Value;
                    foreach (var subWorkNode in sideNode.SubNodes)
                    {
                        TreeNode sWorkTree = new TreeNode();
                        sWorkTree.Text = Globals.serviceManager.GetFieldText(subWorkNode.Name, subWorkNode.Value);
                        sideTree.Tag = sideTree.Tag.ToString() + "|" + subWorkNode.Value;
                        sWorkTree.Checked = subWorkNode.Enabled == 0 ? false : true;
                        sWorkTree.ImageKey = subWorkNode.Value;
                        sWorkTree.SelectedImageKey = subWorkNode.Value;

                        sideTree.Nodes.Add(sWorkTree);
                    }
                    workTree.Nodes.Add(sideTree);
                }
                twToolTree.Nodes.Add(workTree);
            }
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < twToolTree.Nodes.Count; i++)
            {
                toolsTree[i].Enabled = Convert.ToInt32(twToolTree.Nodes[i].Checked);
                for (int j = 0; j < twToolTree.Nodes[i].Nodes.Count; j++)
                {
                    toolsTree[i].SubNodes[j].Enabled = Convert.ToInt32(twToolTree.Nodes[i].Nodes[j].Checked);
                    for (int k = 0; k < twToolTree.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        toolsTree[i].SubNodes[j].SubNodes[k].Enabled = Convert.ToInt32(twToolTree.Nodes[i].Nodes[j].Nodes[k].Checked);
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
