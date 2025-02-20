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
            this.pbFresaTools = new System.Windows.Forms.PictureBox();
            this.pbDrillTools = new System.Windows.Forms.PictureBox();
            this.pbSawTools = new System.Windows.Forms.PictureBox();
            this.pnlToolTree = new System.Windows.Forms.Panel();
            this.twTools = new System.Windows.Forms.TreeView();
            this.pnlToolsHeader = new System.Windows.Forms.Panel();
            this.pnlToolInfo = new System.Windows.Forms.Panel();
            this.pnlToolEdit = new System.Windows.Forms.Panel();
            this.pbEditOK = new System.Windows.Forms.PictureBox();
            this.pbEditCancel = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pbToolInfo = new System.Windows.Forms.PictureBox();
            this.pnlFeedUnit = new System.Windows.Forms.Panel();
            this.pnlAppHeader = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblToolsTitle = new System.Windows.Forms.Label();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbToolSettings = new System.Windows.Forms.PictureBox();
            this.dgvToolInfo = new System.Windows.Forms.DataGridView();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlFeedUnitHeader = new System.Windows.Forms.Panel();
            this.lblFeedUnitTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFresaTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrillTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSawTools)).BeginInit();
            this.pnlToolTree.SuspendLayout();
            this.pnlToolsHeader.SuspendLayout();
            this.pnlToolInfo.SuspendLayout();
            this.pnlToolEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolInfo)).BeginInit();
            this.pnlFeedUnit.SuspendLayout();
            this.pnlAppHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolInfo)).BeginInit();
            this.pnlFeedUnitHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTools
            // 
            this.pnlTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTools.Controls.Add(this.pnlToolsHeader);
            this.pnlTools.Controls.Add(this.pnlToolTree);
            this.pnlTools.Controls.Add(this.pbSawTools);
            this.pnlTools.Controls.Add(this.pbDrillTools);
            this.pnlTools.Controls.Add(this.pbFresaTools);
            this.pnlTools.Location = new System.Drawing.Point(12, 89);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(260, 600);
            this.pnlTools.TabIndex = 0;
            // 
            // pbFresaTools
            // 
            this.pbFresaTools.Image = ((System.Drawing.Image)(resources.GetObject("pbFresaTools.Image")));
            this.pbFresaTools.Location = new System.Drawing.Point(10, 59);
            this.pbFresaTools.Name = "pbFresaTools";
            this.pbFresaTools.Size = new System.Drawing.Size(75, 75);
            this.pbFresaTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFresaTools.TabIndex = 0;
            this.pbFresaTools.TabStop = false;
            // 
            // pbDrillTools
            // 
            this.pbDrillTools.Image = ((System.Drawing.Image)(resources.GetObject("pbDrillTools.Image")));
            this.pbDrillTools.Location = new System.Drawing.Point(91, 59);
            this.pbDrillTools.Name = "pbDrillTools";
            this.pbDrillTools.Size = new System.Drawing.Size(75, 75);
            this.pbDrillTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDrillTools.TabIndex = 1;
            this.pbDrillTools.TabStop = false;
            // 
            // pbSawTools
            // 
            this.pbSawTools.Image = ((System.Drawing.Image)(resources.GetObject("pbSawTools.Image")));
            this.pbSawTools.Location = new System.Drawing.Point(172, 59);
            this.pbSawTools.Name = "pbSawTools";
            this.pbSawTools.Size = new System.Drawing.Size(75, 75);
            this.pbSawTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSawTools.TabIndex = 2;
            this.pbSawTools.TabStop = false;
            // 
            // pnlToolTree
            // 
            this.pnlToolTree.Controls.Add(this.twTools);
            this.pnlToolTree.Location = new System.Drawing.Point(11, 140);
            this.pnlToolTree.Name = "pnlToolTree";
            this.pnlToolTree.Size = new System.Drawing.Size(236, 444);
            this.pnlToolTree.TabIndex = 3;
            // 
            // twTools
            // 
            this.twTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twTools.Location = new System.Drawing.Point(0, 0);
            this.twTools.Name = "twTools";
            this.twTools.Size = new System.Drawing.Size(236, 444);
            this.twTools.TabIndex = 0;
            // 
            // pnlToolsHeader
            // 
            this.pnlToolsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsHeader.Controls.Add(this.lblToolsTitle);
            this.pnlToolsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlToolsHeader.Name = "pnlToolsHeader";
            this.pnlToolsHeader.Size = new System.Drawing.Size(258, 53);
            this.pnlToolsHeader.TabIndex = 4;
            // 
            // pnlToolInfo
            // 
            this.pnlToolInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolInfo.Controls.Add(this.dgvToolInfo);
            this.pnlToolInfo.Controls.Add(this.pnlToolEdit);
            this.pnlToolInfo.Location = new System.Drawing.Point(279, 89);
            this.pnlToolInfo.Name = "pnlToolInfo";
            this.pnlToolInfo.Size = new System.Drawing.Size(342, 660);
            this.pnlToolInfo.TabIndex = 1;
            // 
            // pnlToolEdit
            // 
            this.pnlToolEdit.Controls.Add(this.splitter1);
            this.pnlToolEdit.Controls.Add(this.pbEditCancel);
            this.pnlToolEdit.Controls.Add(this.pbEditOK);
            this.pnlToolEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolEdit.Location = new System.Drawing.Point(0, 595);
            this.pnlToolEdit.Name = "pnlToolEdit";
            this.pnlToolEdit.Size = new System.Drawing.Size(340, 63);
            this.pnlToolEdit.TabIndex = 0;
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
            // pbToolInfo
            // 
            this.pbToolInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbToolInfo.Location = new System.Drawing.Point(627, 508);
            this.pbToolInfo.Name = "pbToolInfo";
            this.pbToolInfo.Size = new System.Drawing.Size(301, 181);
            this.pbToolInfo.TabIndex = 2;
            this.pbToolInfo.TabStop = false;
            // 
            // pnlFeedUnit
            // 
            this.pnlFeedUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFeedUnit.Controls.Add(this.pnlFeedUnitHeader);
            this.pnlFeedUnit.Location = new System.Drawing.Point(934, 89);
            this.pnlFeedUnit.Name = "pnlFeedUnit";
            this.pnlFeedUnit.Size = new System.Drawing.Size(310, 600);
            this.pnlFeedUnit.TabIndex = 3;
            // 
            // pnlAppHeader
            // 
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
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Location = new System.Drawing.Point(9, 38);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(35, 13);
            this.lblAppTitle.TabIndex = 2;
            this.lblAppTitle.Text = "label1";
            // 
            // lblToolsTitle
            // 
            this.lblToolsTitle.AutoSize = true;
            this.lblToolsTitle.Location = new System.Drawing.Point(10, 21);
            this.lblToolsTitle.Name = "lblToolsTitle";
            this.lblToolsTitle.Size = new System.Drawing.Size(35, 13);
            this.lblToolsTitle.TabIndex = 3;
            this.lblToolsTitle.Text = "label2";
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
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1209, 736);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(34, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "v1.00";
            // 
            // pnlFeedUnitHeader
            // 
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
            this.lblFeedUnitTitle.Location = new System.Drawing.Point(14, 21);
            this.lblFeedUnitTitle.Name = "lblFeedUnitTitle";
            this.lblFeedUnitTitle.Size = new System.Drawing.Size(35, 13);
            this.lblFeedUnitTitle.TabIndex = 0;
            this.lblFeedUnitTitle.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(627, 89);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 413);
            this.textBox1.TabIndex = 6;
            // 
            // form_ToolManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 758);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbFresaTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrillTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSawTools)).EndInit();
            this.pnlToolTree.ResumeLayout(false);
            this.pnlToolsHeader.ResumeLayout(false);
            this.pnlToolsHeader.PerformLayout();
            this.pnlToolInfo.ResumeLayout(false);
            this.pnlToolEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEditOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolInfo)).EndInit();
            this.pnlFeedUnit.ResumeLayout(false);
            this.pnlAppHeader.ResumeLayout(false);
            this.pnlAppHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToolSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToolInfo)).EndInit();
            this.pnlFeedUnitHeader.ResumeLayout(false);
            this.pnlFeedUnitHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Panel pnlToolsHeader;
        private System.Windows.Forms.Panel pnlToolTree;
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
    }
}

