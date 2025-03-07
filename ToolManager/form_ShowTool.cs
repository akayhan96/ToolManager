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
    public partial class form_ShowTool : Form
    {
        public form_ShowTool(ToolData toolData, string pos)
        {
            InitializeComponent();

            lblTitle.Text = $"Pos No : {pos}";

            PrepareDgvToolInfo(toolData);

            dgvToolInfo.ClearSelection();
            dgvToolInfo.Rows[0].Cells[0].Selected = false;
            dgvToolInfo.Rows[0].Selected = false;
            dgvToolInfo.Enabled = false;

            lblTitle.Select();
            lblTitle.Focus();
        }

        private void PrepareDgvToolInfo(ToolData toolData)
        {
            string codWorkValue = Globals.serviceManager.GetToolValue(toolData, "codWork");
            string codSideValue = Globals.serviceManager.GetToolValue(toolData, "codSide");
            string codSubWorkValue = Globals.serviceManager.GetToolValue(toolData, "codSubWork");


            string[] viewParameters = new string[]
            {
                Globals.serviceManager.GetFieldName("codWork", codWorkValue),    
                Globals.serviceManager.GetFieldName("codSide", codSideValue),    
                Globals.serviceManager.GetFieldName("codSubWork", codSubWorkValue)
            };
            var toolViewList = Globals.serviceManager.GetToolViews(viewParameters);

            dgvToolInfo.Rows.Clear();

            var itemDesc = toolViewList.Items[0];
            string msgDesc = Globals.serviceManager.GetFieldText(itemDesc.MessageId);

            //Description(Takım Ad bilgisi)
            string msgValue = Globals.serviceManager.GetToolValue(toolData, itemDesc.Field);
            dgvToolInfo.Rows.Add(msgDesc, msgValue, "", "", itemDesc.Field);

            foreach (var group in toolViewList.Groups)
            {
                string groupText = Globals.serviceManager.GetFieldText(group.MessageId);
                dgvToolInfo.Rows.Add(groupText, "", "", "", "");
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
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
