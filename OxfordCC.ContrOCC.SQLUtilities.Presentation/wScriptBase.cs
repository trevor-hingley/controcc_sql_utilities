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
		private oScriptParser _scriptParser = new oScriptParser();

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
				catch (Exception ex)
				{
					DisplayError(ex);
				}
				finally
				{
					this.Cursor = saveCursor;
				}
			}
		}

		protected virtual void ClearWindow()
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}

		protected virtual void OpenScript(string scriptFilePath)
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}

		protected virtual void DisplayError(Exception ex)
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}
	}
}
