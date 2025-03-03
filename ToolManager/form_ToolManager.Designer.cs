namespace ToolManager
{
    partial class form_ToolManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_ToolManager));
            this.pnlTools = new System.Windows.Forms.Panel();
            this.pnlToolDashBoard = new System.Windows.Forms.Panel();
            this.pbConfigureTools = new System.Windows.Forms.PictureBox();
            this.pbEditTool = new System.Windows.Forms.PictureBox();
            this.pbCopyTool = new System.Windows.Forms.PictureBox();
            this.pbAddTool = new System.Windows.Forms.PictureBox();
            this.pbRemoveTool = new System.Windows.Forms.PictureBox();
            this.twTools = new System.Windows.Forms.TreeView();
            this.pnlToolsHeader = new System.Windows.Forms.Panel();
            this.lblToolsTitle = new System.Windows.Forms.Label();
            this.pbSawTools = new System.Windows.Forms.PictureBox();
            this.pbDrillTools = new System.Windows.Forms.PictureBox();
            this.pbFresaTools = new System.Windows.Forms.PictureBox();
            this.pnlToolInfo = new System.Windows.Forms.Panel();
            this.dgvToolInfo = new System.Windows.Forms.DataGridView();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlToolEdit = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pbEditCancel = new System.Windows.Forms.PictureBox();
            this.pbEditOK = new System.Windows.Forms.PictureBox();
            this.pbToolInfo = new System.Windows.Forms.PictureBox();
            this.pnlFeedUnit = new System.Windows.Forms.Panel();
            this.pnlFeedUnitHeader = new System.Windows.Forms.Panel();
            this.lblFeedUnitTitle = new System.Windows.Forms.Label();
            this.pnlAppHeader = new System.Windows.Forms.Panel();
            this.pbToolSettings = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlTools.SuspendLayout();
            this.pnlToolDashBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfigureTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopyTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveTool)).BeginInit();
            this.pnlToolsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSawTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrillTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFresaTools)).BeginInit();
            this.pnlToolInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolInfo)).BeginInit();
            this.pnlToolEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolInfo)).BeginInit();
            this.pnlFeedUnit.SuspendLayout();
            this.pnlFeedUnitHeader.SuspendLayout();
            this.pnlAppHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTools
            // 
            this.pnlTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTools.Controls.Add(this.pnlToolDashBoard);
            this.pnlTools.Controls.Add(this.twTools);
            this.pnlTools.Controls.Add(this.pnlToolsHeader);
            this.pnlTools.Controls.Add(this.pbSawTools);
            this.pnlTools.Controls.Add(this.pbDrillTools);
            this.pnlTools.Controls.Add(this.pbFresaTools);
            this.pnlTools.Location = new System.Drawing.Point(12, 89);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(307, 660);
            this.pnlTools.TabIndex = 0;
            // 
            // pnlToolDashBoard
            // 
            this.pnlToolDashBoard.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlToolDashBoard.Controls.Add(this.pbConfigureTools);
            this.pnlToolDashBoard.Controls.Add(this.pbEditTool);
            this.pnlToolDashBoard.Controls.Add(this.pbCopyTool);
            this.pnlToolDashBoard.Controls.Add(this.pbAddTool);
            this.pnlToolDashBoard.Controls.Add(this.pbRemoveTool);
            this.pnlToolDashBoard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolDashBoard.Location = new System.Drawing.Point(0, 595);
            this.pnlToolDashBoard.Name = "pnlToolDashBoard";
            this.pnlToolDashBoard.Size = new System.Drawing.Size(305, 63);
            this.pnlToolDashBoard.TabIndex = 5;
            // 
            // pbConfigureTools
            // 
            this.pbConfigureTools.Image = ((System.Drawing.Image)(resources.GetObject("pbConfigureTools.Image")));
            this.pbConfigureTools.Location = new System.Drawing.Point(249, 7);
            this.pbConfigureTools.Name = "pbConfigureTools";
            this.pbConfigureTools.Size = new System.Drawing.Size(50, 50);
            this.pbConfigureTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConfigureTools.TabIndex = 6;
            this.pbConfigureTools.TabStop = false;
            this.pbConfigureTools.Click += new System.EventHandler(this.pbConfigureTools_Click);
            // 
            // pbEditTool
            // 
            this.pbEditTool.Image = ((System.Drawing.Image)(resources.GetObject("pbEditTool.Image")));
            this.pbEditTool.Location = new System.Drawing.Point(127, 7);
            this.pbEditTool.Name = "pbEditTool";
            this.pbEditTool.Size = new System.Drawing.Size(50, 50);
            this.pbEditTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEditTool.TabIndex = 5;
            this.pbEditTool.TabStop = false;
            this.pbEditTool.Click += new System.EventHandler(this.pbEditTool_Click);
            // 
            // pbCopyTool
            // 
            this.pbCopyTool.Image = ((System.Drawing.Image)(resources.GetObject("pbCopyTool.Image")));
            this.pbCopyTool.Location = new System.Drawing.Point(188, 7);
            this.pbCopyTool.Name = "pbCopyTool";
            this.pbCopyTool.Size = new System.Drawing.Size(50, 50);
            this.pbCopyTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCopyTool.TabIndex = 4;
            this.pbCopyTool.TabStop = false;
            this.pbCopyTool.Click += new System.EventHandler(this.pbCopyTool_Click);
            // 
            // pbAddTool
            // 
            this.pbAddTool.Image = ((System.Drawing.Image)(resources.GetObject("pbAddTool.Image")));
            this.pbAddTool.Location = new System.Drawing.Point(7, 7);
            this.pbAddTool.Name = "pbAddTool";
            this.pbAddTool.Size = new System.Drawing.Size(50, 50);
            this.pbAddTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddTool.TabIndex = 3;
            this.pbAddTool.TabStop = false;
            this.pbAddTool.Click += new System.EventHandler(this.pbAddTool_Click);
            // 
            // pbRemoveTool
            // 
            this.pbRemoveTool.Image = ((System.Drawing.Image)(resources.GetObject("pbRemoveTool.Image")));
            this.pbRemoveTool.Location = new System.Drawing.Point(68, 7);
            this.pbRemoveTool.Name = "pbRemoveTool";
            this.pbRemoveTool.Size = new System.Drawing.Size(50, 50);
            this.pbRemoveTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRemoveTool.TabIndex = 2;
            this.pbRemoveTool.TabStop = false;
            this.pbRemoveTool.Click += new System.EventHandler(this.pbRemoveTool_Click);
            // 
            // twTools
            // 
            this.twTools.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.twTools.Indent = 20;
            this.twTools.ItemHeight = 30;
            this.twTools.Location = new System.Drawing.Point(7, 144);
            this.twTools.Name = "twTools";
            this.twTools.ShowNodeToolTips = true;
            this.twTools.Size = new System.Drawing.Size(292, 444);
            this.twTools.TabIndex = 0;
            this.twTools.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.twTools_AfterSelect);
            // 
            // pnlToolsHeader
            // 
            this.pnlToolsHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlToolsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsHeader.Controls.Add(this.lblToolsTitle);
            this.pnlToolsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlToolsHeader.Name = "pnlToolsHeader";
            this.pnlToolsHeader.Size = new System.Drawing.Size(305, 62);
            this.pnlToolsHeader.TabIndex = 4;
            // 
            // lblToolsTitle
            // 
            this.lblToolsTitle.AutoSize = true;
            this.lblToolsTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToolsTitle.Location = new System.Drawing.Point(109, 21);
            this.lblToolsTitle.Name = "lblToolsTitle";
            this.lblToolsTitle.Size = new System.Drawing.Size(50, 19);
            this.lblToolsTitle.TabIndex = 3;
            this.lblToolsTitle.Text = "label2";
            // 
            // pbSawTools
            // 
            this.pbSawTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSawTools.Image = ((System.Drawing.Image)(resources.GetObject("pbSawTools.Image")));
            this.pbSawTools.Location = new System.Drawing.Point(224, 65);
            this.pbSawTools.Name = "pbSawTools";
            this.pbSawTools.Size = new System.Drawing.Size(75, 75);
            this.pbSawTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSawTools.TabIndex = 2;
            this.pbSawTools.TabStop = false;
            this.pbSawTools.Click += new System.EventHandler(this.pbSawTools_Click);
            // 
            // pbDrillTools
            // 
            this.pbDrillTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDrillTools.Image = ((System.Drawing.Image)(resources.GetObject("pbDrillTools.Image")));
            this.pbDrillTools.Location = new System.Drawing.Point(114, 65);
            this.pbDrillTools.Name = "pbDrillTools";
            this.pbDrillTools.Size = new System.Drawing.Size(75, 75);
            this.pbDrillTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDrillTools.TabIndex = 1;
            this.pbDrillTools.TabStop = false;
            this.pbDrillTools.Click += new System.EventHandler(this.pbDrillTools_Click);
            // 
            // pbFresaTools
            // 
            this.pbFresaTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFresaTools.Image = ((System.Drawing.Image)(resources.GetObject("pbFresaTools.Image")));
            this.pbFresaTools.Location = new System.Drawing.Point(7, 65);
            this.pbFresaTools.Name = "pbFresaTools";
            this.pbFresaTools.Size = new System.Drawing.Size(75, 75);
            this.pbFresaTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFresaTools.TabIndex = 0;
            this.pbFresaTools.TabStop = false;
            this.pbFresaTools.Click += new System.EventHandler(this.pbFresaTools_Click);
            // 
            // pnlToolInfo
            // 
            this.pnlToolInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolInfo.Controls.Add(this.dgvToolInfo);
            this.pnlToolInfo.Controls.Add(this.pnlToolEdit);
            this.pnlToolInfo.Location = new System.Drawing.Point(325, 89);
            this.pnlToolInfo.Name = "pnlToolInfo";
            this.pnlToolInfo.Size = new System.Drawing.Size(342, 660);
            this.pnlToolInfo.TabIndex = 1;
            // 
            // dgvToolInfo
            // 
            this.dgvToolInfo.AllowUserToAddRows = false;
            this.dgvToolInfo.AllowUserToDeleteRows = false;
            this.dgvToolInfo.AllowUserToOrderColumns = true;
            this.dgvToolInfo.AllowUserToResizeRows = false;
            this.dgvToolInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToolInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvToolInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToolInfo.ColumnHeadersVisible = false;
            this.dgvToolInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Info,
            this.Value,
            this.Min,
            this.Max,
            this.Field});
            this.dgvToolInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToolInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvToolInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvToolInfo.MultiSelect = false;
            this.dgvToolInfo.Name = "dgvToolInfo";
            this.dgvToolInfo.RowHeadersVisible = false;
            this.dgvToolInfo.Size = new System.Drawing.Size(340, 595);
            this.dgvToolInfo.TabIndex = 7;
            // 
            // Info
            // 
            this.Info.HeaderText = "Info";
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Min
            // 
            this.Min.HeaderText = "Min";
            this.Min.Name = "Min";
            this.Min.Visible = false;
            // 
            // Max
            // 
            this.Max.HeaderText = "Max";
            this.Max.Name = "Max";
            this.Max.Visible = false;
            // 
            // Field
            // 
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.Visible = false;
            // 
            // pnlToolEdit
            // 
            this.pnlToolEdit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlToolEdit.Controls.Add(this.splitter1);
            this.pnlToolEdit.Controls.Add(this.pbEditCancel);
            this.pnlToolEdit.Controls.Add(this.pbEditOK);
            this.pnlToolEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolEdit.Location = new System.Drawing.Point(0, 595);
            this.pnlToolEdit.Name = "pnlToolEdit";
            this.pnlToolEdit.Size = new System.Drawing.Size(340, 63);
            this.pnlToolEdit.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(340, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pbEditCancel
            // 
            this.pbEditCancel.Image = ((System.Drawing.Image)(resources.GetObject("pbEditCancel.Image")));
            this.pbEditCancel.Location = new System.Drawing.Point(228, 7);
            this.pbEditCancel.Name = "pbEditCancel";
            this.pbEditCancel.Size = new System.Drawing.Size(50, 50);
            this.pbEditCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEditCancel.TabIndex = 1;
            this.pbEditCancel.TabStop = false;
            this.pbEditCancel.Click += new System.EventHandler(this.pbEditCancel_Click);
            // 
            // pbEditOK
            // 
            this.pbEditOK.Image = ((System.Drawing.Image)(resources.GetObject("pbEditOK.Image")));
            this.pbEditOK.Location = new System.Drawing.Point(284, 7);
            this.pbEditOK.Name = "pbEditOK";
            this.pbEditOK.Size = new System.Drawing.Size(50, 50);
            this.pbEditOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEditOK.TabIndex = 0;
            this.pbEditOK.TabStop = false;
            this.pbEditOK.Click += new System.EventHandler(this.pbEditOK_Click);
            // 
            // pbToolInfo
            // 
            this.pbToolInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbToolInfo.Location = new System.Drawing.Point(673, 345);
            this.pbToolInfo.Name = "pbToolInfo";
            this.pbToolInfo.Size = new System.Drawing.Size(253, 181);
            this.pbToolInfo.TabIndex = 2;
            this.pbToolInfo.TabStop = false;
            // 
            // pnlFeedUnit
            // 
            this.pnlFeedUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFeedUnit.Controls.Add(this.pnlFeedUnitHeader);
            this.pnlFeedUnit.Location = new System.Drawing.Point(934, 89);
            this.pnlFeedUnit.Name = "pnlFeedUnit";
            this.pnlFeedUnit.Size = new System.Drawing.Size(310, 596);
            this.pnlFeedUnit.TabIndex = 3;
            // 
            // pnlFeedUnitHeader
            // 
            this.pnlFeedUnitHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlFeedUnitHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFeedUnitHeader.Controls.Add(this.lblFeedUnitTitle);
            this.pnlFeedUnitHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFeedUnitHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFeedUnitHeader.Name = "pnlFeedUnitHeader";
            this.pnlFeedUnitHeader.Size = new System.Drawing.Size(308, 62);
            this.pnlFeedUnitHeader.TabIndex = 0;
            // 
            // lblFeedUnitTitle
            // 
            this.lblFeedUnitTitle.AutoSize = true;
            this.lblFeedUnitTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblFeedUnitTitle.Location = new System.Drawing.Point(14, 21);
            this.lblFeedUnitTitle.Name = "lblFeedUnitTitle";
            this.lblFeedUnitTitle.Size = new System.Drawing.Size(50, 19);
            this.lblFeedUnitTitle.TabIndex = 0;
            this.lblFeedUnitTitle.Text = "label2";
            // 
            // pnlAppHeader
            // 
            this.pnlAppHeader.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlAppHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAppHeader.Controls.Add(this.pbToolSettings);
            this.pnlAppHeader.Controls.Add(this.pbSave);
            this.pnlAppHeader.Controls.Add(this.lblAppTitle);
            this.pnlAppHeader.Controls.Add(this.pbMinimize);
            this.pnlAppHeader.Controls.Add(this.pbExit);
            this.pnlAppHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlAppHeader.Name = "pnlAppHeader";
            this.pnlAppHeader.Size = new System.Drawing.Size(1256, 83);
            this.pnlAppHeader.TabIndex = 4;
            // 
            // pbToolSettings
            // 
            this.pbToolSettings.Image = ((System.Drawing.Image)(resources.GetObject("pbToolSettings.Image")));
            this.pbToolSettings.Location = new System.Drawing.Point(986, 10);
            this.pbToolSettings.Name = "pbToolSettings";
            this.pbToolSettings.Size = new System.Drawing.Size(60, 60);
            this.pbToolSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbToolSettings.TabIndex = 4;
            this.pbToolSettings.TabStop = false;
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(1052, 10);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(60, 60);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 3;
            this.pbSave.TabStop = false;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAppTitle.Location = new System.Drawing.Point(11, 27);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(129, 26);
            this.lblAppTitle.TabIndex = 2;
            this.lblAppTitle.Text = "Tool Manager";
            // 
            // pbMinimize
            // 
            this.pbMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimize.Image")));
            this.pbMinimize.Location = new System.Drawing.Point(1118, 10);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(60, 60);
            this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimize.TabIndex = 1;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            // 
            // pbExit
            // 
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(1184, 10);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(60, 60);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExit.TabIndex = 0;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1209, 736);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(34, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "v1.00";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(672, 90);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 249);
            this.textBox1.TabIndex = 6;
            // 
            // form_ToolManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1256, 752);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pnlAppHeader);
            this.Controls.Add(this.pnlFeedUnit);
            this.Controls.Add(this.pbToolInfo);
            this.Controls.Add(this.pnlToolInfo);
            this.Controls.Add(this.pnlTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_ToolManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Manager";
            this.Load += new System.EventHandler(this.form_ToolManager_Load);
            this.pnlTools.ResumeLayout(false);
            this.pnlToolDashBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbConfigureTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopyTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveTool)).EndInit();
            this.pnlToolsHeader.ResumeLayout(false);
            this.pnlToolsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSawTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrillTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFresaTools)).EndInit();
            this.pnlToolInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolInfo)).EndInit();
            this.pnlToolEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEditCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolInfo)).EndInit();
            this.pnlFeedUnit.ResumeLayout(false);
            this.pnlFeedUnitHeader.ResumeLayout(false);
            this.pnlFeedUnitHeader.PerformLayout();
            this.pnlAppHeader.ResumeLayout(false);
            this.pnlAppHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Panel pnlToolsHeader;
        private System.Windows.Forms.TreeView twTools;
        private System.Windows.Forms.PictureBox pbSawTools;
        private System.Windows.Forms.PictureBox pbDrillTools;
        private System.Windows.Forms.PictureBox pbFresaTools;
        private System.Windows.Forms.Label lblToolsTitle;
        private System.Windows.Forms.Panel pnlToolInfo;
        private System.Windows.Forms.Panel pnlToolEdit;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pbEditCancel;
        private System.Windows.Forms.PictureBox pbEditOK;
        private System.Windows.Forms.PictureBox pbToolInfo;
        private System.Windows.Forms.Panel pnlFeedUnit;
        private System.Windows.Forms.Panel pnlAppHeader;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.PictureBox pbMinimize;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbToolSettings;
        private System.Windows.Forms.DataGridView dgvToolInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.Panel pnlFeedUnitHeader;
        private System.Windows.Forms.Label lblFeedUnitTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlToolDashBoard;
        private System.Windows.Forms.PictureBox pbConfigureTools;
        private System.Windows.Forms.PictureBox pbEditTool;
        private System.Windows.Forms.PictureBox pbCopyTool;
        private System.Windows.Forms.PictureBox pbAddTool;
        private System.Windows.Forms.PictureBox pbRemoveTool;
    }
}

