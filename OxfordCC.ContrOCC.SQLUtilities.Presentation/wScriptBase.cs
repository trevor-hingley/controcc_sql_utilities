using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wScriptBase : Form
	{
		private oScriptParser _scriptParser;

		protected oScriptParser ScriptParser
		{
			get
			{
				return _scriptParser;
			}
		}

		public wScriptBase()
		{
			InitializeComponent();
		}

		private void wScriptBase_Load(object sender, EventArgs e)
		{
			// PLaced here rather than in wScriptBase() constructor
			// as this.DesignMode does not work properly there!!!
			if (!this.DesignMode)
			{
				_scriptParser = new oScriptParser();
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.Filter = "(SQL Script) | *.sql";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Cursor saveCursor = this.Cursor;

				try
				{
					this.Cursor = Cursors.WaitCursor;
					ClearWindow();
					OpenScript(ofd.FileName);
				}
				catch
				{ }
				finally
				{
					this.Cursor = saveCursor;
				}
			}
		}

		protected virtual void ClearWindow()
		{
			throw new NotImplementedException();
		}

		protected virtual void OpenScript(string scriptFilePath)
		{
			throw new NotImplementedException();
		}
	}
}
