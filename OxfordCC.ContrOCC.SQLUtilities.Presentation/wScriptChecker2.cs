using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wScriptChecker2 : OxfordCC.ContrOCC.SQLUtilities.Presentation.wScriptBase
	{
		public wScriptChecker2()
		{
			InitializeComponent();
		}

		protected override void ClearWindow()
		{
			lvwIssues.Items.Clear();
        }

		protected override void DisplayScript(TSqlFragment rootFragment)
		{
			base.DisplayScript(rootFragment);
		}

		protected override void DisplayParseErrors(IList<ParseError> parseErrors)
		{
			base.DisplayParseErrors(parseErrors);
		}

		protected override void DisplayException(Exception ex)
		{
			base.DisplayException(ex);
		}
	}
}
