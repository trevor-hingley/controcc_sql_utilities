namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	partial class wScriptChecker2
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
			this.lvwIssues = new System.Windows.Forms.ListView();
			this.IssueType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SQLText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvwIssues
			// 
			this.lvwIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IssueType,
            this.Line,
            this.SQLText});
			this.lvwIssues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwIssues.Location = new System.Drawing.Point(0, 24);
			this.lvwIssues.Name = "lvwIssues";
			this.lvwIssues.Size = new System.Drawing.Size(584, 338);
			this.lvwIssues.TabIndex = 1;
			this.lvwIssues.UseCompatibleStateImageBehavior = false;
			this.lvwIssues.View = System.Windows.Forms.View.Details;
			// 
			// IssueType
			// 
			this.IssueType.Text = "Issue Type";
			this.IssueType.Width = 200;
			// 
			// Line
			// 
			this.Line.Text = "Line";
			this.Line.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Line.Width = 50;
			// 
			// SQLText
			// 
			this.SQLText.Text = "SQL Text";
			this.SQLText.Width = 2000;
			// 
			// wScriptChecker2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(584, 362);
			this.Controls.Add(this.lvwIssues);
			this.Name = "wScriptChecker2";
			this.Controls.SetChildIndex(this.lvwIssues, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwIssues;
		private System.Windows.Forms.ColumnHeader IssueType;
		private System.Windows.Forms.ColumnHeader Line;
		private System.Windows.Forms.ColumnHeader SQLText;
	}
}
