namespace PgEdit
{
    partial class TreeWorkspace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.tvTree = new System.Windows.Forms.TreeView();
            this.cmsDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnectDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsServer.SuspendLayout();
            this.cmsDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsServer
            // 
            this.cmsServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveServer});
            this.cmsServer.Name = "cmsStructure";
            this.cmsServer.Size = new System.Drawing.Size(128, 26);
            // 
            // tsmiRemoveServer
            // 
            this.tsmiRemoveServer.Name = "tsmiRemoveServer";
            this.tsmiRemoveServer.Size = new System.Drawing.Size(127, 22);
            this.tsmiRemoveServer.Text = "Удалить...";
            this.tsmiRemoveServer.Click += new System.EventHandler(this.tsmiRemoveServer_Click);
            // 
            // ilTreeView
            // 
            this.ilTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tvTree
            // 
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.ImageIndex = 0;
            this.tvTree.ImageList = this.ilTreeView;
            this.tvTree.Location = new System.Drawing.Point(0, 0);
            this.tvTree.Name = "tvTree";
            this.tvTree.SelectedImageIndex = 0;
            this.tvTree.Size = new System.Drawing.Size(223, 434);
            this.tvTree.TabIndex = 1;
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTree_NodeMouseDoubleClick);
            this.tvTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvTree_KeyDown);
            // 
            // cmsDatabase
            // 
            this.cmsDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDisconnectDatabase,
            this.tsmiRemoveDatabase});
            this.cmsDatabase.Name = "cmsDatabase";
            this.cmsDatabase.Size = new System.Drawing.Size(153, 70);
            // 
            // tsmiRemoveDatabase
            // 
            this.tsmiRemoveDatabase.Name = "tsmiRemoveDatabase";
            this.tsmiRemoveDatabase.Size = new System.Drawing.Size(152, 22);
            this.tsmiRemoveDatabase.Text = "Удалить";
            this.tsmiRemoveDatabase.Click += new System.EventHandler(this.tsmiRemoveDatabase_Click);
            // 
            // tsmiDisconnectDatabase
            // 
            this.tsmiDisconnectDatabase.Name = "tsmiDisconnectDatabase";
            this.tsmiDisconnectDatabase.Size = new System.Drawing.Size(152, 22);
            this.tsmiDisconnectDatabase.Text = "Отключиться";
            this.tsmiDisconnectDatabase.Click += new System.EventHandler(this.tsmiDisconnectDatabase_Click);
            // 
            // TreeWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvTree);
            this.Name = "TreeWorkspace";
            this.Size = new System.Drawing.Size(223, 434);
            this.Load += new System.EventHandler(this.TreeWorkspace_Load);
            this.cmsServer.ResumeLayout(false);
            this.cmsDatabase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsServer;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveServer;
        private System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.ContextMenuStrip cmsDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnectDatabase;
    }
}
