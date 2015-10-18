namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	partial class wMDI
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scriptParserViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scriptCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.windowsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptParserViewerToolStripMenuItem,
            this.scriptCheckerToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// windowsToolStripMenuItem
			// 
			this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem});
			this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
			this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.windowsToolStripMenuItem.Text = "Windows";
			// 
			// scriptParserViewerToolStripMenuItem
			// 
			this.scriptParserViewerToolStripMenuItem.Name = "scriptParserViewerToolStripMenuItem";
			this.scriptParserViewerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.scriptParserViewerToolStripMenuItem.Text = "Script Parser Viewer";
			this.scriptParserViewerToolStripMenuItem.Click += new System.EventHandler(this.scriptParserViewerToolStripMenuItem_Click);
			// 
			// scriptCheckerToolStripMenuItem
			// 
			this.scriptCheckerToolStripMenuItem.Name = "scriptCheckerToolStripMenuItem";
			this.scriptCheckerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.scriptCheckerToolStripMenuItem.Text = "Script Checker";
			this.scriptCheckerToolStripMenuItem.Click += new System.EventHandler(this.scriptCheckerToolStripMenuItem_Click);
			// 
			// tileHorizontalToolStripMenuItem
			// 
			this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
			this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
			this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
			// 
			// tileVerticalToolStripMenuItem
			// 
			this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
			this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.tileVerticalToolStripMenuItem.Text = "Tile Vertical";
			this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.cascadeToolStripMenuItem.Text = "Cascade";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
			// 
			// wMDI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "wMDI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ContrOCC SQL Uitlities";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scriptParserViewerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scriptCheckerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
	}
}