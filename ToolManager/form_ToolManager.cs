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
    public partial class form_ToolManager : Form
    {
        const string toolFresa = "fresa";
        const string toolDrill = "punta";
        const string toolSaw = "lama";

        public form_ToolManager()
        {
            InitializeComponent();
        }
        private void form_ToolManager_Load(object sender, EventArgs e)
        {
            Globals.serviceManager = new Business.BusinessManager();
            CheckToolEnabled();
            LoadToolTree();
        }

        private void CheckToolEnabled()
        {
            var workNodes = Globals.serviceManager.GetToolTree();
            foreach (var node in workNodes)
            {
                if (node.Name == toolFresa && node.Enabled == 0) pbFresaTools.Visible = false;
                if (node.Name == toolDrill && node.Enabled == 0) pbDrillTools.Visible = false;
                if (node.Name == toolSaw && node.Enabled == 0) pbSawTools.Visible = false;
            }
        }

        private void LoadToolTree(string workName)
        {
            var sideNodes = Globals.serviceManager.GetToolTreeWorkNodes(workName);
            foreach (var sideNode in sideNodes)
            {
                if (sideNode.Enabled == 0) goto nextSide;

                TreeNode sideTree = new TreeNode();
                sideTree.

                foreach (var sideNode in workNode.SubNodes)
                {

                }

            nextSide:;
            }
        }

        public void PrintNodes(List<Node> nodes, int indentLevel)
        {
            if (nodes == null) return;

            string indent = new string(' ', indentLevel * 2); // Hiyerarşi için boşluk ekliyoruz.

            foreach (var node in nodes)
            {
                textBox1.Text += $"{indent}İsim: {node.Name}, Değer: {node.Value}, Etkin: {node.Enabled}"+"\r\n";
                PrintNodes(node.SubNodes, indentLevel + 1); // Alt düğümleri yazdır
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
