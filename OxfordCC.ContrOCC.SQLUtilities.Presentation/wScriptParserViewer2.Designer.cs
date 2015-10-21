namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	partial class wScriptParserViewer2
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvwFragmentTree = new System.Windows.Forms.TreeView();
			this.txtFragmentSQL = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvwFragmentTree);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtFragmentSQL);
			this.splitContainer1.Size = new System.Drawing.Size(584, 338);
			this.splitContainer1.SplitterDistance = 235;
			this.splitContainer1.TabIndex = 1;
			// 
			// tvwFragmentTree
			// 
			this.tvwFragmentTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwFragmentTree.Location = new System.Drawing.Point(0, 0);
			this.tvwFragmentTree.Name = "tvwFragmentTree";
			this.tvwFragmentTree.Size = new System.Drawing.Size(235, 338);
			this.tvwFragmentTree.TabIndex = 0;
			this.tvwFragmentTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFragmentTree_BeforeExpand);
			this.tvwFragmentTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFragmentTree_AfterSelect);
			// 
			// txtFragmentSQL
			// 
			this.txtFragmentSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFragmentSQL.Location = new System.Drawing.Point(0, 0);
			this.txtFragmentSQL.Multiline = true;
			this.txtFragmentSQL.Name = "txtFragmentSQL";
			this.txtFragmentSQL.Size = new System.Drawing.Size(345, 338);
			this.txtFragmentSQL.TabIndex = 0;
			// 
			// wScriptParserViewer2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(584, 362);
			this.Controls.Add(this.splitContainer1);
			this.Name = "wScriptParserViewer2";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView tvwFragmentTree;
		private System.Windows.Forms.TextBox txtFragmentSQL;
	}
}
