namespace ToolManager
{
    partial class form_ToolsConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_ToolsConfiguration));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.pbOK = new System.Windows.Forms.PictureBox();
            this.twToolTree = new System.Windows.Forms.TreeView();
            this.pnlHeader.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(337, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(12, 19);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(65, 26);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "label1";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlDashboard.Controls.Add(this.pbCancel);
            this.pnlDashboard.Controls.Add(this.pbOK);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 508);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(337, 60);
            this.pnlDashboard.TabIndex = 1;
            // 
            // pbCancel
            // 
            this.pbCancel.Image = ((System.Drawing.Image)(resources.GetObject("pbCancel.Image")));
            this.pbCancel.Location = new System.Drawing.Point(219, 5);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(50, 50);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancel.TabIndex = 1;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // pbOK
            // 
            this.pbOK.Image = ((System.Drawing.Image)(resources.GetObject("pbOK.Image")));
            this.pbOK.Location = new System.Drawing.Point(275, 5);
            this.pbOK.Name = "pbOK";
            this.pbOK.Size = new System.Drawing.Size(50, 50);
            this.pbOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOK.TabIndex = 0;
            this.pbOK.TabStop = false;
            this.pbOK.Click += new System.EventHandler(this.pbOK_Click);
            // 
            // twToolTree
            // 
            this.twToolTree.CheckBoxes = true;
            this.twToolTree.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twToolTree.Indent = 30;
            this.twToolTree.Location = new System.Drawing.Point(12, 71);
            this.twToolTree.Name = "twToolTree";
            this.twToolTree.Size = new System.Drawing.Size(313, 427);
            this.twToolTree.TabIndex = 2;
            this.twToolTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.twToolTree_BeforeCheck);
            this.twToolTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.twToolTree_NodeMouseClick);
            // 
            // form_ToolsConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 568);
            this.Controls.Add(this.twToolTree);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_ToolsConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools Configuration";
            this.Load += new System.EventHandler(this.form_ToolsConfiguration_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.TreeView twToolTree;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.PictureBox pbOK;
    }
}