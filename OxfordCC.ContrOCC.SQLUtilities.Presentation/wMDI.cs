using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wMDI : Form
	{
		public wMDI()
		{
			InitializeComponent();
		}

		#region Tools Menu Items

		private void scriptParserViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenMDIChildWindow(new wScriptParserViewer2());
		}

		private void scriptCheckerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenMDIChildWindow(new wScriptChecker2());
		}

		#endregion

		#region Windows Menu Items

		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		#endregion

		#region Helper methods

		private void OpenMDIChildWindow(Form windowForm)
		{
			windowForm.MdiParent = this;
			windowForm.Show();
		}
		
		#endregion
	}
}
