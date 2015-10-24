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
				IList<ParseError> parseErrors;
				try
				{
					this.Cursor = Cursors.WaitCursor;
					ClearWindow();

					//IList<ParseError> parseErrors;
					TSqlFragment rootFragment = OpenScript(ofd.FileName, out parseErrors);

					if ((parseErrors == null) || (parseErrors.Count == 0))
						DisplayScript(rootFragment);
					else
						DisplayParseErrors(parseErrors);
				}
				catch (Exception ex)
				{
					DisplayException(ex);
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

		protected virtual TSqlFragment OpenScript(string scriptFilePath, out IList<ParseError> parseErrors)
		{
			TSqlFragment rootFragment;

			using (TextReader textReader = new StreamReader(scriptFilePath))
			{
				rootFragment = ScriptParser.GetRootFragment(textReader, out parseErrors);
			}

			return rootFragment;
		}

		protected virtual void DisplayScript(TSqlFragment rootFragment)
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}

		protected virtual void DisplayParseErrors(IList<ParseError> parseErrors)
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}

		protected virtual void DisplayException(Exception ex)
		{
			if (!this.DesignMode)
				throw new NotImplementedException();
		}
	}
}
