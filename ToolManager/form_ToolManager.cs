using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        BindingList<string> DisplayTools = new BindingList<string>();

        bool LoadedForm = false;
        public form_ToolManager()
        {
            InitializeComponent();
        }
        private void form_ToolManager_Load(object sender, EventArgs e)
        {
            GetLanguage();

            Globals.serviceManager = new Business.BusinessManager();
            Globals.serviceManager.GetFieldImages();
            CheckToolEnabled();


            lblFeedUnitTitle.Text = Globals.serviceManager.ReadMessage("2000", Globals.XmlngTecnoManager);

            LoadToolTree(toolFresa);

            LoadFeedTools();

            dgvToolInfo.Select();


            Globals.serviceManager.ReadWorkTypes();
            LoadedForm = true;
        }

        private void GetLanguage()
        {
            string escFile = @"C:\Albatros\system\Esc\Esc.ini";
            if(File.Exists(escFile))
            {
                string[] esc = File.ReadAllLines(escFile);
                string lineLng = esc.FirstOrDefault(e => e.StartsWith("Language="));
                Globals.CurLang = lineLng.Split('=')[1];

            }
            else
            {
                Globals.CurLang = "TRK";
                MessageBox.Show(Globals.serviceManager.ReadMessage("8",Globals.XmlngToolManager),"ToolManager",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void CheckToolEnabled()
        {
            var workNodes = Globals.serviceManager.GetToolTree();
            foreach (var node in workNodes)
            {
                if (node.Value == toolFresa) pbFresaTools.Visible = node.Enabled == 0 ? false : true;
                if (node.Value == toolDrill) pbDrillTools.Visible = node.Enabled == 0 ? false : true;
                if (node.Value == toolSaw) pbSawTools.Visible = node.Enabled == 0 ? false : true;
            }
        }

        private void LoadToolTree(string workValue, bool forceLoad = false)
        {
            if (Globals.SelectWorkValue == workValue && forceLoad == false) return;

            twTools.Nodes.Clear();
            DisplayTools.Clear();
            DisplayTools.Add("");
            Globals.SelectWorkValue = workValue;
            lblToolsTitle.Text = Globals.serviceManager.GetFieldText("codWork", workValue);

            var sideNodes = Globals.serviceManager.GetToolTreeWorkNodes("codSide");

            foreach (var sideNode in sideNodes)
            {
                if (sideNode.Enabled == 0) goto nextSide;

                int sideTreeIndex = 0;
                TreeNode sideTree = new TreeNode();
                sideTree.Tag = string.Format("{0}|{1}", workValue, sideNode.Value);
                sideTree.Text = Globals.serviceManager.GetFieldText(sideNode.Name, sideNode.Value);

                foreach (var subWorkNode in sideNode.SubNodes)
                {
                    if (subWorkNode.Enabled == 0) goto nextSubWork;

                    TreeNode subWorkTree = new TreeNode();
                    subWorkTree.Tag = string.Format("{0}|{1}|{2}", workValue, sideNode.Value, subWorkNode.Value);
                    subWorkTree.Text = Globals.serviceManager.GetFieldText(subWorkNode.Name, subWorkNode.Value);
                    subWorkTree.NodeFont = new Font("Gadugi", 9, FontStyle.Bold);

                    var toolList = Globals.serviceManager.GetTools(workValue, sideNode.Value, subWorkNode.Value);
                    foreach (var tool in toolList)
                    {
                        TreeNode toolNode = new TreeNode();
                        string toolName = Globals.serviceManager.GetToolName(tool);
                        toolNode.Tag = string.Format("{0}|{1}|{2}|{3}", workValue, sideNode.Value, subWorkNode.Value, toolName);
                        toolNode.Text = toolName;
                        toolNode.NodeFont = new Font("Gadugi", 9);
                        subWorkTree.Nodes.Add(toolNode);

                        DisplayTools.Add(toolName);
                    }
                    sideTree.Nodes.Add(subWorkTree);

                nextSubWork:;
                }
                twTools.Nodes.Add(sideTree);
                sideTreeIndex++;

            nextSide:;
            }


            twTools.Refresh();
            twTools.Update();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            if(changedOutfitData || changedToolsData)
            {
                var res = MessageBox.Show(Globals.serviceManager.ReadMessage("3999", Globals.XmlngTecnoManager), "ToolManager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    if (changedToolsData)
                    {
                        Globals.serviceManager.WriteXml(Globals.EntityDbTools);
                    }

                    if (changedOutfitData)
                    {
                        Globals.serviceManager.WriteXml(Globals.EntityDbOutfits);
                    }
                }
            }

            Application.Exit();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbFresaTools_Click(object sender, EventArgs e)
        {
            LoadToolTree(toolFresa);
        }

        private void pbDrillTools_Click(object sender, EventArgs e)
        {
            LoadToolTree(toolDrill);
        }

        private void twTools_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] nodeTag = e.Node.Tag.ToString().Split('|');
            if (nodeTag.Length == 4)
            {
                PrepareDgvToolInfo(nodeTag);
            }
            else
            {
                dgvToolInfo.Rows.Clear();
                pbEditOK.Visible = false;
                pbEditCancel.Visible = false;
                pbToolInfo.Visible = false;
            }
        }

        private void PrepareDgvToolInfo(string[] nodeTag, bool newTool = false)
        {
            var toolViewList = Globals.serviceManager.GetToolViews(nodeTag);
            var toolData = newTool == false ? Globals.serviceManager.GetTool(nodeTag) : CreateEmptyToolData();

            dgvToolInfo.Rows.Clear();

            var itemDesc = toolViewList.Items[0];
            string msgDesc = Globals.serviceManager.GetFieldText(itemDesc.MessageId);

            //Description(Takım Ad bilgisi)
            string msgValue = newTool == false ? Globals.serviceManager.GetToolValue(toolData, itemDesc.Field) : "Tool 0";
            dgvToolInfo.Rows.Add(msgDesc, msgValue, "", "", itemDesc.Field);

            foreach (var group in toolViewList.Groups)
            {
                string groupText = Globals.serviceManager.GetFieldText(group.MessageId);
                int rowIndex = dgvToolInfo.Rows.Add(groupText, "", "", "", "group");
                dgvToolInfo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Gray;
                dgvToolInfo.Rows[rowIndex].DefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Bold);

                foreach (var item in group.Items)
                {
                    string itemText = Globals.serviceManager.GetFieldText(item.MessageId) + item.Suffix;

                    if (string.IsNullOrEmpty(item.Values))
                    {
                        dgvToolInfo.Rows.Add(itemText, Globals.serviceManager.GetToolValue(toolData, item.Field), item.Min, item.Max, item.Field);
                    }
                    else
                    {
                        string[] values = item.Values.Split('%');
                        DataGridViewComboBoxCell dgvCbCell = new DataGridViewComboBoxCell();
                        dgvCbCell.Items.Add(Globals.serviceManager.GetFieldText(values[0]));
                        dgvCbCell.Items.Add(Globals.serviceManager.GetFieldText(values[1]));

                        dgvToolInfo.Rows.Add();
                        int rowId = dgvToolInfo.Rows.Count - 1;
                        dgvToolInfo.Rows[rowId].Cells["Value"] = dgvCbCell;

                        int itemValue = Convert.ToInt16(Globals.serviceManager.GetToolValue(toolData, item.Field));
                        dgvToolInfo.Rows[rowId].Cells["Info"].Value = itemText;
                        dgvToolInfo.Rows[rowId].Cells["Value"].Value = dgvCbCell.Items[itemValue];
                        dgvToolInfo.Rows[rowId].Cells["Min"].Value = "";
                        dgvToolInfo.Rows[rowId].Cells["Max"].Value = "";
                        dgvToolInfo.Rows[rowId].Cells["Field"].Value = item.Field;
                    }
                }
            }
            pbEditOK.Visible = true;
            pbEditCancel.Visible = true;
            pbToolInfo.Visible = true;

        }

        bool changedToolsData = false;
        private void pbEditOK_Click(object sender, EventArgs e)
        {
            string tagWork = twTools.SelectedNode.Tag.ToString().Split('|')[0];
            string tagSide = twTools.SelectedNode.Tag.ToString().Split('|')[1];
            string tagSubWork = twTools.SelectedNode.Tag.ToString().Split('|')[2];
            string toolName = modeCopyTool == false ? dgvToolInfo.Rows[0].Cells["Value"].Value.ToString() : copiedToolName;
            string toolTag = $"{tagWork}|{tagSide}|{tagSubWork}|{toolName}";

            var toolData = modeNewTool == false ? Globals.serviceManager.GetTool(toolTag.Split('|')) : CreateEmptyToolData();
            for (int i = 0; i < dgvToolInfo.Rows.Count; i++)
            {
                string cellField = dgvToolInfo.Rows[i].Cells["Field"].Value.ToString();
                string cellValue = dgvToolInfo.Rows[i].Cells["Value"].Value.ToString();
                if (!string.IsNullOrEmpty(cellField) && cellField !="group")
                {
                    if (cellField == "rotDirection")
                    {
                        cellValue = cellValue[0].ToString();
                    }
                    Globals.serviceManager.SetToolValue(toolData, cellField, cellValue);
                }
            }

            if (modeNewTool || modeCopyTool)
            {
                string[] nodeTag = twTools.SelectedNode.Tag.ToString().Split('|');
                string work = Globals.serviceManager.GetFieldValue("codWork", nodeTag[0]);
                string side = Globals.serviceManager.GetFieldValue("codSide", nodeTag[1]);
                string sWork = Globals.serviceManager.GetFieldValue("codSubWork", nodeTag[2]);

                if (modeNewTool)
                {
                    Globals.serviceManager.SetToolValue(toolData, "codWork", work);
                    Globals.serviceManager.SetToolValue(toolData, "codSide", side);
                    Globals.serviceManager.SetToolValue(toolData, "codSubWork", sWork);

                    Globals.serviceManager.AddToolOnList(toolData);
                }

                DisplayTools.Add(Globals.serviceManager.GetToolName(toolData));
                AddToolOnTreeView(twTools.SelectedNode.Tag.ToString(), toolData);
            }
            else
            {
                string newToolName = Globals.serviceManager.GetToolName(toolData);

                twTools.SelectedNode.Text = newToolName;
                twTools.SelectedNode.Tag = $"{tagWork}|{tagSide}|{tagSubWork}|{newToolName}";

                int toolIndex = DisplayTools.IndexOf(toolName);
                DisplayTools[toolIndex] = newToolName;
            }

            changedToolsData = true;
            twTools.Enabled = true;

            modeNewTool = false;
            modeCopyTool = false;
        }

        private void AddToolOnTreeView(string tag, ToolData toolData)
        {
            string[] subWorkTag = tag.Split('|');
            if (subWorkTag.Length > 3)
            {
                tag = string.Format("{0}|{1}|{2}", subWorkTag[0], subWorkTag[1], subWorkTag[2]);
            }

            // Önce subWork düğümünü direkt olarak bul
            TreeNode subWorkNode = twTools.Nodes
                .Cast<TreeNode>()
                .SelectMany(n => n.Nodes.Cast<TreeNode>()) // Tüm alt düğümleri al
                .FirstOrDefault(n => n.Tag.ToString() == tag);

            TreeNode toolNode = new TreeNode();
            string toolName = Globals.serviceManager.GetToolName(toolData);
            toolNode.Tag = string.Format("{0}|{1}|{2}|{3}", subWorkTag[0], subWorkTag[1], subWorkTag[2], toolName);
            toolNode.Text = toolName;
            toolNode.NodeFont = new Font("Gadugi", 9);
            subWorkNode.Nodes.Add(toolNode);

            twTools.SelectedNode = toolNode;

        }

        private void pbEditCancel_Click(object sender, EventArgs e)
        {
            if (modeCopyTool || modeNewTool)
            {
                dgvToolInfo.Rows.Clear();
                twTools.SelectedNode = twTools.SelectedNode.Parent;
            }
            else
            {
                twTools.SelectedNode = twTools.SelectedNode;
            }

            EnableStateDgvToolInfo(false);
            twTools.Enabled = true;
        }

        private void pbSawTools_Click(object sender, EventArgs e)
        {
            LoadToolTree(toolSaw);
        }

        bool modeNewTool = false;
        private void pbAddTool_Click(object sender, EventArgs e)
        {
            if (twTools.SelectedNode == null) return;
            string[] nodeTag = twTools.SelectedNode.Tag.ToString().Split('|');

            if (nodeTag.Length >= 3)
            {
                modeNewTool = true;
                PrepareDgvToolInfo(nodeTag, modeNewTool);
                EnableStateDgvToolInfo(true);
            }
        }

        private ToolData CreateEmptyToolData()
        {
            var toolData = new ToolData();

            // ToolData içindeki ToolFields listesini başlat
            toolData.ToolFields = new List<ToolField>();

            var fields = Globals.serviceManager.GetToolTypes();

            foreach (var field in fields)
            {
                toolData.ToolFields.Add(new ToolField { Name = field.Name, Type = "System." + field.Type, Value = "0" });
            }

            return toolData;
        }

        private void pbRemoveTool_Click(object sender, EventArgs e)
        {
            if (twTools.SelectedNode == null) return;
            string[] nodeTag = twTools.SelectedNode.Tag.ToString().Split('|');
            if (nodeTag.Length == 4)
            {
                Globals.serviceManager.RemoveToolOnList(twTools.SelectedNode.Tag.ToString());
                DisplayTools.Remove(nodeTag[3]);
                twTools.SelectedNode.Remove();

                changedToolsData = true;
            }
        }

        private void pbEditTool_Click(object sender, EventArgs e)
        {
            if (twTools.SelectedNode == null) return;
            string[] nodeTag = twTools.SelectedNode.Tag.ToString().Split('|');
            if (nodeTag.Length == 4)
            {
                // Yani listeden bir tool seçilmişse çalışacak
                PrepareDgvToolInfo(nodeTag);
                EnableStateDgvToolInfo(true);
            }
        }

        bool modeCopyTool = false;
        string copiedToolName = "";
        private void pbCopyTool_Click(object sender, EventArgs e)
        {
            if (twTools.SelectedNode == null) return;
            string[] nodeTag = twTools.SelectedNode.Tag.ToString().Split('|');
            if (nodeTag.Length == 4)
            {
                modeCopyTool = true;
                modeNewTool = false;

                var selectedTool = Globals.serviceManager.GetTool(nodeTag);

                var copyTool = Globals.serviceManager.CopyTool(selectedTool);

                string tagWork = twTools.SelectedNode.Parent.Tag.ToString().Split('|')[0];
                string tagSide = twTools.SelectedNode.Parent.Tag.ToString().Split('|')[1];
                string tagSubWork = twTools.SelectedNode.Parent.Tag.ToString().Split('|')[2];
                string copyToolName = copyTool.ToolFields.FirstOrDefault(f => f.Name == "description").Value.ToString();
                copiedToolName = copyToolName;

                string newTag = $"{tagWork}|{tagSide}|{tagSubWork}|{copyToolName}";
                PrepareDgvToolInfo(newTag.Split('|'));
                EnableStateDgvToolInfo(true);
                //AddToolOnTreeView(twTools.SelectedNode.Parenet.Tag.ToString(), copyTool);
            }
        }

        private void pbConfigureTools_Click(object sender, EventArgs e)
        {
            using (var toolsCfg = new form_ToolsConfiguration())
            {
                if (toolsCfg.ShowDialog() == DialogResult.OK)
                {
                    CheckToolEnabled();
                    LoadToolTree(Globals.SelectWorkValue, true);
                    Globals.serviceManager.WriteXml(Globals.EntityToolTree);
                }
            }
        }

        private void LoadFeedTools()
        {
            suppressEvent = true;
            ShowFeedGroups();

            var feeds = Globals.serviceManager.GetFeeds();
            foreach (var feed in feeds)
            {
                string pos = feed.Position.ToString();
                Control findedGroup = FindFeedGroup(pos);
                string cbName = findedGroup.Name.Replace("gb", "cb");
                Control cbTool = findedGroup.Controls.Find(cbName, true).FirstOrDefault();
                (cbTool as ComboBox).SelectedItem = feed.Value;

                var tool = Globals.serviceManager.GetTool(feed.Value);
                string sideValue = Globals.serviceManager.GetToolValue(tool, "codSide");
                string imageName = Globals.serviceManager.GetFieldName("codSide", sideValue);
                string pbName = findedGroup.Name.Replace("gbTool", "pbFeedSide"); // gbTool1 -> pbFeedSide1
                // Control pbSide = findedGroup.Controls.Find(pbName, true).FirstOrDefault();
                // (pbSide as PictureBox).Image = Globals.TreeViewImages.Images[imageName];
            }

            suppressEvent = false;
        }

        private Control FindFeedGroup(string text)
        {
            foreach (Control item in pnlFeedUnit.Controls)
            {
                if (item.Text == text)
                {
                    return item;
                }
            }

            return null;
        }

        private void ShowFeedGroups()
        {
            // All Hide Groups

            for (int i = 1; i <= 15; i++)
            {
                string ctrlGbName = $"gbTool{i}";
                Control gbControl = pnlFeedUnit.Controls.Find(ctrlGbName, true).FirstOrDefault();
                (gbControl as GroupBox).Visible = false;
            }
            //-------------------------


            var spindles = Globals.serviceManager.GetCorrectors();
            int gbCount = 1;

            foreach (var spindle in spindles)
            {
                if (spindle.CorrectorZ != 0 || spindle.RelativeAggregate > 0)
                {
                    string ctrlGbName = $"gbTool{gbCount}";
                    Control gbControl = pnlFeedUnit.Controls.Find(ctrlGbName, true).FirstOrDefault();
                    (gbControl as GroupBox).Text = spindle.Index.ToString();
                    (gbControl as GroupBox).Visible = true;

                    var tools = Globals.serviceManager.GetToolsForFeedTools(2, spindle.SideMask);
                    var descriptions = tools
                        .SelectMany(t => t.ToolFields) // Tüm ToolField'leri tek listeye al
                        .Where(f => f.Name == "description") // Sadece "description" olanları filtrele
                        .Select(f => f.Value) // Sadece değerleri al
                        .Distinct() // Aynı olanları kaldır
                        .ToList();

                    descriptions.Insert(0, "");
                    string ctrlCbName = $"cbTool{gbCount}";
                    Control cbControl = gbControl.Controls.Find(ctrlCbName, true).FirstOrDefault();
                    //(cbControl as ComboBox).DataSource = descriptions;
                    (cbControl as ComboBox).DataSource = DisplayTools;
                    (cbControl as ComboBox).Tag = spindle.Index.ToString();
                    (cbControl as ComboBox).SelectedIndex = 0;


                    gbCount++;
                }
            }
        }

        string previewSelectedTool = "-1";
        bool suppressEvent = false;
        bool changedOutfitData = false;
        private void cbTool_SelectedIndex(object sender, EventArgs e)
        {
            if (!LoadedForm) return;
            if (suppressEvent) return;

            ComboBox cbTool = sender as ComboBox;

            string message = "";
            if (cbTool.SelectedItem == null || cbTool.SelectedItem.ToString() == "")
            {
                Globals.serviceManager.RemoveFeed(cbTool.Tag.ToString());
                message = Globals.serviceManager.ReadMessage("1", Globals.XmlngToolManager);
                MessageBox.Show(message,"ToolManager",MessageBoxButtons.OK, MessageBoxIcon.Information);
                changedOutfitData = true;
            }
            else
            {
                var pluggedTool = Globals.serviceManager.GetFeed(cbTool.Tag.ToString());
                var isPlugSelectedTool = Globals.serviceManager.isPlugTool(cbTool.Tag.ToString(), cbTool.SelectedItem.ToString());
                if (pluggedTool == null && isPlugSelectedTool == false)
                {
                    // Takılı takım olmadığı için ekleme işlemi yapıldı
                    Globals.serviceManager.AddFeed(cbTool.Tag.ToString(), cbTool.SelectedItem.ToString());
                    message = Globals.serviceManager.ReadMessage("2", Globals.XmlngToolManager);
                    MessageBox.Show(message, "ToolManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changedOutfitData = true;
                }
                else
                {
                    // Takılı takım var. O zaman yeni kendisini güncelleyecek ya da takılımı başka takımı kullanmış olacak
                    if (isPlugSelectedTool)
                    {
                        // Seçilen takım başka bir besleme yerinde kullanılıyor
                        // Takım takılı ve pos bilgi farklı ise bu takımı bu pos' da kullanamazsın
                        suppressEvent = true;
                        message = Globals.serviceManager.ReadMessage("1", Globals.XmlngToolManager);
                        MessageBox.Show(message, "ToolManager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbTool.SelectedItem = previewSelectedTool;
                        suppressEvent = false;
                        return;
                    }
                    else
                    {
                        // Takılı takım varsa ve pos bilgi aynı ise takım güncellendi
                        Globals.serviceManager.UpdateFeed(cbTool.Tag.ToString(), cbTool.SelectedItem.ToString());
                        message = Globals.serviceManager.ReadMessage("1", Globals.XmlngToolManager);
                        MessageBox.Show(message, "ToolManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changedOutfitData = true;
                    }
                }
            }
        }

        private void cbTool_Click(object sender, EventArgs e)
        {
            ComboBox cbTool = sender as ComboBox;
            previewSelectedTool = cbTool.SelectedItem.ToString();
        }

        string selectedGroup = "";
        private ComboBox FindToolCombobox(string btnName, string subStr)
        {
            string feedGrName = btnName.Replace(subStr, "gb"); // pbShowTool1 -> gbTool1
            GroupBox feedGr = pnlFeedUnit.Controls.Find(feedGrName, true)[0] as GroupBox;
            selectedGroup = feedGr.Text;
            string comboboxName = feedGrName.Replace("gb", "cb"); // gbTool1 -> cbTool1

            return feedGr.Controls.Find(comboboxName, true)[0] as ComboBox;
        }

        private void pbShowTool_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = FindToolCombobox((sender as PictureBox).Name, "pbShow");

            string toolName = comboBox.SelectedItem.ToString();

            if (string.IsNullOrEmpty(toolName)) return;

            var existTool = Globals.serviceManager.GetTool(toolName);
            using (var toolShow = new form_ShowTool(existTool, selectedGroup))
            {
                toolShow.ShowDialog();
            }
        }

        private void pbPlaceTool_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = FindToolCombobox((sender as PictureBox).Name, "pbPlace");

            string toolName = comboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(toolName)) return;

            var existTool = Globals.serviceManager.GetTool(toolName);
            string codWorkValue = Globals.serviceManager.GetToolValue(existTool, "codWork");
            string codSideValue = Globals.serviceManager.GetToolValue(existTool, "codSide");
            string codSubWorkValue = Globals.serviceManager.GetToolValue(existTool, "codSubWork");

            string workName = Globals.serviceManager.GetFieldName("codWork", codWorkValue);
            string sideName = Globals.serviceManager.GetFieldName("codSide", codSideValue);
            string sWorkName = Globals.serviceManager.GetFieldName("codSubWork", codSubWorkValue);

            string nodeTag = string.Format("{0}|{1}|{2}|{3}", workName, sideName, sWorkName, toolName);

            SelectNodeByTag(twTools, nodeTag);
        }

        public void SelectNodeByTag(TreeView treeView, object tagValue)
        {
            twTools.Select();
            twTools.Focus();
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode foundNode = FindNodeByTag(node, tagValue);
                if (foundNode != null)
                {
                    treeView.SelectedNode = foundNode;
                    foundNode.EnsureVisible(); // Seçili düğümü görünür yap
                    break;
                }
            }
        }

        private TreeNode FindNodeByTag(TreeNode node, object tagValue)
        {
            if (node.Tag != null && node.Tag.Equals(tagValue))
            {
                return node;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                TreeNode foundNode = FindNodeByTag(childNode, tagValue);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }

        private void dgvToolInfo_Leave(object sender, EventArgs e)
        {
            if (dgvToolInfo.RowCount > 0)
                EnableStateDgvToolInfo(false);
        }

        private void twTools_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.ToString().Split('|').Length != 4) return;

            EnableStateDgvToolInfo(true);
        }

        private void EnableStateDgvToolInfo(bool state)
        {
            dgvToolInfo.ReadOnly = !state;
            if (dgvToolInfo.RowCount > 0)
            {
                dgvToolInfo.Rows[0].Cells[1].Selected = state;
            }

            twTools.Enabled = !state;
            pbEditOK.Enabled = state;
            pbEditCancel.Enabled = state;
        }

        private void dgvToolInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvToolInfo.ReadOnly)
            {
                e.Cancel = true;
                return;
            }

            if (dgvToolInfo.Rows[e.RowIndex].Cells["Field"].Value.ToString() == "group")
            {
                e.Cancel = true;
                return;
            }

            selectedField = dgvToolInfo.Rows[e.RowIndex].Cells["Field"].Value.ToString();
            selectedValue = dgvToolInfo.Rows[e.RowIndex].Cells["Value"].Value.ToString();
        }

        string selectedField;
        string selectedValue;
        private void dgvToolInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToolInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dgvToolInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = selectedValue;
            }
        }

        private void dgvToolInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToolInfo.Rows.Count > 0)
            {
                EnableStateDgvToolInfo(true);
                dgvToolInfo.Rows[e.RowIndex].Cells["Value"].Selected = true;
                dgvToolInfo.Columns[0].ReadOnly = true;
            }
        }

        private void pbToolSettings_Click(object sender, EventArgs e)
        {
            using (var form = new form_TechnologicalParameters())
            {
                form.ShowDialog();

                LoadFeedTools();
            }
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            if (changedToolsData)
            {
                Globals.serviceManager.WriteXml(Globals.EntityDbTools);
            }

            if (changedOutfitData)
            {
                Globals.serviceManager.WriteXml(Globals.EntityDbOutfits);
            }

            if(changedToolsData || changedOutfitData)
                MessageBox.Show(Globals.serviceManager.ReadMessage("7", Globals.XmlngToolManager), "ToolManager", MessageBoxButtons.OK, MessageBoxIcon.Information);

            changedOutfitData = false;
            changedToolsData = false;
        }

        private void pbToolInfo_Click(object sender, EventArgs e)
        {
            string nameWork = twTools.SelectedNode.Tag.ToString().Split('|')[0];
            string nameSide = twTools.SelectedNode.Tag.ToString().Split('|')[1];
            string nameSubWork = twTools.SelectedNode.Tag.ToString().Split('|')[2];

            string valWork = Globals.serviceManager.GetFieldValue("codWork", nameWork);
            string valSide = Globals.serviceManager.GetFieldValue("codSide", nameSide);
            string valSubWork = Globals.serviceManager.GetFieldValue("codSubWork", nameSubWork);

            string baseUTE = @"C:\Albatros\system\Tecno\Img\UTE";

            string imgFile = $@"{baseUTE}\UTE_{valWork}_{valSide}_{valSubWork}.jpg";

            if(!File.Exists(imgFile))
            {
                MessageBox.Show(Globals.serviceManager.ReadMessage("5",Globals.XmlngToolManager), "ToolManager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                from_PreviewTool preview = new from_PreviewTool(imgFile);
                preview.ShowDialog();
            }
        }
    }
}
